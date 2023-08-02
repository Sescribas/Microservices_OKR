using MediatR;
using Newtonsoft.Json;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identitty.Services.EventHandlers.Commands
{
    public class UserUpdateCommand : IRequest<BaseResult<string>>
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dni")]
        public string Dni { get; set; }
    }
}
