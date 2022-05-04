using Common.Contracts;
using Common;


namespace Common.Repositories
{
    public class RoleRepository : RepositoryBase<ApplicationRole>, IRoleRepository
    {

        public RoleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ICollection<ApplicationRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
