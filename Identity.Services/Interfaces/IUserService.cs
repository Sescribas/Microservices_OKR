using Domain;

namespace Identity.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}