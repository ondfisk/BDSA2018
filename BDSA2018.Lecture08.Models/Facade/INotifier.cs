﻿using System.Collections.Generic;

namespace BDSA2018.Lecture08.Models.Facade
{
    public interface INotifier
    {
        void Notify(Article article, IEnumerable<Person> people);
    }
}