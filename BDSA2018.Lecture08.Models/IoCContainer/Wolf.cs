using System;

namespace BDSA2018.Lecture08.Models.IoCContainer
{
    public class Wolf : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Woof");
        }
    }
}
