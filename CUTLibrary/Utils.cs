using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    // przykłady z wykładów
    public class Utils
    {
        public int GetNumZero(int[] x)
        {
            int count = 0;
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// It is not testable method.
        /// The reason is time dependency
        /// </summary>
        /// <param name="eventDate"></param>
        /// <returns></returns>
        public string DaysToEvent(DateTime eventDate)
        {
            TimeSpan span = eventDate - DateTime.Now;
            switch (span.Days)
            {
                case 0:
                    return "Today";
                case 1:
                    return "Tommorow";
                default:
                    return "In " + span.Days + " days";
            }
        }

        /// <summary>
        /// After removing time dependency this method is testable
        /// </summary>
        /// <param name="now"></param>
        /// <param name="eventDate"></param>
        /// <returns></returns>
        public string DaysToEvent_Refactored(DateTime now, DateTime eventDate)
        {
            TimeSpan span = eventDate - now;
            switch (span.Days)
            {
                case 0:
                    return "Today";
                case 1:
                    return "Tommorow";
                default:
                    return "In " + span.Days + " days";
            }
        }
        public bool IsEven(int arg)
        {
            return arg % 2 == 0;

            //return arg % 3 == 0

        }
    }
}

