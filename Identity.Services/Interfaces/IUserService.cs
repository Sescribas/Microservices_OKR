using OKR.Common.Domain;

namespace OKR.Common.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetById(int id);
        void Create(User user);
        void Update(User user);
        bool VerifyUserName(string v);
        bool VerifyEmail(string v);
        void Delete(User user);
    }
}