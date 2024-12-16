using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdventOfCode2024{
    internal static class Program
    {
        private static void Main(string[] args)
        { 
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Day9.Part1();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}