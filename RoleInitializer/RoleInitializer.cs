using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.RoleInitializer
{
    public class RoleInitializer
    {

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "admin";
            string adminPassword = "qwert123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("Guest") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Guest"));
            }
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                User admin = new User { UserName = adminName };

                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
    
}
