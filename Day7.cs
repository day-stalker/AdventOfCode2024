using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2024
{
    internal static class Day7
    {
        private static readonly string _filePath = "inputs/input7.txt";
        
        public static void Part1()
        {
            var lines = File.ReadAllLines(_filePath);
            var correctTotal = 0L;

            foreach (var line in lines)
            {
                var target = 0L;
                var evaluation = new List<long>();
                foreach (var c in line)
                {
                    if (c == ':')
                    {
                        target = long.Parse(line.Substring(0, line.IndexOf(':')));
                        var evaluationParts = line.Substring(line.IndexOf(':') + 1).Trim().Split(' ');
                        foreach (var part in evaluationParts)
                        {
                            evaluation.Add(long.Parse(part));
                        }
                        break;
                    }
                }

                var equations = GeneratePossibleEquations(evaluation);
                var calculatedEquations = new List<long>();

                foreach (var equation in equations)
                {
                    calculatedEquations.Add(CalculateEquation(evaluation, equation));
                }

                foreach (var calculatedEquation in calculatedEquations)
                {
                    if (calculatedEquation == target)
                    {
                        correctTotal += target;
                        break;
                    }
                }
            }
            Console.WriteLine(correctTotal);
        }

        private static List<string> GeneratePossibleEquations(List<long> evaluation)
        {
            var possibleEquations = new List<string>();

            var signCounter = 0;
            var totalSign = evaluation.Count - 1;
            var stack = new StringBuilder();
            void generate(List<long> evaluation, StringBuilder stack, int signCounter)
            {
                if (signCounter == totalSign)
                {
                    possibleEquations.Add(stack.ToString());
                    return;
                } 
                
                stack.Append('+');
                generate(evaluation, stack, signCounter + 1);
                stack.Remove(stack.Length - 1, 1);
                
                stack.Append('*');
                generate(evaluation, stack, signCounter + 1);
                stack.Remove(stack.Length - 1, 1);
            }
            generate(evaluation, stack, 0);
            
            return possibleEquations;
        }

        private static long CalculateEquation(List<long> evaluation, string equation)
        {
            long result = evaluation[0];
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '+')
                {
                    result += evaluation[i + 1];
                }
                else if (equation[i] == '*')
                {
                    result *= evaluation[i + 1];
                }
            }
            return result;
        }
        
        public static void Part2()
        {
            var lines = File.ReadAllLines(_filePath);
            var correctTotal = 0L;

            foreach (var line in lines)
            {
                var target = 0L;
                var evaluation = new List<long>();
                foreach (var c in line)
                {
                    if (c == ':')
                    {
                        target = long.Parse(line.Substring(0, line.IndexOf(':')));
                        var evaluationParts = line.Substring(line.IndexOf(':') + 1).Trim().Split(' ');
                        foreach (var part in evaluationParts)
                        {
                            evaluation.Add(long.Parse(part));
                        }
                        break;
                    }
                }

                var equations = GeneratePossibleEquations2(evaluation);
                var calculatedEquations = new List<long>();

                foreach (var equation in equations)
                {
                    calculatedEquations.Add(CalculateEquation2(evaluation, equation));
                }

                foreach (var calculatedEquation in calculatedEquations)
                {
                    if (calculatedEquation == target)
                    {
                        correctTotal += target;
                        break;
                    }
                }
            }
            Console.WriteLine(correctTotal);
        }
        
        private static List<List<string>> GeneratePossibleEquations2(List<long> evaluation)
        {
            var possibleEquations = new List<List<string>>();

            var signCounter = 0;
            var totalSign = evaluation.Count - 1;
            var stack = new List<string>();
            void generate(List<string> stack, int signCounter)
            {
                if (signCounter == totalSign)
                {
                    possibleEquations.Add(new List<string>(stack));
                    return;
                } 
                
                stack.Add("+");
                generate(stack, signCounter + 1);
                stack.RemoveAt(stack.Count - 1);
                
                stack.Add("*");
                generate(stack, signCounter + 1);
                stack.RemoveAt(stack.Count - 1);
                
                stack.Add("||");
                generate(stack, signCounter + 1);
                stack.RemoveAt(stack.Count - 1);
            }
            generate(stack, 0);
            
            return possibleEquations;
        }

        private static long CalculateEquation2(List<long> evaluation, List<string> equation)
        {
            long result = evaluation[0];
            for (int i = 0; i < equation.Count; i++)
            {
                if (equation[i] == "+")
                {
                    result += evaluation[i + 1];
                }
                else if (equation[i] == "*")
                {
                    result *= evaluation[i + 1];
                }
                else if (equation[i] == "||")
                {
                    result = long.Parse(result.ToString() + evaluation[i + 1].ToString());
                }
            }
            return result;
        }
    }
}
