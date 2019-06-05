using System.Collections.Generic;

namespace TravelAppAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Route> Routes { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
