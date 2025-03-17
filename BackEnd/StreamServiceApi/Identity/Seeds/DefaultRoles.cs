using Application.ENUMs;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Llenado de roles
            var roleAdministrator = await roleManager.FindByNameAsync(Roles.Administrator.ToString());
            if (roleAdministrator == null)
                await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));

            var roleBasic = await roleManager.FindByNameAsync(Roles.Customer.ToString());
            if (roleBasic == null)
                await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));

           
        }
    }
}
