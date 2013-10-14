using FluentAssertions;
using Xunit;

namespace NGeoIP.Test
{
    public class GeoClientTest
    {
        protected readonly BaseGeoClient geoClient;
        protected readonly Request geoRequest;

        public GeoClientTest()
        {
            geoRequest = new Request()
            {
                Format = Format.Json,
                IP = HelperTest.GetLocalIP()
            };

            geoClient = new GeoClient(geoRequest);
        }

        public class Execute : GeoClientTest
        {
            private Response _response;

            public Execute()
            {
                _response = geoClient.Execute();
            }

            [Fact]
            public void Should_Not_Return_Null()
            {
                _response.Should().NotBeNull();
            }

            [Fact]
            public void Response_IP_Should_Not_Be_Empty()
            {
                _response.IP.Should().NotBeEmpty();
            }
        }
    }
}