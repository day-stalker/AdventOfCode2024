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

            var decodedLine = Decode1(input);
            var sorted = Sort1(decodedLine);
            var checkSum = CheckSum(sorted);
            
            Console.WriteLine(checkSum);
        }

        private static string Decode1(string input)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    builder.Append(new string(input[i], int.Parse(input[i].ToString())));
                }
                else
                {
                    builder.Append(new string('.', int.Parse(input[i].ToString())));
                }
            }
            return builder.ToString();
        }

        private static string Sort1(string line)
        {
            char[] charArray = line.ToCharArray();
            var right_i = charArray.Length - 1;
            for (var l = 0; l <  right_i; l++)
            {
                if (l < right_i && charArray[l] == '.' && charArray[right_i] != '.')
                {
                    char tmp = charArray[l];
                    charArray[l] = charArray[right_i];
                    charArray[right_i] = tmp;
                    right_i--;
                }

                if (l < right_i && charArray[l] == '.' && charArray[right_i] == '.')
                {
                    right_i--;
                }
            }
            return new string(charArray);
        }
        private static long CheckSum(string line)
        {
            long result = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] != '.')
                {
                    result += long.Parse(line[i].ToString()) * i;
                }
            }

            return result;
        } 
    }
}