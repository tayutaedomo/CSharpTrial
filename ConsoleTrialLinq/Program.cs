using System;
using System.Linq;

namespace ConsoleTrialLinq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = new[]
            {
                new { X = 0, Y = 10, Z = new[]{ 1, 2, 3} },
                new { X = 1, Y = 11, Z = new[]{ 4, 5, 6} },
                new { X = 2, Y = 12, Z = new[]{ 7, 8, 9} },
                new { X = 3, Y = 13, Z = new[]{ 0, 1, 2} },
                new { X = 4, Y = 14, Z = new[]{ 3, 4, 5} },
            };

            {
                var b =
                    from p in a
                    select p.X;
                //var b = a.Select(p => p.X);
                foreach (var p in b)
                    Console.Write("{0} ", p);
            }

            Console.WriteLine("");

            {
                var b = a.Select(p => p.X);
                foreach (var p in b)
                    Console.Write("{0} ", p);
            }
        }
    }
}