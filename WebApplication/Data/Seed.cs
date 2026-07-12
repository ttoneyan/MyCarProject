using WebApplication.Models;
using WebApplication.Models.Enums;

namespace WebApplication.Data;

public static class Seed
{
    public static void SeedData(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            var admin = new Users
            {
                Email = "admin@test.com",
                FirstName = "System",
                LastName = "Admin",
                UserPasswordHash = "admin123",
                Role = UserRole.Admin,
                Active = true,
                Salary = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}