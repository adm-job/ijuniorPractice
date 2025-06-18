using System;
using System.IO;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = ReadMap("map.txt");
            DrawMap(map);
        }

        private static char[,] ReadMap(string patch)
        {
            string[] file = File.ReadAllLines("map.txt");
            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                    map[x, y] = file[y][x];
            }

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                    Console.Write(map[x, y]);

                Console.Write("\n");
            }
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLenght = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > maxLenght)
                    maxLenght = lines[i].Length;
            }

            return maxLenght;
        }
    }
}
