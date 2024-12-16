using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2024
{
    internal static class Day2
    {
        private static string filePath = "inputs/input2.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(filePath);
            
            var safeCount = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Trim().Split(" ");
                var level = new List<int>(7);
                foreach (var part in parts)
                {
                    if (int.TryParse(part, out var num))
                    {
                        level.Add(num);
                    }
                }
                
                if (IsSafe1(level))
                {
                    safeCount++;
                }
            }
            Console.WriteLine($"SafeCount: {safeCount}");
        }

        private static bool IsSafe1(List<int> level)
        {
            bool? isInCreasing = null;
            
            for (var i = 1; i < level.Count; i++)
            {
                var diff = level[i] - level[i - 1];
                if (Math.Abs(diff) is > 3 or < 1) return false;
                if (isInCreasing == null)
                {
                    isInCreasing = diff > 0;
                }
                else if (isInCreasing != (diff > 0)) return false;
            }
            return true;
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(filePath);
            
            var safeCount = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Trim().Split(" ");
                var level = new List<int>(7);
                foreach (var part in parts)
                {
                    if (int.TryParse(part, out var num))
                    {
                        level.Add(num);
                    }
                }
                
                if (IsSafe2(level))
                {
                    safeCount++;
                }
            }
            Console.WriteLine($"SafeCount: {safeCount}");
        }
        private static bool IsSafe2(List<int> level)
        {
            if (IsSafe1(level)) return true;
            
            for (var i = 0; i < level.Count; i++)
            {
                var modifiedLevel = new List<int>(level);
                modifiedLevel.RemoveAt(i);

                if (IsSafe1(modifiedLevel)) return true;
            }
            return false;
        }
    }
}