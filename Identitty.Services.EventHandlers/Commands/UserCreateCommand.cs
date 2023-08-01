using MediatR;
using Newtonsoft.Json;
using OKR.Common.Results;
using System.ComponentModel.DataAnnotations;

namespace Identitty.Services.EventHandlers.Commands
{
    public class UserCreateCommand : IRequest<BaseResult<string>>
    {
        [Required(ErrorMessage ="The field {0} is requered.")]
        [JsonProperty("username")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "The field {0} is requered.")]
        //[RegularExpression("^(?=.[A-Z])(?=.\\d).{7,}$", ErrorMessage = "El campo Contraseña debe contener al menos una mayúscula, un número y tener 7 caracteres.")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is requered.")]
        [JsonProperty("dni")]
        public string Dni { get; set; }


    }
}