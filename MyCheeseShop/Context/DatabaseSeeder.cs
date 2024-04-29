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

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }

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

             

            }
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
            new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 5.99m, ImageUrl="cheddar.png" },
            new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price = 7.49m, ImageUrl="brie.png" },
            new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "Smooth and nutty", Strength = "Medium", Price = 6.99m, ImageUrl="gouda.png" },
            new Cheese { Name = "Swiss", Type = "Hard", Description = "Nutty and sweet", Strength = "Mild", Price = 8.99m, ImageUrl="swiss.png" },
            new Cheese { Name = "Blue Cheese", Type = "Blue", Description = "Sharp and tangy with blue mold veins", Strength = "Strong", Price = 9.99m, ImageUrl="blue.png" },
            new Cheese { Name = "Parmesan", Type = "Hard", Description = "Sharp and salty", Strength = "Strong", Price = 10.99m, ImageUrl="parmesan.png" },
            new Cheese { Name = "Camembert", Type = "Soft", Description = "Buttery and earthy", Strength = "Medium", Price = 11.49m, ImageUrl="camembert.png" },
            new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 4.99m, ImageUrl="mozzarella.png" },
            new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 7.99m, ImageUrl="feta.png" },
            new Cheese { Name = "Roquefort", Type = "Blue", Description = "Intensely creamy and tangy", Strength = "Strong", Price = 12.99m, ImageUrl="pepperjack.png" },
            new Cheese { Name = "Emmental", Type = "Hard", Description = "Sweet and nutty with large holes", Strength = "Medium", Price = 8.49m, ImageUrl="emmental.png" },
            new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "Sharp and savory", Strength = "Medium", Price = 9.49m, ImageUrl="provolone.png" },
            new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "Smooth and buttery", Strength = "Mild", Price = 7.99m, ImageUrl="havarti.png" },
            new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and creamy with nutty flavor", Strength = "Medium", Price = 10.49m, ImageUrl="manchego.png" },
            new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "Mild and creamy", Strength = "Mild", Price = 6.49m, ImageUrl="colby.png" },
            new Cheese { Name = "Monterey Jack", Type = "Semi-Hard", Description = "Mild and creamy with slight tang", Strength = "Mild", Price = 6.99m, ImageUrl="monterey.png" },
            new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Sharp and pungent with blue mold veins", Strength = "Strong", Price = 10.99m, ImageUrl="gorgonzola.png" },
            new Cheese { Name = "Edam", Type = "Semi-Hard", Description = "Smooth and mild", Strength = "Mild", Price = 7.49m, ImageUrl="unicorn.png" },
            new Cheese { Name = "Fontina", Type = "Semi-Soft", Description = "Buttery and fruity", Strength = "Medium", Price = 9.99m, ImageUrl="goat.png" },
            new Cheese { Name = "Pepper Jack", Type = "Semi-Hard", Description = "Mild with spicy pepper flakes", Strength = "Medium", Price = 7.49m, ImageUrl="ricotta.png" }
            ];
        }
    }
}

