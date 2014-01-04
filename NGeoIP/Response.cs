
namespace NGeoIP
{
    public class Response
    {
        public Response()
        {
            Address = new Domain.Address();
        }

        public string IP { get; set; }

        public Domain.Address Address { get; set; }
    }
}