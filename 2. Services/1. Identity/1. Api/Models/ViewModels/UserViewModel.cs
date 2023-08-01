using Newtonsoft.Json;

namespace Identity.api.Models.ViewModels
{
    public class UserViewModel
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dni")]
        public string Dni { get; set; }

    }
}
