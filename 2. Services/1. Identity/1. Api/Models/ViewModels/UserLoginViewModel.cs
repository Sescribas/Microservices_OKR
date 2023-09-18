using Newtonsoft.Json;

namespace Identity.api.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
