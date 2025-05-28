using Gotorz.Models;
using Microsoft.EntityFrameworkCore;

namespace Gotorz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<TravelPackageTemplate> TravelPackageTemplates { get; set; }

    }
}
