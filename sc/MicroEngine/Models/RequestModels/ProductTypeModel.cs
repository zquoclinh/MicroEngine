using MicroEngine.Framework.Commons;

namespace MicroEngine.Models.RequestModels
{
    public class ProductTypeModel : BaseModel
    {
        public string TypeCode { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
    }
}
