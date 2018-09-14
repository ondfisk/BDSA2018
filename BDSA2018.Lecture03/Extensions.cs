using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture03
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> stuff)
        {
            foreach (var s in stuff)
            {
                Console.WriteLine(s);
            }
        }

        public static void Print<T>(this T stuff)
        {
            Console.WriteLine(stuff);
        }

        public static void Scream(this int number)
        {
            if (number == 42)
            {
                Console.WriteLine("aaaaarrrggghhh!!!");
            }
        }
    }
}
