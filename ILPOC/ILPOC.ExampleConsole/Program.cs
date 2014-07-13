using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILPOC.ExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            Facade.Init();

            Console.WriteLine("Started");
            Console.Read();
        }
    }
}
