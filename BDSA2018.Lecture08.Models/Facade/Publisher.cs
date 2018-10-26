using System;

namespace BDSA2018.Lecture08.Models.Facade
{
    public class Publisher : IPublisher
    {
        public void PublishOnline(Article article)
        {
            Console.WriteLine($"Published {article.Title} by {article.Author} online");
        }
    }
}
