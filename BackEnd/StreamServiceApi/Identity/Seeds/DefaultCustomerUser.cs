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
    public static class DefaultCustomerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userCustomer, RoleManager<IdentityRole> roleCustomer)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "userCustomer",
                Email = "Customer@gmail.com",
                FirstName = "FirstName Customer",
                Lastname = "LastName Customer",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userCustomer.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userCustomer.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userCustomer.CreateAsync(defaultUser, "P4$$w0rd");
                    await userCustomer.AddToRoleAsync(defaultUser, Roles.Customer.ToString());
                }
            }
        }

    }
}
