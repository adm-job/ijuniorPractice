using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxBar;
            int percentageFilling;
            string frameChars = "";
            ConsoleColor consoleColor;

            EnteringParameters(out percentageFilling, out maxBar, out frameChars);
            DrawConsoleBar(percentageFilling, maxBar, ConsoleColor.Red, 0, 0, frameChars[0], frameChars[1]);
            EnteringParameters(out percentageFilling, out maxBar, out frameChars);
            DrawConsoleBar(percentageFilling, maxBar, ConsoleColor.Blue, 0, 1, frameChars[0], frameChars[1]);
        }

        static void DrawConsoleBar(int percentageFilling, int maxBar, ConsoleColor color, int positionX = 0, int positionY = 0, char firstBracket = '[', char lastBracket = ']')
        {
            int percentMax = 100;

            percentageFilling = maxBar * percentageFilling / percentMax;

            Console.SetCursorPosition(positionX, positionY);
            Console.Write(firstBracket);
            Console.ForegroundColor = color;
            DrowChars(percentageFilling, '#');
            Console.ResetColor();
            DrowChars(maxBar - percentageFilling, '_');
            Console.Write(lastBracket);
        }

        static void DrowChars(int maxValue, char characterOutput)
        {
            for (int i = 0; i < maxValue; i++)
            {
                Console.Write(characterOutput);
            }
        }

        static void EnteringParameters(out int currentBar, out int maxBar, out string frameChars)
        {
            int inputNumber = 0;

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("\bВведите процент заполнения: ");
            currentBar = ReadInt(inputNumber);
            Console.WriteLine("\nВведите длину шкалы: ");
            maxBar = ReadInt(inputNumber);
            Console.Write("\nДоп. параметр рамка из 2 символов, можно пропустить по ENTER: ");
            frameChars = Console.ReadLine();

            if (frameChars == "")
            {
                frameChars = "[]";
            }
        }

        static int ReadInt(int inputNumber)
        {
            Console.Write("Введите число: ");

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число: ");
            }

            return inputNumber;
        }
    }
}


