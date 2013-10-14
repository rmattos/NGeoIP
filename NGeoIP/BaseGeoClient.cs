
namespace NGeoIP
{
    public abstract class BaseGeoClient
    {
        private readonly Request _request;

        private readonly string baseURI = "http://freegeoip.net/";

        public BaseGeoClient(Request req)
        {
            _request = req;
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

        public abstract Response Execute();
    }
}