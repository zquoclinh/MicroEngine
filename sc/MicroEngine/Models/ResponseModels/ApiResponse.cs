using MicroEngine.Framework.Commons;

namespace MicroEngine.Models.ResponseModels
{
    public class ApiResponse : BaseModel
    {
        public ApiResponse() { }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
