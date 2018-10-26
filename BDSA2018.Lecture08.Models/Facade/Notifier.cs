using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture08.Models.Facade
{
    public class Notifier : INotifier
    {
        public void Notify(Article article, IEnumerable<Person> people)
        {
            Console.WriteLine("Notifying:");
            foreach (var person in people)
            {
                Console.WriteLine($"- {person.Name}");
            }
        }
    }
}
