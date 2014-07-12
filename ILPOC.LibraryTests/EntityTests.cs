using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ILPOC.Library;
using System.Linq;
using System.Collections.Generic;

namespace ILPOC.LibraryTests
{
    [TestClass]
    public class EntityTests
    {
        [TestInitialize]
        public void Init()
        {
            using (var context = new MyContext())
            {
                context.Twos.RemoveRange(context.Twos.Select(x => x));
                context.Ones.RemoveRange(context.Ones.Select(x => x));

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void WriteEntities()
        {
            using (var context = new MyContext())
            {
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

            List<EntityTwo> actual;
            using (var context = new MyContext())
            {
                actual = context.Twos
                    .Include("Ones")
                    .Select(x => x)
                    .ToList();
            }

            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(2, actual[0].Ones.Count);
            Assert.AreEqual("Thingy", actual[1].Name);
            Assert.AreEqual("Balls", actual[0].Ones[1].Name);
        }
    }
}
