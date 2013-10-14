using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace NGeoIP.Test
{
    public static class HelperTest
    {
        public static string GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress localIP = host.AddressList.SingleOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);

            if (!string.IsNullOrWhiteSpace(localIP.ToString()))
            {
                //return localIP.ToString();
            }

            return "187.22.197.94"; //string.Empty;
        }
    }
}