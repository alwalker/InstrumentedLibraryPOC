using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC.Library
{
    public class EntityTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<EntityOne> Ones { get; set; }
    }
}
