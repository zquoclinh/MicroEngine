using MicroEngine.Framework.Commons;
using MimeKit;

namespace MicroEngine.Models.RequestModels
{
    public class SendMailModel : BaseModel
    {
        /// <summary>
        /// MailTemplateModel constructor
        /// </summary>
        public SendMailModel() { }

        /// <summary>
        /// TemplateId
        /// </summary>
        public string TemplateId { get; set; } = string.Empty;

        /// <summary>
        /// Sender
        /// </summary>
        public string ConfigId { get; set; } = string.Empty;

        /// <summary>
        /// Receiver
        /// </summary>
        public string Receiver { get; set; } = string.Empty;

        /// <summary>
        /// DataTemplate
        /// </summary>
        public Dictionary<string, object> DataTemplate { get; set; } =
            new Dictionary<string, object>();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<string> AttachmentBase64Strings { get; set; } = new List<string>();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<string> AttachmentFilenames { get; set; } = new List<string>();

        /// <summary>
        ///
        /// </summary>

        public List<MimeEntity> MimeEntities { get; set; } = new List<MimeEntity>();

        /// <summary>
        ///
        /// </summary>
        public bool IncludeLogo { get; set; } = false;
    }
}
