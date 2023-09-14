using OKR.Common.Domain;
using OKR.Common.Persistence.Database.IdentityDbContext;
using OKR.Common.Repositories.Interfaces;

namespace OKR.Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDBContext _context;


        public UserRepository(IdentityDBContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }       

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User? GetByUserName(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }
    }
}