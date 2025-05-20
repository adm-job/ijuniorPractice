using System.IO;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxBar;
            int currentBar;
            string frameChars = "";
            ConsoleColor consoleColor;

            EnteringParameters(out currentBar, out maxBar, out frameChars);
            DrawConsoleBar(currentBar, maxBar, ConsoleColor.Red, 0, 0, frameChars[0]);
            EnteringParameters(out currentBar, out maxBar, out frameChars);
            DrawConsoleBar(currentBar, maxBar, ConsoleColor.Blue, 0, 1, frameChars[1]);
        }

        static void DrawConsoleBar(int value, int maxValue, ConsoleColor color, int positionX = 0, int positionY = 0, char firstBracket = '[', char lastBracket = ']')
        {
            int percentMax = 100;

            value = maxValue * value / percentMax;

            Console.SetCursorPosition(positionX, positionY);
            Console.Write(firstBracket);
            Console.ForegroundColor = color;
            DrowChars(value, '#');
            Console.ResetColor();
            DrowChars(maxValue - value, '_');
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
            Console.SetCursorPosition(0, 10);
            Console.Write("\bВведите процент заполнения: ");
            currentBar = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите длинну шкалы: ");
            maxBar = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nДоп. параметр рамка из 2 символов, можно пропустить по ENTER: ");
            frameChars = Console.ReadLine();

            if (frameChars == "")
            {
                frameChars = "[]";
            }
        }
    }
}


