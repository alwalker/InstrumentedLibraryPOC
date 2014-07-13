using ILPOC.Library;
using ILPOC.Web;
using Microsoft.Owin.Hosting;
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
                var url = "http://+:8080";

                using (WebApp.Start<Startup>(url))
                {
                    for (; ; ) { }
                }
            })).Start();
        }

        public static IList<EntityOne> GetOnesForTwo(string twoName)
        {
            return _controller.GetOnesForTwo(twoName);
        }
    }
}
