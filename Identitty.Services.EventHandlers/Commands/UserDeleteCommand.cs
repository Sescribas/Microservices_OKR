using MediatR;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identitty.Services.EventHandlers.Commands
{
    public class UserDeleteCommand : IRequest<BaseResult<string>>
    {
        public UserDeleteCommand(int userId) 
        {
            Id = userId;
        }
        public int Id { get; set; }
    }
}
