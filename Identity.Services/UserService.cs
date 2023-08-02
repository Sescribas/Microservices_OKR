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

        public User? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user;
        }

        public void Create(User user)
        {
           _userRepository.Create(user);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public bool VerifyUserName(string userName)
        {
            return _userRepository.VerifyByUserName(userName);
        }

        public bool VerifyEmail(string email)
        {
            return _userRepository.VerifyByEmail(email);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }
    }
}