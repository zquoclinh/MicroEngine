using System.Text.RegularExpressions;
using AutoMapper.Internal;
using MailKit.Net.Smtp;
using MailKit.Security;
using MicroEngine.Data.Entities;
using MicroEngine.Framework.Repository;
using MicroEngine.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json.Linq;

namespace MicroEngine.Services.Services.EmailService
{
    public partial class EmailService : IEmailService
    {
        private readonly IRepository<EmailConfig> _configRepository;
        private readonly IRepository<EmailTemplate> _templateRepository;

        public EmailService(
            IRepository<EmailConfig> configRepository,
            IRepository<EmailTemplate> templateRepository
        )
        {
            _configRepository = configRepository;
            _templateRepository = templateRepository;
        }

        public async Task HandleSendMail(SendMailModel mailRequest)
        {
            try
            {
                var getMailConfig = await _configRepository
                    .Table.Where(s => s.ConfigId == mailRequest.ConfigId)
                    .FirstOrDefaultAsync();
                var getMailTemplate = await _templateRepository
                    .Table.Where(s => s.TemplateId == mailRequest.TemplateId)
                    .FirstOrDefaultAsync();
                if (getMailConfig == null || getMailTemplate == null)
                    throw new Exception("Mail Config or Mail Template not found");

                var email = new MimeMessage { Sender = MailboxAddress.Parse(getMailConfig.Sender) };

                foreach (
                    var address in mailRequest.Receiver.Split(
                        new[] { ";" },
                        StringSplitOptions.RemoveEmptyEntries
                    )
                )
                {
                    email.To.Add(MailboxAddress.Parse(address));
                }
                email.Subject = ReplaceData(getMailTemplate.Subject, mailRequest.DataTemplate);

                var builder = new BodyBuilder();
                if (
                    mailRequest.AttachmentBase64Strings != null
                    && mailRequest.AttachmentBase64Strings.Count > 0
                )
                {
                    List<byte[]> attachmentByteArrays = mailRequest
                        .AttachmentBase64Strings.Select(base64String =>
                            Convert.FromBase64String(base64String)
                        )
                        .ToList();
                    for (int i = 0; i < attachmentByteArrays.Count; i++)
                    {
                        byte[] byteArray = attachmentByteArrays[i];
                        string filename = mailRequest.AttachmentFilenames[i];

                        builder.Attachments.Add(filename, byteArray);
                    }
                }
                if (mailRequest.MimeEntities != null && mailRequest.MimeEntities.Count > 0)
                {
                    foreach (var entity in mailRequest.MimeEntities)
                    {
                        builder.LinkedResources.Add(entity);
                    }
                }
                //if (mailRequest.IncludeLogo)
                //{
                //    var imagePartFooter = new MimePart(new ContentType("image", "png"))
                //    {
                //        ContentId = "logo_footer",
                //        Content = new MimeContent(new MemoryStream(Convert.FromBase64String(_setting.LogoBankFooter))),
                //    };
                //    var imagePartHeader = new MimePart(new ContentType("image", "png"))
                //    {
                //        ContentId = "logo_header",
                //        Content = new MimeContent(new MemoryStream(Convert.FromBase64String(_setting.LogoBankHeader))),
                //    };
                //    builder.LinkedResources.Add(imagePartFooter);
                //    builder.LinkedResources.Add(imagePartHeader);
                //}

                builder.HtmlBody = ReplaceData(getMailTemplate.Body, mailRequest.DataTemplate);
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(
                    getMailConfig.Host,
                    getMailConfig.Port,
                    getMailConfig.EnableTLS
                        ? SecureSocketOptions.StartTls
                        : SecureSocketOptions.StartTlsWhenAvailable
                );
                smtp.Authenticate(getMailConfig.Sender, getMailConfig.Password);

                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private static string ReplaceData(string para, Dictionary<string, object> data)
        {
            if (para == null || data == null)
                return para;

            string pattern = "@\\{([^\\{]*)\\}";

            foreach (Match match in Regex.Matches(para, pattern).Cast<Match>())
            {
                if (match.Success && match.Groups.Count > 0)
                {
                    var text = match.Groups[1].Value;
                    try
                    {
                        var value = JObject.Parse(System.Text.Json.JsonSerializer.Serialize(data));
                        if (value.SelectToken(text) != null)
                            para = para.Replace(
                                match.Groups[0].Value,
                                value.SelectToken(text).ToString()
                            );
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(
                            "CANT FIND "
                                + text
                                + " IN DATA SAMPLE "
                                + System.Text.Json.JsonSerializer.Serialize(data)
                                + ex.StackTrace
                        );
                    }
                }
            }
            return para;
        }
    }
}
