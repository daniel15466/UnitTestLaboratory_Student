using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CUT;

namespace DependencyTest
{
    // Przykłady z wykładów
    [TestClass]
    public class GreetingsTest
    {
        public class StubCustomerRepository : ICustomerRepository
        {
            public string GetNameById(long id)
            {
                return "Smith";
            }
        }

        [TestMethod]
        public void PrepareGreetingsSimple_Test()
        {
            var cut = new Grettings(new StubCustomerRepository());
            string expected = "Hello Smith";
            string actual = cut.PrepareGrettings(0);

            Assert.AreEqual(expected, actual);
        }
    }
}
