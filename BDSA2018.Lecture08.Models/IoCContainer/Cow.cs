using System;

namespace BDSA2018.Lecture08.Models.IoCContainer
{
    public class Cow : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Mooh");
        }
    }
}
