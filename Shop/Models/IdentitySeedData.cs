using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Shop.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async Task EnsurePopulated (UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var Admin = new IdentityRole("Admin");
            await roleManager.CreateAsync(Admin);
        }
    }
}
