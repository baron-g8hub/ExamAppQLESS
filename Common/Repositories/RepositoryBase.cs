using Common.Contracts;
using Common.DataAccess;

namespace Common.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        public RepositoryBase(ApplicationDbContext applicationDBContext )
        {
            _context = applicationDBContext;
        }
    }
}
