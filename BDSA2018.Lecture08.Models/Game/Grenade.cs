namespace BDSA2018.Lecture08.Models.Game
{
    public class Grenade : IWeapon
    {
        public string Name => nameof(Grenade);

        public int Damage => 128;

        public int Range => 4;
    }
}
