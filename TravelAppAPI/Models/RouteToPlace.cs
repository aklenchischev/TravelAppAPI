namespace TravelAppAPI.Models
{
    public class RouteToPlace
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int PlaceId { get; set; }

        public int PlaceOrder { get; set; }


        public Route Route { get; set; }

        public Place Place { get; set; }
    }
}
