using System;

namespace BDSA2018.Lecture02
{
    public class TrafficLightController : ITrafficLightController
    {
        public bool MayIGo(string color)
        {
            switch (color.ToLower())
            {
                case "green":
                    return true;
                case "yellow":
                case "red":
                    return false;
                default:
                    throw new ArgumentException("Invalid color");
            }
        }
    }
}
