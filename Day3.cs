using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    internal static class Day3
    {
        private static string filePath = "inputs/input3.txt";
        
        public static void Part1()
        {
            var lines = File.ReadAllLines(filePath);
            var sum = 0;
            var pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            foreach (var line in lines)
            {
                var fullLine = string.Join("", line.Split(' '));
                var matches = Regex.Matches(fullLine, pattern);
                
                foreach (Match match in matches)
                {
                    var x = int.Parse(match.Groups[1].Value);
                    var y = int.Parse(match.Groups[2].Value);
                    sum += x * y;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines(filePath);
            var sum = 0;
            var isEnabled = true;
            
            var mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            var blockPattern = @"don't\(\)";
            var unblockPattern = @"do\(\)";

            foreach (var line in lines)
            {
                int i = 0;
                while (i < line.Length)
                {
                    var window = line.Substring(i, Math.Min(20, line.Length - i));

                    if (Regex.IsMatch(window, blockPattern))
                    {
                        isEnabled = false;
                        i += window.IndexOf("don't()") + 7;
                        continue;
                    }

                    if (Regex.IsMatch(window, unblockPattern))
                    {
                        isEnabled = true;
                        i += window.IndexOf("do()") + 4;
                        continue;
                    }

                    if (isEnabled)
                    {
                        var match = Regex.Match(window, mulPattern);
                        if (match.Success)
                        {
                            var x = int.Parse(match.Groups[1].Value);
                            var y = int.Parse(match.Groups[2].Value);
                            sum += x * y;
                            i += match.Index + match.Length;
                            continue;
                        }
                    }

                    i++;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
