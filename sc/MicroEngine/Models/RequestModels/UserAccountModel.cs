using MicroEngine.Framework.Commons;
using Newtonsoft.Json;

namespace MicroEngine.Models.RequestModels
{
    public class UserAccountModel : BaseModel
    {
        public UserAccountModel() { }

        [JsonProperty("user_code")]
        public string UserCode { get; set; } = string.Empty;

        [JsonProperty("user_name")]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty("login_name")]
        public string LoginName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("branch_code")]
        public string BranchCode { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("remaining_days_off")]
        public int RemainingDaysOff { get; set; }

        [JsonProperty("days_off_used")]
        public int DaysOffUsed { get; set; }

        [JsonProperty("position")]
        public string Posision { get; set; } = string.Empty;
    }

    public class UserUpdateModel : BaseModel
    {
        public UserUpdateModel() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_code")]
        public string UserCode { get; set; } = string.Empty;

        [JsonProperty("user_name")]
        public string UserName { get; set; } = string.Empty;

        [JsonProperty("login_name")]
        public string LoginName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("branch_code")]
        public string BranchCode { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("remaining_days_off")]
        public int RemainingDaysOff { get; set; }

        [JsonProperty("days_off_used")]
        public int DaysOffUsed { get; set; }

        [JsonProperty("position")]
        public string Posision { get; set; } = string.Empty;
    }
}
