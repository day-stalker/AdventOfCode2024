using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2024
{
    internal static class Day8
    {
        private static readonly string _fileName = "inputs/input8.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(_fileName);
            int height = lines.Length;
            int width = lines[0].Length;

            var uniqueNodes = new HashSet<(int, int)>();
            
            for (int x1 = 0; x1 < height; x1++)
            {
                for (int y1 = 0; y1 < width; y1++)
                {
                    char freq1 = lines[x1][y1];
                    if (freq1 == '.') continue;

                    for (int x2 = 0; x2 < height; x2++)
                    {
                        for (int y2 = 0; y2 < width; y2++)
                        {
                            if (x1 == x2 && y1 == y2) continue;

                            char freq2 = lines[x2][y2];
                            if (freq1 != freq2) continue;
                            
                            int xDiff = x2 - x1;
                            int yDiff = y2 - y1;
                            
                            var antinode1 = (x1 - xDiff, y1 - yDiff);
                            var antinode2 = (x2 + xDiff, y2 + yDiff);
                            
                            if (IsWithinBounds(antinode1.Item1, antinode1.Item2, height, width))
                            {
                                uniqueNodes.Add(antinode1);
                            }

                            if (IsWithinBounds(antinode2.Item1, antinode2.Item2, height, width))
                            {
                                uniqueNodes.Add(antinode2);
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine(uniqueNodes.Count);
        }
        private static bool IsWithinBounds(int r, int c, int totalR, int totalC)
        {
            return r >= 0 && r < totalR && c >= 0 && c < totalC;
        }
        
        public static void Part2()
        {
            var lines = File.ReadAllLines(_fileName);
            int height = lines.Length;
            int width = lines[0].Length;

            var uniqueNodes = new HashSet<(int, int)>();

            for (int x1 = 0; x1 < height; x1++)
            {
                for (int y1 = 0; y1 < width; y1++)
                {
                    char freq1 = lines[x1][y1];
                    if (freq1 == '.') continue;

                    for (int x2 = 0; x2 < height; x2++)
                    {
                        for (int y2 = 0; y2 < width; y2++)
                        {
                            if (x1 == x2 && y1 == y2) continue;

                            char freq2 = lines[x2][y2];
                            if (freq1 != freq2) continue;
                            
                            int xDiff = x2 - x1;
                            int yDiff = y2 - y1;
                            
                            uniqueNodes.Add((x1, y1));
                            uniqueNodes.Add((x2, y2));
                            
                            ExtendLineRecursively(uniqueNodes, x1 - xDiff, y1 - yDiff, -xDiff, -yDiff, height, width);
                            ExtendLineRecursively(uniqueNodes, x2 + xDiff, y2 + yDiff, xDiff, yDiff, height, width);
                        }
                    }
                }
            }

            Console.WriteLine(uniqueNodes.Count);
        }

        private static void ExtendLineRecursively(HashSet<(int, int)> uniqueNodes, int x, int y, int dx, int dy, int height, int width)
        {
            if (!IsWithinBounds(x, y, height, width)) return;
            
            uniqueNodes.Add((x, y));
            
            ExtendLineRecursively(uniqueNodes, x + dx, y + dy, dx, dy, height, width);
        }
    }
}