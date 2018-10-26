namespace BDSA2018.Lecture08.Models.Game
{
    public interface IWeapon
    {
        string Name { get; }

        int Damage { get; }

        int Range { get; }
    }
}
