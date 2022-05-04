using Microsoft.AspNetCore.Identity;

namespace Common
{
    public class ApplicationRole : IdentityRole
    {
        public int? RoleLevel { get; set; }
    }

}
