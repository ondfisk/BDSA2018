using System;
using System.Collections.Generic;

namespace BDSA2018.Lecture02
{
    public class CollectionUtilities
    {
        public static IEnumerable<int> GetEven(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                if (item == 42)
                {
                    continue;
                }

                if (item % 2 == 0)
                {
                    //if (item > 42)
                    //{
                    //    yield break;
                    //}

                    yield return item;
                }
            }
        }

        public static bool Find(int[] list, int number)
        {
            throw new NotImplementedException();
        }

        public static ISet<int> Unique(IEnumerable<int> numbers)
        {
            return new HashSet<int>(numbers);
        }

        public static IEnumerable<int> Reverse(IEnumerable<int> numbers)
        {
            return new Stack<int>(numbers);
        }

        public static void Sort(List<Duck> ducks, IComparer<Duck> comparer = null)
        {
            ducks.Sort(comparer);
        }

        public static IDictionary<int, Duck> ToDictionary(IEnumerable<Duck> ducks)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Duck> GetOlderThan(IEnumerable<Duck> ducks, int age)
        {
            throw new NotImplementedException();
        }
    }
}
