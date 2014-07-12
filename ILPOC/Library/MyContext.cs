using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC.Library
{
    public class MyContext : DbContext
    {
        public DbSet<EntityOne> Ones { get; set; }
        public DbSet<EntityTwo> Twos { get; set; }
    }
}
