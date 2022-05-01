namespace Common.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        //ITransportCardRepository TransportCard { get; }

        Task SaveAsync();
        Task<int> SaveAsync(CancellationToken ct);
    }
}
