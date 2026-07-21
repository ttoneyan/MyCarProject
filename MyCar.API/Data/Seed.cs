using Microsoft.AspNetCore.Identity;
using MyCar.API.Models;
using MyCar.API.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace MyCar.API.Data;

public static class Seed
{
    public static async Task SeedDataAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new ApplicationRole { Name = "User" });
        }
        if (!await roleManager.RoleExistsAsync("Dealer"))
        {
            await roleManager.CreateAsync(new ApplicationRole { Name = "Dealer" });
        }

        var admin = await userManager.FindByEmailAsync("admin@test.com");

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                FirstName = "System",
                LastName = "Admin",
                Salary = 0
            };

            var result = await userManager.CreateAsync(admin, "Admin123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}