using System;

namespace BDSA2018.Lecture01.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var name = args?.Length > 0 
                ? args[0] 
                : "World";

            Console.WriteLine("Hello {0}!", name);
        }
    }
}
