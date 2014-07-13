using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC.Web
{
    public class MainModule: Nancy.NancyModule
    {
        public MainModule()
        {
            Get["/GetOnesForTwo/{name}"] = _ => {
                //return Facade.GetOnesForTwo(_.name); 
                return "HAI " + _.name + "!!!";
            };
        }
    }
}
