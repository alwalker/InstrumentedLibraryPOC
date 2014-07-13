using ILPOC.Library;
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

            while (true)
            {
                Console.WriteLine("What would you like to do?\n1. Get ones for twos\n2. Get all twos\n3. Add two");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Name of two: ");
                        var ones = Facade.GetOnesForTwo(Console.ReadLine());
                        Console.WriteLine("Ones");
                        foreach (var one in ones)
                        {
                            Console.WriteLine("\tId: " + one.Id + "\tName: " + one.Name);
                        }
                        break;
                    case "2":
                        var twos = Facade.GetTwos();
                        Console.WriteLine("Twos:");
                        foreach (var two in twos)
                        {
                            Console.WriteLine("\tId: " + two.Id +"\tName: " + two.Name);
                        }
                        break;
                    case "3":
                        Console.WriteLine("New Name: ");
                        Facade.AddTwo(new EntityTwo() { Name = Console.ReadLine() });
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}
