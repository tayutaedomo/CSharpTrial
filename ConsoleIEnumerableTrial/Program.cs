using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleIEnumerableTrial
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //DoFromTo();
            //DoSleepYield();
            //DoTaskYield();
            DoNestedTaskYieldWithCallback();
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
            Console.Write("Start 1st\n");
            Thread.Sleep(500);
            yield return "End 1st";

            Console.Write("Start 2nd\n");
            Thread.Sleep(500);
            yield return "End 2nd";
        }

        static void DoTaskYield()
        {
            foreach (string item in TaskYield())
                Console.WriteLine(item);
        }

        static IEnumerable<string> TaskYield()
        {
            Task t1 = Task.Run(() =>
            {
                Console.Write("Start 1st\n");
                Thread.Sleep(500);
            });
            t1.Wait();
            yield return "End 1st";
            
            Task t2 = Task.Run(() =>
            {
                Console.Write("Start 2nd\n");
                Thread.Sleep(500);
            });
            t2.Wait();
            yield return "End 2nd";
        }

        static void DoNestedTaskYieldWithCallback()
        {
            foreach (string item in NestedTaskYield())
                Console.WriteLine(item);
        }

        static IEnumerable<string> NestedTaskYield()
        {
            string t1Result = "";
            Task t1 = SleepTaskWithCallback("1st", (str) => { t1Result = str; });
            Console.WriteLine("Beafre wait");
            t1.Wait();
            yield return "End " + t1Result;
            
            string t2Result = "";
            Task t2 = SleepTaskWithCallback("2st", (str) => { t2Result = str; });
            Console.WriteLine("Beafre wait");
            t2.Wait();
            yield return "End " + t2Result;
        }

        static Task<string> SleepTaskWithCallback(string str, Action<string> callback)
        {
            return SleepTask(str).ContinueWith(t =>
            {
                Console.Write("t.Result {0}\n", t.Result);
                callback(t.Result);
                return t;

            }).Unwrap();
        }

        static Task<string> SleepTask(string str)
        {
            return Task.Run(() =>
            {
                Console.Write("Start {0}\n", str);
                Thread.Sleep(500);
                return "nested " + str;
            });
        }
    }
}

