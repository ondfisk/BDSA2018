using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2018.Lecture06
{
    public class TaskParallelLibrary
    {
        public static void For()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void ForEach()
        {
            var numbers = Enumerable.Range(0, 1000);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public static void Invoke()
        {
            var sw = Stopwatch.StartNew();

            SuperLongRunningThingy1();
            SuperLongRunningThingy2();
            SuperLongRunningThingy3();
            SuperLongRunningThingy4();

            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }

        private static void SuperLongRunningThingy1()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private static void SuperLongRunningThingy2()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private static void SuperLongRunningThingy3()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private static void SuperLongRunningThingy4()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
}
