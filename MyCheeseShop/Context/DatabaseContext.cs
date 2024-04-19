using MyCheeseShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyCheeseShop.Context
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        private IWebHostEnvironment _environment;
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IWebHostEnvironment enviornment) : base(options)
        {
            _environment = enviornment;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var folder = Path.Combine(_environment.WebRootPath, "database");
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

         
            optionbuilder.UseSqlite($"Data Source={folder}/cheese.db");
        }
    }
}
