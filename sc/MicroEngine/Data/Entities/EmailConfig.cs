using MicroEngine.Framework.Commons;

namespace MicroEngine.Data.Entities
{
    public class EmailConfig : BaseEntity
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string ConfigId { get; set; } = string.Empty;

        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public string Sender { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// EnableTLS
        /// </summary>
        public bool EnableTLS { get; set; }
    }
}
