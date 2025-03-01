using MicroEngine.Framework.Commons;

namespace MicroEngine.Models.RequestModels
{
    public class LoginModel : BaseModel
    {
        public LoginModel() { }

        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
