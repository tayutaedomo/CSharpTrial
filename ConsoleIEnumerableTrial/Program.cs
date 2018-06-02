using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleIEnumerableTrial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DoFromTo();
            DoSleepYield();
        }

        static void DoFromTo()
        {
            // See: http://ufcpp.net/study/csharp/sp2_iterator.html
            Console.Write("doFromTo\n");

            foreach(int i in FromTo(10, 20))
            {
                Console.Write("{0}\n", i);
            }
        }

        static IEnumerable<int> FromTo(int from, int to)
        {
            while(from <= to)
                yield return from++;
        }


        static void DoSleepYield()
        {
            // See: http://tyheeeee.hateblo.jp/entry/2013/08/07/C%23%E3%81%AB%E3%81%8A%E3%81%91%E3%82%8Byield_return%E3%81%AE%E6%8C%99%E5%8B%95
            foreach (string item in SleepYield())
                Console.WriteLine(item);
        }

        static IEnumerable<string> SleepYield()
        {
            Console.Write("Staart 1st\n");
            Thread.Sleep(500);
            yield return "End 1st";

            Console.Write("Start 2nd\n");
            Thread.Sleep(500);
            yield return "End 2nd";

            Console.Write("Start 3rd\n");
            Thread.Sleep(500);
            yield return "End 3rd";
        }

        static void DoHttpYield()
        {
            
        }
    }
}

