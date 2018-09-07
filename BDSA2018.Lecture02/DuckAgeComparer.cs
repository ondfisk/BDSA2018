using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture02
{
    public class DuckAgeComparer : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Age == y.Age)
            {
                return 0;
            }
            if (x.Age < y.Age)
            {
                return -4;
            }
            return 42;
        }

        public static Comparison<Duck> Comparison => throw new NotImplementedException();
    }
}
