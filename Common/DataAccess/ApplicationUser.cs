using Microsoft.AspNetCore.Identity;

namespace Common.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string? Username { get; set; }
        public string? UserUID { get; set; }
        public string BranchCode { get; set; } = "MAIN";
        
    }
}



public class ApplicationRole : IdentityRole
{

}
