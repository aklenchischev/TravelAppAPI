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

        public DbSet<RouteToPlace> RoutesToPlaces { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}
