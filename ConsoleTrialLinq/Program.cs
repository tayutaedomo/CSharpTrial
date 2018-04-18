using System;
using System.Linq;

namespace ConsoleTrialLinq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Refer: http://ufcpp.net/study/csharp/sp3_stdquery.html

            var a = new[]
            {
                new { X = 0, Y = 10, Z = new[]{ 1, 2, 3} },
                new { X = 1, Y = 11, Z = new[]{ 4, 5, 6} },
                new { X = 2, Y = 12, Z = new[]{ 7, 8, 9} },
                new { X = 3, Y = 13, Z = new[]{ 0, 1, 2} },
                new { X = 4, Y = 14, Z = new[]{ 3, 4, 5} }
            };

            {
                var b =
                    from p in a
                    select p.X;
                //var b = a.Select(p => p.X);
                foreach (var p in b)
                    Console.Write("{0} ", p);
            }
            {
                var b = a.Select(p => p.X);
                foreach (var p in b)
                    Console.Write("{0} ", p);
            }

            Console.Write("\n\n");

            {
                var b =
                    from p in a
                    let sumZ = p.Z.Sum()
                    select new { p.X, sumZ };

                foreach (var p in b)
                    Console.Write("{0}\n", p);
            }
            {
                var b = a
                    .Select(p => new { p, SumZ = p.Z.Sum() })
                    .Select(p2 => new { p2.p.X, p2.SumZ });

                foreach (var p in b)
                    Console.Write("{0}\n", p);
            }
        }
    }
}