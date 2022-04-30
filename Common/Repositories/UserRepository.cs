using Common.Contracts;
using Common.DataAccess;

namespace Common.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public ApplicationUser GetUser(string id)
        {
            if (_context != null)
            {
                if (_context.Users.Any(x => x.Id == id))
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id == id);
                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            return new ApplicationUser();
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
