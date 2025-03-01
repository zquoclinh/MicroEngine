using MicroEngine.Framework.Commons;

namespace MicroEngine.Data.Entities
{
    public class Branch : BaseEntity
    {
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
    }
}
