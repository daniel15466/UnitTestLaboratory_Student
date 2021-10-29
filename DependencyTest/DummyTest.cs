using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CUT;

namespace DependencyTest
{
    // Przykłady z wykładów
    [TestClass]
    public class InvoiceTest
    {
        public class DummyItem : IItem
        {
            public double GetQuantity()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void TheNumberOfDummyItems_Test()
        {
            // test Count property
            var cut = new Invoice();
            cut.Add(new DummyItem());
            cut.Add(new DummyItem());

            Assert.AreEqual(cut.GetCount(), 2);
        }

        [TestMethod]
        public void TheNumberOfRealItems_Test()
        {
            // test Count property
            Money m1 = new Money(10);
            Money m2 = new Money(20);
            Product p1 = new Product("a", m1);
            Product p2 = new Product("b", m2);

            var cut = new Invoice();
            cut.Add(new Item(p1, 100));
            cut.Add(new Item(p2, 200));

            Assert.AreEqual(cut.GetCount(), 2);
        }

    }

}
