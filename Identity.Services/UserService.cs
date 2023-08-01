using Domain;
using Identity.Services.Interfaces;
using OKR.Common.Repositories.Interfaces;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users;
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }
    }
}