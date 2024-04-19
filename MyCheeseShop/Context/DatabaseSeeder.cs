using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
  
    public class DatabaseSeeder
    {

        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customers"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    Postcode = "AD12 MIN",
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");

                if(!_context.Cheeses.Any())
                {
                    var cheeses = GetCheeses();
                    _context.Cheeses.AddRange(cheeses);
                    await _context!.SaveChangesAsync();
                }

            }
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
            new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 5.99m },
            new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price = 7.49m },
            new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "Smooth and nutty", Strength = "Medium", Price = 6.99m },
            new Cheese { Name = "Swiss", Type = "Hard", Description = "Nutty and sweet", Strength = "Mild", Price = 8.99m },
            new Cheese { Name = "Blue Cheese", Type = "Blue", Description = "Sharp and tangy with blue mold veins", Strength = "Strong", Price = 9.99m },
            new Cheese { Name = "Parmesan", Type = "Hard", Description = "Sharp and salty", Strength = "Strong", Price = 10.99m },
            new Cheese { Name = "Camembert", Type = "Soft", Description = "Buttery and earthy", Strength = "Medium", Price = 11.49m },
            new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 4.99m },
            new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 7.99m },
            new Cheese { Name = "Roquefort", Type = "Blue", Description = "Intensely creamy and tangy", Strength = "Strong", Price = 12.99m },
            new Cheese { Name = "Emmental", Type = "Hard", Description = "Sweet and nutty with large holes", Strength = "Medium", Price = 8.49m },
            new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "Sharp and savory", Strength = "Medium", Price = 9.49m },
            new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "Smooth and buttery", Strength = "Mild", Price = 7.99m },
            new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and creamy with nutty flavor", Strength = "Medium", Price = 10.49m },
            new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "Mild and creamy", Strength = "Mild", Price = 6.49m },
            new Cheese { Name = "Monterey Jack", Type = "Semi-Hard", Description = "Mild and creamy with slight tang", Strength = "Mild", Price = 6.99m },
            new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Sharp and pungent with blue mold veins", Strength = "Strong", Price = 10.99m },
            new Cheese { Name = "Edam", Type = "Semi-Hard", Description = "Smooth and mild", Strength = "Mild", Price = 7.49m },
            new Cheese { Name = "Fontina", Type = "Semi-Soft", Description = "Buttery and fruity", Strength = "Medium", Price = 9.99m },
            new Cheese { Name = "Pepper Jack", Type = "Semi-Hard", Description = "Mild with spicy pepper flakes", Strength = "Medium", Price = 7.49m }
            ];
        }
    }
}

