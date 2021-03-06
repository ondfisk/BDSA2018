﻿using System;

namespace BDSA2018.Lecture08.Models.ChainOfResponsibility
{
    public class CEO : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine($"{nameof(CEO)} approved request no. {purchase.Number}");
            }
            else
            {
                Console.WriteLine($"Request no. {purchase.Number} requires an executive meeting!");
            }
        }
    }
}
