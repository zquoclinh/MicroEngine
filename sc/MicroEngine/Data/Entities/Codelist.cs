using MicroEngine.Framework.Commons;

namespace MicroEngine.Data.Entities
{
    public class Codelist : BaseEntity
    {
        public string CodeGroup { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;
        public string CodeId { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
    }
}
