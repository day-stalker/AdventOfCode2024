using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2024
{
    internal static class Day1
    {
        private static string filePath = "inputs/input1.txt";
        public static void Part1()
        {
            var lines = File.ReadAllLines(filePath);
            var LeftList = new List<int>(lines.Length);
            var RightList = new List<int>(lines.Length);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                    continue;
                }
                
                if (int.TryParse(parts[0], out var left) && int.TryParse(parts[1], out var right))
                {
                    LeftList.Add(left);
                    RightList.Add(right);
                }
            }
            
            LeftList.Sort();
            RightList.Sort();

            var diff = 0;
            
            for (var i = 0; i < LeftList.Count; i++)
            {
                diff += Math.Abs(LeftList[i] - RightList[i]);
            }
            
            Console.WriteLine($"Total difference: {diff}");
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(filePath);
            int[] rightCount = new int[100000];
            var LeftList = new List<int>(lines.Length);
            var RightList = new List<int>(lines.Length);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                    continue;
                }
                
                if (int.TryParse(parts[0], out var left) && int.TryParse(parts[1], out var right))
                {
                    LeftList.Add(left);
                    RightList.Add(right);
                }
            }

            foreach (var num in RightList)
            {
                rightCount[num]++;
            }

            var similarity = 0;

            for (var i = 0; i < LeftList.Count; i++)
            {
                similarity += LeftList[i] * rightCount[LeftList[i]];
            }
            
            Console.WriteLine($"Similarity: {similarity}");
        }
    }
}