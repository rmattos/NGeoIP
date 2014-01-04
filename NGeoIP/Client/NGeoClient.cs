using AutoMapper;

namespace NGeoIP.Client
{
    public class NGeoClient : BaseNGeoClient
    {
        public NGeoClient(Request request)
            : base(request)
        {
        }

        public Response MapResponse(RawData source)
        {
            Mapper.CreateMap<RawData, Response>()
                .ForMember(dest => dest.IP, src => src.MapFrom(opt => opt.Ip))
                .ForMember(dest => dest.Address, src => src.ResolveUsing<AddressCustomerResolver>());

            Mapper.AssertConfigurationIsValid();

            return Mapper.Map<RawData, Response>(source);
        }

        #region [ CUSTOMER RESOLVER ]

        public class AddressCustomerResolver : ValueResolver<RawData, Domain.Address>
        {
            protected override Domain.Address ResolveCore(RawData source)
            {
                return new Domain.Address()
                {
                    AreaCode = source.AreaCode,
                    City = new Domain.City()
                    {
                        Name = source.City
                    },
                    Country = new Domain.Country()
                    {
                        Code = source.CountryCode,
                        Name = source.CountryName
                    },
                    Latitude = source.Latitude,
                    Longitude = source.Longitude,
                    MetroCode = source.MetroCode,
                    Region = new Domain.Region()
                    {
                        Code = source.RegionCode,
                        Name = source.RegionName
                    },
                    Zipcode = source.ZipCode
                };
            }
        }

        #endregion
    }
}