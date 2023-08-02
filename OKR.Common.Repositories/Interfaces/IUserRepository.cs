using OKR.Common.Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User? GetById(int id);
        void Create(User user);
        void Update(User user);
        bool VerifyByUserName(string username);
        bool VerifyByEmail(string email);
        void Delete(User user);
    }
}