using RestSharp;
using System;

namespace NGeoIP.Client
{
    public abstract class BaseNGeoClient
    {
        private readonly string baseURI = "http://freegeoip.net/";

        private readonly Request _request;

        private readonly RestClient _restClient;

        private readonly RestRequest _restRequest;

        public BaseNGeoClient(Request request)
        {
            _request = request;
            _restClient = new RestClient(BaseURI);
            _restRequest = new RestRequest(ResoureURI);
        }

        protected string BaseURI
        {
            get
            {
                return baseURI;
            }
        }

        protected string ResoureURI
        {
            get
            {
                return string.Format("{0}/{1}", _request.Format.ToString().ToLower(), (_request.IP ?? _request.HostName));
            }
        }

        public virtual RawData Execute()
        {
            IRestResponse<RawData> response = _restClient.Execute<RawData>(_restRequest);

            if (response.ErrorException != null)
            {
                throw new Exception("Error retrieving response, Check inner details for more info.", response.ErrorException);
            }

            return response.Data;
        }
    }
}