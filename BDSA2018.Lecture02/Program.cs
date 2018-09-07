using System;
using System.Linq;

namespace BDSA2018.Lecture02
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = Enumerable.Range(0, int.MaxValue);

            //var evens = CollectionUtilities.GetEven(input);

            //foreach (var item in evens)
            //{
            //    Console.WriteLine(item);
            //}

            var ducks = Duck.Ducks;

            CollectionUtilities.Sort(ducks, new DuckAgeComparer());

            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Name} {duck.Age}");
            }
        }
    }
}
