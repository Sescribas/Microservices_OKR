using OKR.Common.Domain;
using Identitty.Services.EventHandlers.Commands;
using OKR.Common.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationErrorException;

namespace Identitty.Services.EventHandlers
{
    public class UserCreateEventHandler : IRequestHandler<UserCreateCommand, BaseResult<string>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserCreateEventHandler> _logger;

        public UserCreateEventHandler(IUserService userService, ILogger<UserCreateEventHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creando usuario - {Request}", JsonSerializer.Serialize(request));
            try
            {

                User userToCreate = MapUser(request);

                ValidateUserName(request);

                ValidateEmail(request);

            
                _userService.Create(userToCreate);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al crear el usuario.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }


        private void ValidateUserName(UserCreateCommand request)
        {
            var exist = _userService.VerifyUserName(request.UserName.ToLower());
            if (!exist) return;

            _logger.LogError("Username ya existente: {Request}", JsonSerializer.Serialize(request));
            throw new ApplicationErrorExceptions("Usuario ya existente", (int)ErrorDictionary.GeneralCodes.ModelStateInvalid);
        }

        private void ValidateEmail(UserCreateCommand request)
        {
            var exist = _userService.VerifyEmail(request.Email.ToLower());

            if (!exist) return;

            _logger.LogError("Email: ya existente: {Request}", JsonSerializer.Serialize(request));
            throw new ApplicationErrorExceptions("Email ya existente", (int)ErrorDictionary.GeneralCodes.ModelStateInvalid);
        }

        private User MapUser(UserCreateCommand request)
        {
            return new User
            {
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email
            };
        }

    }
}
