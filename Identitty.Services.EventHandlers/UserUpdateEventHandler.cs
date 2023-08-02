using ApplicationErrorException;
using Domain;
using Identitty.Services.EventHandlers.Commands;
using Identity.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using System.Xml.Linq;

namespace Identitty.Services.EventHandlers
{
    public class UserUpdateEventHandler : IRequestHandler<UserUpdateCommand, BaseResult<string>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserUpdateEventHandler> _logger;

        public UserUpdateEventHandler(IUserService userService, ILogger<UserUpdateEventHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Actualizando usuario - {Request}", JsonSerializer.Serialize(request));
            try
            {

                User? user = _userService.GetById(request.Id);

                if(user is null)
                    throw new ApplicationErrorExceptions("No se encontro un usuario con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                user.Name = request.Name;
                user.LastName = request.LastName;
                user.Dni = request.Dni;
                user.Email = request.Email;

                ValidateEmail(user);


                _userService.Update(user);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al modificar el usuario.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }

        private void ValidateEmail(User request)
        {
            var exist = _userService.VerifyEmail(request.Email.ToLower());

            if (!exist) return;

            _logger.LogError("Email: ya existente: {Request}", JsonSerializer.Serialize(request));
            throw new ApplicationErrorExceptions("Email ya existente", (int)ErrorDictionary.GeneralCodes.ModelStateInvalid);
        }

      

    }
}
