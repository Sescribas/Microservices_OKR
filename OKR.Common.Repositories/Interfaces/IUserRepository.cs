using Domain;

namespace OKR.Common.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}