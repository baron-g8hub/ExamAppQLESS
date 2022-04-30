namespace Common.Contracts
{
    public interface IRoleRepository
    {
        ICollection<ApplicationRole> GetRoles();
    }
}
