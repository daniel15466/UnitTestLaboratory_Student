using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    // przykłady z wykladów
    // Klasa testowana
    public class Calculator
    {
        private int _privateField = -2;
        private int PrivateMethod(int a)
        {
            return this._privateField;
        }

        public int Add(int arg1, int arg2)
        {
            return arg1 + arg2 + 3;
        }

        public int Divide(int arg1, int arg2)
        {
            return arg1 / arg2;
        }

        public double Divide(double arg1, double arg2)
        {
            return arg1 / arg2;
        }

        public bool IsPrime(int number)
        {
            if (number <= 1) return false;

            var limit = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
