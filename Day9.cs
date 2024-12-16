using System; 
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2024
{
    internal static class Day9
    {
        private static readonly string _filePath = "inputs/input9.txt";

        public static void Part1()
        {
            var file = File.ReadAllLines(_filePath);
            string input = file[0];

            var disk = Decode1(input);
            Compact1(disk);
            Console.WriteLine(CheckSum1(disk));
        }

        private static List<char> Decode1(string input)
        {
            var disk = new List<char>();
            int fileId = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int length = int.Parse(input[i].ToString());
                if (i % 2 == 0)
                {
                    disk.AddRange(new string((char)('0' + fileId), length));
                    fileId++;
                }
                else
                {
                    disk.AddRange(new string('.', length));
                }
            }
            return disk;
        }

        private static void Compact1(List<char> disk)
        {
            while (true)
            {
                int leftmostFree = disk.IndexOf('.');
                int rightmostFile = -1;
                for (int i = disk.Count - 1; i >= 0; i--)
                {
                    if (disk[i] != '.')
                    {
                        rightmostFile = i;
                        break;
                    }
                }

                if (leftmostFree == -1 || rightmostFile == -1 || leftmostFree > rightmostFile) break;

                disk[leftmostFree] = disk[rightmostFile];
                disk[rightmostFile] = '.';
            }
        }

        private static long CheckSum1(List<char> disk)
        {
            long result = 0;
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != '.')
                {
                    result += (disk[i] - '0') * i;
                }
            }
            return result;
        }
    }
}