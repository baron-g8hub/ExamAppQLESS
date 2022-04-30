namespace Common.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        ITravelCardRepository TravelCard { get; }

        Task SaveAsync();
        Task<int> SaveAsync(CancellationToken ct);
    }
}
