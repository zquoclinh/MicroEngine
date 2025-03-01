using MicroEngine.Framework.Commons;

namespace MicroEngine.Data.Entities
{
    public class EmailTemplate : BaseEntity
    {
        /// <summary>
        /// TemplateId
        /// </summary>
        public string TemplateId { get; set; } = string.Empty;

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Attachments { get; set; } = string.Empty;
    }
}
