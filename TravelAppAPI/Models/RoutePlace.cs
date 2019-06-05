using System.Collections.Generic;

namespace TravelAppAPI.Models
{
    public class RoutePlace
    {
        public int RouteId { get; set; }

        public Route Route { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
