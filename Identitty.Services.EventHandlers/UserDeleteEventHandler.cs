using ApplicationErrorException;
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

namespace Identitty.Services.EventHandlers
{
    public class UserDeleteEventHandler : IRequestHandler<UserDeleteCommand, BaseResult<string>>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserDeleteEventHandler> _logger;

        public UserDeleteEventHandler(IUserService userService, ILogger<UserDeleteEventHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Eliminando usuario - {Request}", JsonSerializer.Serialize(request));
            try
            {

                User? user = _userService.GetById(request.Id);

                if (user is null)
                    throw new ApplicationErrorExceptions("No se encontro un usuario con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                _userService.Delete(user);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al eliminar el usuario.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }



    }
}
