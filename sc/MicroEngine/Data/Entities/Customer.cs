using MicroEngine.Framework.Commons;
using Newtonsoft.Json;

namespace MicroEngine.Data.Entities
{
    public class Customer : BaseEntity
    {
        [JsonProperty("customer_id")]
        public string CustomerID { get; set; } = string.Empty;

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; } = string.Empty;
    }
}
