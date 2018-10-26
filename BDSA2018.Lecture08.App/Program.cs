using BDSA2018.Lecture08.Models.ChainOfResponsibility;
using BDSA2018.Lecture08.Models.Facade;
using BDSA2018.Lecture08.Models.FactoryMethod;
using BDSA2018.Lecture08.Models.IoCContainer;
using BDSA2018.Lecture08.Models.Singleton;
using BDSA2018.Lecture08.Models.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BDSA2018.Lecture08.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IoCContainer.Container;

            var service = container.GetService<IAnimal>();

            //service.Hello();

            //Game.Run();

            //var config = container.GetRequiredService<IConfig>();

            //Console.WriteLine(config.ClientId);

            var facade = container.GetService<Facade>();
            var article = new Article
            {
                Title = "Something really bad happened",
                Body = "Bad, bad, bad, bad, ...",
                Author = "The Pessimist"
            };

            //facade.Publish(article);

            //ChainOfResponsibility.Run();

            Strategy.Run();
        }
    }
}
