using System;

namespace BDSA2018.Lecture03
{
    public class TrafficLightController : ITrafficLightController
    {
        public bool MayIGo(TrafficLightColor color)
        {
            switch (color)
            {
                case TrafficLightColor.Green:
                    return true;
                case TrafficLightColor.Yellow:
                case TrafficLightColor.Red:
                    return false;
                default:
                    throw new ArgumentException("Invalid color");
            }
        }
    }
}
