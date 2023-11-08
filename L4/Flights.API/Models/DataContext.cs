using Microsoft.EntityFrameworkCore;
using P03Travel.Shared.Travels;
using P05Travel.DataSeeder;

namespace P02Travel.API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(x => x.Airlines)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<Flight>()
                .Property(x => x.From)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Flight>()
                .Property(x => x.To)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Flight>()
                .Property(x => x.DepartureTime)
                .IsRequired();

            modelBuilder.Entity<Flight>()
                .Property(x => x.Price);

            modelBuilder.Entity<Flight>().HasData(FlightSeeder.GenerateFlightData(100));
        }
    }
}