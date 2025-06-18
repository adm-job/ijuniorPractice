using System;
using System.IO;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

            char[,] map = ReadMap("map.txt");
            int playerX = 1;
            int playerY = 1;
            int score = 1;


            while (true)
            {
                Console.Clear();
                DrawMap(map);

                Console.SetCursorPosition(playerX, playerY);
                Console.Write("@");

                pressedKey = Console.ReadKey();
                PressedButton(pressedKey, ref playerX, ref playerY, map, ref score);

                Console.SetCursorPosition(32, 0);
                Console.Write("Score");
            }
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

        private static void PressedButton(ConsoleKeyInfo pressedKey, ref int playerX, ref int playerY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPlayerPositionX = playerX + direction[0];
            int nextPlayerPositionY = playerY + direction[1];

            char nextChar = map[nextPlayerPositionX, nextPlayerPositionY];

            if (nextChar == ' ' || nextChar == '$')
            {
                playerX = nextPlayerPositionX;
                playerY = nextPlayerPositionY;
                if (nextChar == '$')
                {
                    score++;
                    map[nextPlayerPositionX, nextPlayerPositionY] = ' ';
                }
            }
        }
        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    direction[1] = -1;
                    break;

                case ConsoleKey.DownArrow:
                    direction[1] = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    direction[0] = -1;
                    break;

                case ConsoleKey.RightArrow:
                    direction[0] = 1;
                    break;
            }

            return direction;
        }
    }
}
