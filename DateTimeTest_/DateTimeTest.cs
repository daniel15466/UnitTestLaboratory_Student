using Microsoft.VisualStudio.TestTools.UnitTesting;
using CUT;

using System;

namespace DateTimeTest_
{


    //              Klasy równoważnosci
    //  miesiace w zakresie 1-12
    // miesiac poza zakresem <0, 12<
    // luty w latach przestepnych
    // luty w latach zwyklych
    // zwykle miesiace w lata zwyklych
    // zwykle miesiace w latach przestepnych
    // argumenty nieprawidłowe
    // rok 0 i poniżej 0
    [TestClass]
    public class DateTimeTest
    {


        [DataRow(2021,12,31)]
        [DataRow(2021, 1, 31)]
        [DataRow(2021, 13, 0)]
        [DataRow(2021, 0, 0)]
        [DataRow(2021, 2, 28)]
        [DataRow(2020, 2, 29)]
        [DataRow(2020, 3, 31)]
        [DataRow(2021, 3, 31)]
        [DataRow(null, 2, null)]
        [DataRow(null, null, null)]
        [DataRow(2021, null, null)]
        [DataRow("2021", "2", null)]//prawidlowo wyrzuca wyjatek
        [DataRow(2021.2, 2, null)] // prawidlowo wyrzuca wyjatek
        [DataRow(0, 12, 31)]
        [DataRow(-5, 12, 31)]
        [DataRow(0, 12, 30)] //nie dziala
        [DataRow(-5, 12, 30)] // nie dziala
        [DataRow(1, 12, 30)] //sprawdza assert
        [DataRow(1, 12, 31)] //prawidlowo wykrywa powyzej 0 roku
        [DataTestMethod]
        public void DaysInMonthTest(int year, int month, int expected)
        {


            int actual;

            try
            {
                 actual = DateTime.DaysInMonth(year, month);
                 

            }
            catch(Exception)
            {
                return;
            }

            Assert.AreEqual(actual, expected);


        }
    }
}
