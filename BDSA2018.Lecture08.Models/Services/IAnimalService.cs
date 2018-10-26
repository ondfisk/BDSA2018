using System;

namespace BDSA2018.Lecture08.Models.Animals
{
    public interface IAnimalService : IDisposable
    {
        void Speak();
    }
}