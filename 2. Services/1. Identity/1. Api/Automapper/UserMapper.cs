using AutoMapper;
using Identitty.Services.EventHandlers.Commands;
using OKR.Common.api.Models.ViewModels;
using OKR.Common.Domain.Dtos.UserDto;

namespace Identity.api.Automapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserRegisterViewModel, UserCreateCommand>();

            CreateMap<UserRegisterViewModel, UserAuthResponseDto>();
            CreateMap<UserLoginResponseDto, UserLoginResponseDto>();

        }
    }
}
