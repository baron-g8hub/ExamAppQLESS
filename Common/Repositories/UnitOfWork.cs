using Common.Contracts;

namespace Common.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public ITravelCardRepository TravelCard { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role, ITravelCardRepository travelCard)
        {
            User = user;
            Role = role;
            TravelCard = travelCard;    
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
