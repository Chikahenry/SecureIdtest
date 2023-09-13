using Microsoft.AspNetCore.Identity;
using RolebaseAuthorization.Entities;

namespace RolebaseAuthorization.Services
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            await CreateRole(roleManager, RoleConstants.Admin);
            await CreateRole(roleManager, RoleConstants.User);
        }

        private static async Task CreateRole(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
