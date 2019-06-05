namespace TravelAppAPI.Models
{
    public class Favourite
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
    }
}
