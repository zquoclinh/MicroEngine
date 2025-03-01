using MicroEngine.Framework.Commons;
using Newtonsoft.Json;

namespace MicroEngine.Framework.Entity
{
    public class User : BaseEntity
    {
        [JsonProperty("user_code")]
        public string UserCode { get; set; }

        [JsonProperty("login_name")]
        public string LoginName { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }
    }
}
