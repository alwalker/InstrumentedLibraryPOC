using Newtonsoft.Json;
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
                return JsonConvert.SerializeObject(Facade.GetOnesForTwo(_.name)); 
            };
        }
    }
}
