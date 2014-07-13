using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC.Library
{
    public class Controller
    {
        private List<EntityTwo> _twos;

        public bool Init()
        {
            using (var db = new MyContext())
            {
                _twos = db
                    .Twos
                    .Include("Ones")
                    .Select(x => x)
                    .ToList();
            }

            return true;
        }

        public IList<EntityOne> GetOnesForTwo(string twoName)
        {
            foreach (var two in _twos)
            {
                if (two.Name == twoName)
                {
                    return two.Ones;
                }
            }

            return null;
        }

        public void AddTwo(EntityTwo two)
        {
            using (var context = new MyContext()) {
                context.Twos.Add(two);
                context.SaveChanges();
            }
            _twos.Add(two);
        }

        public List<EntityTwo> GetTwos()
        {
            return _twos;
        }
    }
}
