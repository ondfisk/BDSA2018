using System;

namespace BDSA2018.Lecture03
{
    public enum TrafficLightColor
    {
        Green,
        Red,
        Yellow
    }

    [Flags]
    public enum EightBitSwitches
    {
        None = 0b00000000, // 0
        One = 0b00000001, // 1
        Two = 0b00000010, // 2
        Three = 0b00000100, // 4
        Four = 0b00001000, // 8
        Five = 0b00010000, // 16
        Six = 0b00100000, // 32
        Seven = 0b01000000, // 64
        Eight = 0b10000000  // 128
    }
}
