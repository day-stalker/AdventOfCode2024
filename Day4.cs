using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace AdventOfCode2024 {
    internal static class Day4
    { 
        private static string filePath = "inputs/input4.txt";

        public static void Part1()
        {
            var lines = File.ReadAllLines(filePath);
            var matrix = new List<List<string>>();
            var count = 0;
            var directions = new int[][]
            {
                new[] {1, 1},
                new[] {-1, 1},
                new[] {1, -1},
                new[] {-1, -1},
                new[] {1, 0},
                new[] {0, 1},
                new[] {0, -1},
                new[] {-1, 0}
            };

            
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    
                }
                var row = line.ToCharArray()
                    .Select(c => c.ToString())
                    .ToList();
                matrix.Add(row.ToList());
            }

            for (var i = 0; i < matrix.Count; i++)
            {
                for (var j = 0; j < matrix[i].Count; j++)
                {
                    
                    if (matrix[i][j] == "X")
                    {
                        foreach (var direction in directions)
                        {
                            var builder = new StringBuilder();
                            builder.Append("X");

                            for (var k = 1; k < 4; k++)
                            {
                                var x = i + direction[0]*k;
                                var y = j + direction[1]*k;

                                if (x < 0 || x >= matrix.Count) 
                                    break;
                                if (y < 0 || y >= matrix[x].Count)
                                    break;

                                builder.Append(matrix[x][y]);
                            }

                            if (builder.Length == 4 && builder.ToString() == "XMAS")
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
        public static void Part2()
        {
            var lines = File.ReadAllLines(filePath);
            var matrix = new List<List<string>>();
            var count = 0;
            var directions = new int[][]
            {
                new[] {1, 1},
                new[] {-1, 1},
                new[] {1, -1},
                new[] {-1, -1}
            };

            
            foreach (var line in lines)
            {
                var row = line.ToCharArray()
                    .Select(c => c.ToString())
                    .ToList();
                matrix.Add(row.ToList());
            }

            for (var i = 0; i < matrix.Count; i++)
            {
                for (var j = 0; j < matrix[i].Count; j++)
                {
                    
                    if (matrix[i][j] == "A")
                    {
                        int x1 = i + directions[0][0];
                        int y1 = j + directions[0][1];
                        int x2 = i + directions[3][0];
                        int y2 = j + directions[3][1];

                        int x3 = i + directions[1][0];
                        int y3 = j + directions[1][1];
                        int x4 = i + directions[2][0];
                        int y4 = j + directions[2][1];
                        
                        if (x1 < 0 || x1 >= matrix.Count || y1 < 0 || y1 >= matrix[x1].Count) continue;
                        if (x2 < 0 || x2 >= matrix.Count || y2 < 0 || y2 >= matrix[x2].Count) continue;
                        if (x3 < 0 || x3 >= matrix.Count || y3 < 0 || y3 >= matrix[x3].Count) continue;
                        if (x4 < 0 || x4 >= matrix.Count || y4 < 0 || y4 >= matrix[x4].Count) continue;
                        
                        char topLeft = matrix[x2][y2][0];
                        char bottomRight = matrix[x1][y1][0];

                        char topRight = matrix[x3][y3][0];
                        char bottomLeft = matrix[x4][y4][0];
                        
                        bool diag1Valid = (topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M');
                        
                        bool diag2Valid = (topRight == 'M' && bottomLeft == 'S') || (topRight == 'S' && bottomLeft == 'M');

                        if (diag1Valid && diag2Valid)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}