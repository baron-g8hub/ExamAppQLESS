namespace Common.Contracts
{
    public interface IRoleRepository : IRepositoryBase<ApplicationRole>
    {
        ICollection<ApplicationRole> GetRoles();
    }
}
