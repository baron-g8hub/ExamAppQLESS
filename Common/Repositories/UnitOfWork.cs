using Common.Contracts;
using Common.DataAccess;

namespace Common.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _repoContext;
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
      //  public ITransportCardRepository TransportCard { get; }

        public UnitOfWork(ApplicationDbContext context, IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
            // TransportCard = travelCard;    
            _repoContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task SaveAsync()
        {
         await _repoContext.SaveChangesAsync();   
        }

        public Task<int> SaveAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
