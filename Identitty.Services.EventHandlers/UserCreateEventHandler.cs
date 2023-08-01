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
using System.Text.Json;
using System.Threading.Tasks;

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


            User userToCreate = new User
            {
                UserName = request.UserName,
                Password = request.Password,
                Name = request.Name,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email
            }; 

            _userService.Create(userToCreate);
            //ValidateUserName(request);

            //ValidateEmail(request);


            return new BaseResult<string> { Success = true };


        }


        //private void ValidateUserName(UserCreateCommand request)
        //{
        //    var exist = _userService.Users.Any(x => x.UserName.ToLower() == request.UserName.ToLower());

        //    if (!exist) return;

        //    _logger.LogError("Username ya existente: {Request}", JsonSerializer.Serialize(request));
        //    throw new ApplicationErrorException("Usuario ya existente", (int)GeneralCodes.ModelStateInvalid);
        //}

        //private void ValidateEmail(UserCreateCommand request)
        //{
        //    var exist = _userService.Users.Any(x => x.Email.ToLower() == request.Email.ToLower());

        //    if (!exist) return;

        //    _logger.LogError("Email: ya existente: {Request}", JsonSerializer.Serialize(request));
        //    throw new ApplicationErrorException("Email ya existente", (int)GeneralCodes.ModelStateInvalid);
        //}
    }
}
