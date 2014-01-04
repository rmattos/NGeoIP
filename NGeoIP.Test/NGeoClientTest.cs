using FluentAssertions;
using NGeoIP.Client;
using Xunit;

namespace NGeoIP.Test
{
    public class NGeoClientTest
    {
        protected readonly NGeoClient nGeoClient;
        protected readonly Request nGeoRequest;
        protected readonly RawData rawData;

        public NGeoClientTest()
        {
            nGeoRequest = new Request()
            {
                Format = Format.Json,
                IP = HelperTest.GetLocalIP()
            };

            nGeoClient = new NGeoClient(nGeoRequest);

            rawData = nGeoClient.Execute();
        }

        public class Execute : NGeoClientTest
        {
            [Fact]
            public void Should_Not_Return_Null()
            {
                rawData.Should().NotBeNull();
            }

            [Fact]
            public void Response_IP_Should_Not_Be_Empty()
            {
                rawData.Ip.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_IP_Should_Equals_N_Geo_Request_IP()
            {
                rawData.Ip.Should().Be(nGeoRequest.IP);
            }

            [Fact]
            public void Response_Latitude_Should_Not_Be_Empty()
            {
                rawData.Latitude.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Longitude_Should_Not_Be_Empty()
            {
                rawData.Longitude.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Country_Name_Should_Not_Be_Empty()
            {
                rawData.CountryName.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Region_Name_Should_Not_Be_Empty()
            {
                rawData.RegionName.Should().NotBeEmpty();
            }
        }

        public class MapResponse : NGeoClientTest
        {
            private Response response;

            public MapResponse()
            {
                response = nGeoClient.MapResponse(rawData);
            }

            [Fact]
            public void Should_Be_A_Response_Type()
            {
                response.Should().BeOfType<Response>();
            }

            [Fact]
            public void Should_Not_Return_Null()
            {
                response.Should().NotBeNull();
            }

            [Fact]
            public void Response_IP_Should_Not_Be_Empty()
            {
                response.IP.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_IP_Should_Equals_N_Geo_Request_IP()
            {
                response.IP.Should().Be(nGeoRequest.IP);
            }

            [Fact]
            public void Response_Address_Latitude_Should_Not_Be_Empty()
            {
                response.Address.Latitude.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Address_Longitude_Should_Not_Be_Empty()
            {
                response.Address.Longitude.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Address_Country_Name_Should_Not_Be_Empty()
            {
                response.Address.Country.Name.Should().NotBeEmpty();
            }

            [Fact]
            public void Response_Address_Region_Name_Should_Not_Be_Empty()
            {
                response.Address.Region.Name.Should().NotBeEmpty();
            }
        }
    }
}