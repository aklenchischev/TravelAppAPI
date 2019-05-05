namespace TravelAppAPI.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public int PlaceId { get; set; }


        public User User { get; set; }

        public Place Place { get; set; }
    }
}
