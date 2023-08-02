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
        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool VerifyByUserName(string username)
        {
            return _context.Users.Any(x => x.UserName.ToLower() == username);
        }

        public bool VerifyByEmail(string email)
        {
            return _context.Users.Any(x => x.Email.ToLower() == email);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}