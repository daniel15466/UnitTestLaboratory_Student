using System;
using CUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberHelperTest
{
    // przykłady z wykładów
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void DaysToEvent_OriginalCode_Today_Test()
        {
            DateTime eventDate = new DateTime(2014, 11, 1);
            string expected = "Today";
            var cut = new Utils();
            string actual = cut.DaysToEvent(eventDate);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void DaysToEvent_Refactored_Today_Test()
        {
            DateTime now = new DateTime(2014, 11, 1);
            DateTime eventDate = new DateTime(2014, 11, 1);
            string expected = "Today";
            var cut = new Utils();
            string actual = cut.DaysToEvent_Refactored(now, eventDate);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void DaysToEvent_Refactored_Tomorrow_Test()
        {
            DateTime now = new DateTime(2014, 11, 1);
            DateTime eventDate = new DateTime(2014, 11, 2);
            string expected = "Tommorow";
            var cut = new Utils();
            string actual = cut.DaysToEvent_Refactored(now, eventDate);

            Assert.AreEqual<string>(expected, actual);
        }

        [TestMethod]
        public void DaysToEvent_Refactored_5Days_Test()
        {
            DateTime now = new DateTime(2014, 11, 1);
            DateTime eventDate = new DateTime(2014, 11, 6);
            string expected = "In 5 days";
            var cut = new Utils();
            string actual = cut.DaysToEvent_Refactored(now, eventDate);

            Assert.AreEqual<string>(expected, actual);
        }




    }
}
