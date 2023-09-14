using OKR.Common.Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User? GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User? GetByUserName(string username);
    }
}