using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ILPOC.Library;
using System.Collections.Generic;

namespace ILPOC.LibraryTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestInitialize]
        public void Init()
        {
            using (var context = new MyContext())
            {
                context.Twos.RemoveRange(context.Twos.Select(x => x));
                context.Ones.RemoveRange(context.Ones.Select(x => x));

                context.SaveChanges();

                var ones = new List<EntityOne> {
                    new EntityOne {Id = 1, Name = "Test" },
                    new EntityOne {Id = 2, Name= "Balls"}
                };

                var twos = new List<EntityTwo> {
                    new EntityTwo {Id = 1, Name = "Test", Ones = ones},
                    new EntityTwo {Id = 2, Name = "Thingy", Ones = null}
                };

                context.Twos.AddRange(twos);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestGetOnesForTwo()
        {
            var controller = new Controller();
            controller.Init();

            var actual = controller.GetOnesForTwo("Test");

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("Balls", actual[1].Name);
        }
    }
}
