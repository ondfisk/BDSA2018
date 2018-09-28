using BDSA2018.Lecture05.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BDSA2018.Lecture05.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var container = IoCContainer.Create();

            var repository = container.GetRequiredService<ICharacterRepository>();


        }
    }
}
