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
            int positionPlayerX = 1;
            int positionPlayerY = 1;
            int score = 0;
            int scoreX = 32;
            int scoreY = 0;
            bool isRetry = true;

            while (isRetry)
            {
                Console.Clear();
                DrawMap(map);

                Console.SetCursorPosition(positionPlayerX, positionPlayerY);
                Console.Write("@");
                Console.SetCursorPosition(scoreX, scoreY);
                Console.Write($"Score: {score}");

                pressedKey = Console.ReadKey();
                PressingKey(pressedKey, ref positionPlayerX, ref positionPlayerY, map, ref score);

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    isRetry = false;
                }
            }
        }

        private static char[,] ReadMap(string patch)
        {
            string[] file = File.ReadAllLines(patch);
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
                {
                    Console.Write(map[x, y]);
                }

                Console.Write("\n");
            }
        }

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLenght = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > maxLenght)
                {
                    maxLenght = lines[i].Length;
                }
            }

            return maxLenght;
        }

        private static void PressingKey(ConsoleKeyInfo pressedKey, ref int positionPlayerX, ref int positionPlayerY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPlayerPositionX = positionPlayerX + direction[0];
            int nextPlayerPositionY = positionPlayerY + direction[1];

            char nextChar = map[nextPlayerPositionX, nextPlayerPositionY];
            char freeSpace = ' ';
            char loot = '$';

            if (nextChar == freeSpace || nextChar == loot)
            {
                positionPlayerX = nextPlayerPositionX;
                positionPlayerY = nextPlayerPositionY;

                if (nextChar == loot)
                {
                    score++;
                    map[nextPlayerPositionX, nextPlayerPositionY] = ' ';
                }
            }
        }
        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            const ConsoleKey UpArrowPressed = ConsoleKey.UpArrow;
            const ConsoleKey DownArrowPressed = ConsoleKey.DownArrow;
            const ConsoleKey LeftArrowPressed = ConsoleKey.LeftArrow;
            const ConsoleKey RightArrowPressed = ConsoleKey.RightArrow;

            int[] direction = { 0, 0 };
            ConsoleKey Up, Down, Left, Right;

            Up = ConsoleKey.UpArrow;

            switch (pressedKey.Key)
            {
                case UpArrowPressed:
                    direction[1] = -1;
                    break;

                case DownArrowPressed:
                    direction[1] = 1;
                    break;

                case LeftArrowPressed:
                    direction[0] = -1;
                    break;

                case RightArrowPressed:
                    direction[0] = 1;
                    break;
            }

            return direction;
        }
    }
}
