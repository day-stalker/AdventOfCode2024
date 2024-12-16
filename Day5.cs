using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2024 
{
    internal static class Day5 
    {
        private static string filePath = "inputs/input5.txt";
        
        public static void Part1()
        {
            var lines = File.ReadAllLines(filePath);

            var validMidSum = 0;

            var graph = new Dictionary<int, List<int>>();

            int i = 0;

            for (; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    i++; // cause we need to skip that line for next itteration
                    break;
                }
                var parts = lines[i].Split('|');
                if (!graph.ContainsKey(int.Parse(parts[0])))
                {
                    graph.Add(int.Parse(parts[0]), new List<int>());
                }
                else
                {
                    graph[int.Parse(parts[0])].Add(int.Parse(parts[1]));
                }
                
            }

            for (; i < lines.Length; i++)
            {
                var splited = lines[i].Split(",");
                var inted = Array.ConvertAll(splited, int.Parse);
                
                bool isValid = true;
                var positions = new Dictionary<int, int>();
                
                for (var j = 0; j < inted.Length; j++)
                {
                    positions[inted[j]] = j;
                } // enumerated my positions in order

                foreach (var page in inted)
                {
                    if (!graph.ContainsKey(page)) continue;

                    var afterList = graph[page];

                    foreach (var after in afterList) // checked if position order persists base on graph
                    {
                        if (!positions.ContainsKey(after)) continue;
                        if (positions[page] > positions[after])
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (!isValid) break;
                }

                if (!isValid) continue;

                validMidSum += inted[inted.Length / 2];

            }

            Console.WriteLine(validMidSum);
        }
        public static void Part2()
{
    var lines = File.ReadAllLines(filePath);
    var unValidMidSum = 0;
    var graph = new Dictionary<int, List<int>>();
    int i = 0;

    for (; i < lines.Length; i++)
    {
        if (string.IsNullOrEmpty(lines[i]))
        {
            i++;
            break;
        }
        var parts = lines[i].Split('|');
        if (!graph.ContainsKey(int.Parse(parts[0])))
        {
            graph.Add(int.Parse(parts[0]), new List<int>());
        }
        graph[int.Parse(parts[0])].Add(int.Parse(parts[1]));
    }

    for (; i < lines.Length; i++)
    {
        var splited = lines[i].Split(",");
        var inted = Array.ConvertAll(splited, int.Parse);
        bool isNotValid = false;

        var positions = new Dictionary<int, int>();
        for (var j = 0; j < inted.Length; j++)
        {
            positions[inted[j]] = j;
        }
        foreach (var page in inted)
        {
            if (!graph.ContainsKey(page)) continue;

            var afterList = graph[page];
            foreach (var after in afterList)
            {
                if (!positions.ContainsKey(after)) continue;
                if (positions[page] > positions[after])
                {
                    isNotValid = true;
                    break;
                }
            }
            if (isNotValid) break;
        }

        if (!isNotValid) continue;

        for (var r = 0; r < inted.Length - 1; r++)
        {
            for (var l = 0; l < inted.Length - r - 1; l++)
            {
                if (graph.ContainsKey(inted[l]) && graph[inted[l]].Contains(inted[l + 1])) continue;
                else if (graph.ContainsKey(inted[l + 1]) && graph[inted[l + 1]].Contains(inted[l]))
                {
                    var tmp = inted[l];
                    inted[l] = inted[l + 1];
                    inted[l + 1] = tmp;
                }
            }
        }

        unValidMidSum += inted[inted.Length / 2];
    }

    Console.WriteLine(unValidMidSum);
}


        
    }
       
}