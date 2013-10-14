
namespace NGeoIP.Domain
{
    public class Address
    {
        public Country Country { get; set; }

        public Region Region { get; set; }

        public City City { get; set; }

        public string Zipcode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string MetroCode { get; set; }

        public string AreaCode { get; set; }
    }
}