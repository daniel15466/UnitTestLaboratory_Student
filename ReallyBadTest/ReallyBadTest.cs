using System;
using CUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReallyBadTest
{
    [TestClass]
    public class ReallyBadTest
    {
        // Tutaj umieścić rozwiązanie zad. 4

        // Zad. 4.	Klasa ReallyBad posiada dwie metody FirstIndexOf(string source, char c) oraz LastIndexOf(string source, char c). 
        // Zadanie metod polega na znalezieniu pozycji pierwszego(ostatniego) wystąpienia znaku c w łańcuchu source. 
        // Obydwie metody posiadają wady. Stosując podejście czarnej skrzynki (tj.bez zaglądania do kodu), 
        // przygotować testy, które ujawniają wady.Szczegółowa specyfikacja metod znajduje się w klasie ReallyBadTest.


        /// Metoda LastIndexOf z klasy ReallyBad zwraca pozycję ostatniego wystąpienia znaku c w łańcuchu source
        /// Pozycja jest liczona od 0
        /// Dla znaków nie występujacych w łańcuchu source metoda zwraca -1
        /// Dla łańcucha pustego metoda metoda zwraca -1
        /// Dla łańcucha null metoda zwraca wyjątek ArgumentNullException


        /// Metoda FirstIndexOf z klasy ReallyBad zwraca pierwszego wystąpienia znaku c w łańcuchu source
        /// Pozycja jest liczona od 0
        /// Dla znaków nie występujacych w łańcuchu source metoda zwraca -1
        /// Dla łańcucha pustego metoda metoda zwraca -1
        /// Dla łańcucha null metoda zwraca wyjątek ArgumentNullException

        [TestMethod]


        
        public void ReallyBad_LastIndexOf_Test_Standard()
        {
            string source = "auto";
            char c = 'u';

            int expected = 1;
           

            ReallyBad cut = new ReallyBad();

            int pos = cut.LastIndexOf(source, c);
            Assert.AreEqual<int>(expected, pos);

        }
        [TestMethod]
        public void ReallyBad_FirstIndexOf_Test_Standard()
        {
            string source = "auto";
            char c = 'u';

            int expected = 1;

            ReallyBad cut = new ReallyBad();

            int pos = cut.FirstIndexOf(source, c);
            Assert.AreEqual<int>(expected, pos);

        }


        [DataRow("Kajak", "k", 3)] //Duża litera // ujawnia wade niemoznosci zastosowania duzych liter
        [DataRow("dom", 'd', 0)] //standardowy test
        [DataRow("dodo", 'd', 2)] //powtorzenia  // ujawnia wade, zwraca pierwsza zamiast ostatniej
        [DataRow("moje auto", ' ', 4)] //spacja
        [DataRow("akakakakaka", 'a', 10)] //wiele powtorzen
        [DataRow(null, 'c', null)] //null
        [DataRow("", 'c', null)] //null //ujawnia wade, dla pustego stringa zwraca -1
        [DataRow("dom", 'c', null)] // ujawnia wade, gdy nie wystepuje dany char w stringu zwraca -1 
        [DataTestMethod]
        public void ReallyBad_LastIndexOf_Test_Datatest(string sentence, char c, int expected)
        {
            try
            {
                ReallyBad cut = new ReallyBad();
                int actual = cut.LastIndexOf(sentence, c);
                Assert.AreEqual<int>(expected, actual);
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }

        [DataRow("Kajak", "k", 3)] //Duża litera // ujawnia wade niemoznosci zastosowania duzych liter
        [DataRow("dom", 'd', 0)] //standardowy test
        [DataRow("dodo", 'd', 2)] //powtorzenia  
        [DataRow("moje auto", ' ', 4)] //spacja
        [DataRow("akakakakaka", 'a', 10)] //wiele powtorzen
        [DataRow(null, 'c', null)] //null
        [DataRow("", 'c', null)] //null 
        [DataRow("dom", 'c', null)] // 
        [DataTestMethod]
        public void ReallyBad_FirstIndexOf_Test_Datatest(string sentence, char c, int expected)
        {
            try
            {
                ReallyBad cut = new ReallyBad();
                int actual = cut.LastIndexOf(sentence, c);
                Assert.AreEqual<int>(expected, actual);
            }
            catch(Exception)
            {
                return;
            }
        }

    }
}

