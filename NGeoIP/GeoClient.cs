using Newtonsoft.Json.Linq;
using RestSharp;

namespace NGeoIP
{
    public class GeoClient : BaseGeoClient
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public GeoClient(Request req)
            : base(req)
        {
            _client = new RestClient(BaseURI);
            _request = new RestRequest(ResoureURI);
        }

        public override Response Execute()
        {
            IRestResponse response = _client.Execute(_request);

            dynamic jObject = JObject.Parse(response.Content);

            return new Response()
            {
                IP = jObject.ip,
                Address = new Domain.Address()
                {
                    Country = new Domain.Country() { Code = jObject.country_code, Name = jObject.country_name },
                    Region = new Domain.Region() { Code = jObject.region_code, Name = jObject.region_name },
                    City = new Domain.City() { Name = jObject.city },
                    Zipcode = jObject.zipcode,
                    Latitude = jObject.latitude,
                    Longitude = jObject.longitude,
                    MetroCode = jObject.metro_code,
                    AreaCode = jObject.areacode
                }
            };
        }
    }
}