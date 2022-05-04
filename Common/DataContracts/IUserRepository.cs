namespace Common.Contracts
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser>
    {
        ICollection<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
