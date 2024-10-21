using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Create roles if they do not exist
            string[] roleNames = { "Farmer", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Ensure roles are created before users are added
            await context.SaveChangesAsync();

            if (!context.Users.Any())
            {
                var farmerUser = new ApplicationUser { UserName = "farmer@example.com", Email = "farmer@example.com" };
                await userManager.CreateAsync(farmerUser, "Farmer@123");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");

                var admin = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com" };
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Employee");

                // Ensure users are created and roles are assigned before adding related entities
                await context.SaveChangesAsync();

                // Now add related entities
                var farmer = new Farmer
                {
                    Name = "John Doe",
                    ContactInfo = "farmer@example.com",
                    UserId = farmerUser.Id,
                    Products = new List<Product>
                    {
                        new Product { Name = "Corn", Category = "Vegetable", ProductionDate = DateTime.Now }
                    }
                };

                context.Farmers.Add(farmer);
                await context.SaveChangesAsync();
            }
        }
    }
}
