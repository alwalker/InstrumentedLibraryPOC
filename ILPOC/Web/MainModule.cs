using ILPOC.Library;
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
            Get["/GetTwos"] = _ =>
            {
                return JsonConvert.SerializeObject(Facade.GetTwos());
            };
            Post["/AddTwo/{name}"] = _ =>
            {
                Facade.AddTwo(new EntityTwo() { Name = _.name });
                return 200;
            };
        }
    }
}
