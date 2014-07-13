using ILPOC.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC
{
    public class Facade
    {
        private static Controller _controller = new Controller();

        public static IList<EntityOne> GetOnesForTwo(string twoName)
        {
            return _controller.GetOnesForTwo(twoName);
        }
    }
}
