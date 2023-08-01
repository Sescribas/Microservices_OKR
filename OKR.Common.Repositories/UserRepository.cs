using Data;
using Domain;
using OKR.Common.Repositories.Interfaces;

namespace OKR.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;


        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }
    }
}