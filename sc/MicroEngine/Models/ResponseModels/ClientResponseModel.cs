using MicroEngine.Framework.Commons;
using Newtonsoft.Json;

namespace MicroEngine.Models
{
    public class ClientResponseModel : BaseModel
    {
        [JsonProperty("client_name")]
        public string ClientName { get; set; } = string.Empty;

        [JsonProperty("date_of_birth")]
        public DateTime DayOfBirth { get; set; }
    }
}
