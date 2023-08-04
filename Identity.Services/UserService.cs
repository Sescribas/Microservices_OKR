using OKR.Common.Domain;
using OKR.Common.Services.Interfaces;
using OKR.Common.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OKR.Common.Services
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

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public bool VerifyByUserName(string username)
        {
            var users = _userRepository.GetUsers();

            return users.Any(x => x.UserName.ToLower() == username);
        }

        public bool VerifyByEmail(string email)
        {
            var users = _userRepository.GetUsers();

            return users.Any(x => x.Email.ToLower() == email);
        }
    }
}