using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode2024
{
    internal static class Day6
    {
        private static int _width;
        private static int _height;
        private static char[,]? _map;
        private static string filePath = "inputs/input6.txt";
        private static Point _startingPoint;

        public static string Part1()
        {
            var lines = new List<string>();

            foreach (var line in File.ReadLines(filePath))
            {
                _width = line.Length;
                _height++;
                lines.Add(line);
            }

            _map = new char[_width, _height];

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _map[x, y] = lines[y][x];
                    if (_map[x, y] == '^')
                    {
                        _startingPoint = new Point(x, y);
                    }
                }
            }

            var result = CountSteps(_startingPoint).ToString();
            Console.WriteLine(result);

            return result;
        }

        private static int CountSteps(Point start)
        {
            var visited = new HashSet<Point>();
            var currentDirection = new Point(0, -1);
            var currentPoint = start;

            while (true)
            {
                visited.Add(currentPoint);
                var nextPosition = new Point(currentPoint.X + currentDirection.X, currentPoint.Y + currentDirection.Y);

                if (IsOutOfBounds(nextPosition))
                {
                    break;
                }

                if (_map[nextPosition.X, nextPosition.Y] == '#')
                {
                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                    nextPosition = new Point(currentPoint.X + currentDirection.X, currentPoint.Y + currentDirection.Y);
                }

                currentPoint = nextPosition;
            }

            return visited.Count;
        }

        public static void Part2()
        {
            var lines = new List<string>();

            foreach (var line in File.ReadLines(filePath))
            {
                _width = line.Length;
                _height++;
                lines.Add(line);
            }

            _map = new char[_width, _height];

            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    _map[x, y] = lines[y][x];
                    if (_map[x, y] == '^')
                    {
                        _startingPoint = new Point(x, y);
                    }
                }
            }

            var potentialObstructions = GetPotentialObstructions(_startingPoint);
            var obstructionCount = 0;

            foreach (var potentialObstruction in potentialObstructions.Except(new[] { _startingPoint }))
            {
                if (DoesGuardLoop(_startingPoint, potentialObstruction))
                {
                    obstructionCount++;
                }
            }

            Console.WriteLine($"Total Obstruction Count: {obstructionCount}");
        }

        private static bool DoesGuardLoop(Point startingPoint, Point newObstruction)
        {
            var visited = new HashSet<(Point point, Point direction)>();
            var currentDirection = new Point(0, -1);
            var currentPoint = startingPoint;

            while (true)
            {
                if (visited.Contains((currentPoint, currentDirection)))
                {
                    return true; 
                }

                visited.Add((currentPoint, currentDirection));

                var nextPosition = new Point(
                    currentPoint.X + currentDirection.X,
                    currentPoint.Y + currentDirection.Y
                );

                if (IsOutOfBounds(nextPosition))
                {
                    break;
                }

                if (_map[nextPosition.X, nextPosition.Y] == '#' || 
                    (nextPosition.X == newObstruction.X && nextPosition.Y == newObstruction.Y))
                {
                    // Turn right
                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                    nextPosition = currentPoint;
                }

                if (IsOutOfBounds(nextPosition))
                {
                    break;
                }

                currentPoint = nextPosition;
            }

            return false;
        }

        private static HashSet<Point> GetPotentialObstructions(Point start)
        {
            var visited = new HashSet<Point>();
            var currentDirection = new Point(0, -1);
            var currentPoint = start;

            while (true)
            {
                visited.Add(currentPoint);
                var nextPosition = new Point(
                    currentPoint.X + currentDirection.X,
                    currentPoint.Y + currentDirection.Y
                );

                if (IsOutOfBounds(nextPosition))
                {
                    break;
                }

                if (_map[nextPosition.X, nextPosition.Y] == '#')
                {
                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                    nextPosition = currentPoint;
                }

                if (IsOutOfBounds(nextPosition))
                {
                    break;
                }

                currentPoint = nextPosition;
            }

            return visited;
        }

        private static bool IsOutOfBounds(Point position)
        {
            return position.X < 0 || position.Y < 0 || position.X >= _width || position.Y >= _height;
        }
    }
}