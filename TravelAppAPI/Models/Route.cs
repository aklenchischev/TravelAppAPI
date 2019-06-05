using System.Collections.Generic;

namespace TravelAppAPI.Models
{
    public class Route
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<RoutePlace> RoutePlaces { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
