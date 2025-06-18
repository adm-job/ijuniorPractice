using System;
using System.IO;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadMap("map.txt");
        }

        private static char[,] ReadMap(string patch)
        {
            string[] file = File.ReadAllLines("map.txt");
            char[,] map = new char[file[0].Length,file.Length] ;

            for (int x = 0; x < file.Length; x++)
            {
                for (int y = 0; y < file[x].Length; y++)
                    map[x, y] = file[y][x];
            }

            return map;
        }
    }
}
