using Microsoft.EntityFrameworkCore;
using TravelAppAPI.Models;

namespace TravelAppAPI.Infrastructure
{
    public class TravelAppContext: DbContext
    {
        public TravelAppContext(DbContextOptions<TravelAppContext> options) : base(options)
        {
        }

        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<RoutePlace> RoutePlaces { get; set; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoutePlace>()
                .HasKey(rp => new { rp.RouteId, rp.PlaceId });
            modelBuilder.Entity<RoutePlace>()
                .HasOne(rp => rp.Route)
                .WithMany(r => r.RoutePlaces)
                .HasForeignKey(rp => rp.RouteId);
            modelBuilder.Entity<RoutePlace>()
                .HasOne(rp => rp.Place)
                .WithMany(p => p.RoutePlaces)
                .HasForeignKey(rp => rp.PlaceId);

            modelBuilder.Entity<Favourite>()
                .HasKey(f => new { f.UserId, f.RouteId });
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.Route)
                .WithMany(r => r.Favourites)
                .HasForeignKey(f => f.RouteId);
        }
    }
}
