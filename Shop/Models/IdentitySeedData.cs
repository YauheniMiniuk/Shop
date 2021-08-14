using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Shop.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Administrator";
        private const string adminPassword = "Secret123$";
        public static async Task EnsurePopulated (UserManager<User> userManager)
        {
            User user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new User("Administrator");
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
