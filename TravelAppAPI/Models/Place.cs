namespace TravelAppAPI.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }
        
        public double Longtitude { get; set; }

        public string Address { get; set; }
    }
}
