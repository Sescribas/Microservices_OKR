using OKR.Common.Domain;

namespace OKR.Common.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetById(int id);
        User? GetByUserName(string username);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        bool VerifyByUserName(string username);
        bool VerifyByEmail(string email);
    }
}