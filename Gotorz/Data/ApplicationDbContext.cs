using Gotorz.Models;
using Microsoft.EntityFrameworkCore;

namespace Gotorz.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
