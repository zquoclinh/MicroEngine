using System.ComponentModel.DataAnnotations;
using MicroEngine.Framework.Commons;
using Newtonsoft.Json;

namespace MicroEngine.Models.RequestModels
{
    public class ProductModel : BaseModel
    {
        public ProductModel() { }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; } = string.Empty;

        [JsonProperty("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [JsonProperty("product_description")]
        public string ProductDescription { get; set; } = string.Empty;

        [JsonProperty("product_type")]
        public string ProductType { get; set; } = string.Empty;

        [JsonProperty("product_category")]
        public string ProductCategory { get; set; } = string.Empty;

        [JsonProperty("product_price")]
        public double ProductPrice { get; set; }
    }
}
