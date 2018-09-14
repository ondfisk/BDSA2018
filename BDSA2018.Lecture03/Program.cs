using BDSA2018.Lecture03.Models;
using System;
using static System.Console;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace BDSA2018.Lecture03
{
    public delegate int BinaryOperation(int x1, int y1);

    class Program
    {
        static void Main(string[] args)
        {
            //Action<string> process = Console.WriteLine;

            //int add(int a, int b) => a + b;

            //Predicate<City> london = c => c.Name == "London";
            //Func<City, bool> berlin = c => c.Name == "Berlin";

            //WriteLine(london(new City { Name = "Berlin" }));

            //WriteLine(Compute(add, 20, 22));

            //var res = Add(int.MaxValue, 42);

            //Console.WriteLine(res);

            //var hero = new { Name = "Clark Kent", AlterEgo = "Superman", City = default(string) };
            //var hero2 = new { Name = "Peter Parker", AlterEgo = "Spider-man", City = "New York" };

            //hero = hero2;

            var repo = new Repository();

            //var cities = repo.Cities;

            //var sorted = cities.OrderBy(c => c.Name);

            //sorted.Print();

            var heroes = repo.Superheroes;

            //heroes.OrderByDescending(c => c.GivenName)
            //      .ThenBy(c => c.Surname)
            //      .Print();

            //heroes.OrderByDescending(h => h.FirstAppearance).First(s => s.FirstAppearance < DateTime.Parse("1945-01-01")).Print();

            var h1 = from h in heroes
                     orderby h.GivenName descending, h.Surname
                     select new Superhero { AlterEgo = h.AlterEgo };

            //h1.First().Print();

            var h2 = from h in heroes
                     join c in repo.Cities on h.CityId equals c.Id
                     select new { h.AlterEgo, City = c.Name };

            //h2.Print();

            //var gr = from y in h2
            //         group y by y.City into g
            //         select new
            //         {
            //             City = g.Key,
            //             Count = g.Count()
            //         };

            //gr.Print();


            var text = File.ReadAllText("Hamlet.txt");

            var words = Regex.Split(text, @"\P{L}+");

            var histogram = from w in words
                            group w by w.ToLower() into h
                            let c = h.Count()
                            orderby c descending
                            select new { Word = h.Key, Count = c };

            //histogram.Take(5).Print();

            var dict = histogram.ToLookup(i => i.Count, i => i.Word);

            dict[42].Print();
        }

        public static int Compute(Func<int, int, int> op, int x, int y)
        {
            return op(x, y);
        }

        public static long Add(long x, long y)
        {
            checked
            {
                y += x;
            }

            return y;
        }
    }
}
