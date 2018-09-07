using System.Linq;

namespace BDSA2018.Lecture02
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Enumerable.Range(0, int.MaxValue);

            var evens = CollectionUtilities.GetEven(input);
        }
    }
}
