

using Microsoft.AspNetCore.Identity;

namespace Common
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserUID { get; set; }
        public string BranchCode { get; set; } = "MAIN";
        
    }
}


