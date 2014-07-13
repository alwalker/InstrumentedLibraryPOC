using ILPOC.Library;
using ILPOC.Web;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ILPOC
{
    public class Facade
    {
        private static Controller _controller = new Controller();

        public static void Init()
        {
            _controller.Init();

            new Thread(new ThreadStart(() =>
            {
                var config = new HostConfiguration();
                config.UrlReservations = new UrlReservations() { CreateAutomatically = true };
                using (var host = new NancyHost(config, new Uri("http://localhost:9000")))
                {
                    host.Start();
                    while (true) Thread.Sleep(10000000);
                }
            })).Start();
        }

        public static IList<EntityOne> GetOnesForTwo(string twoName)
        {
            return _controller.GetOnesForTwo(twoName);
        }
    }
}
