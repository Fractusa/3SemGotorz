using Gotorz.Models;
using Microsoft.EntityFrameworkCore;

namespace Gotorz.Data
{
    public class TravelPackageDbContext : DbContext
    {
        public TravelPackageDbContext(DbContextOptions<TravelPackageDbContext> options) : base(options) { }

        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<FlightData> FlightData { get; set; }
        public DbSet<HotelData> HotelData { get; set; }
    }
}
