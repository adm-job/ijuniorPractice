namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxBar = 0;
            int currentBar = 0;
            string frameChars = "";
            ConsoleColor consoleColor;

            
            EnteringParameters(ref currentBar, ref maxBar,ref frameChars);
            DrawConsoleBar(currentBar, maxBar, ConsoleColor.Red,0,0, frameChars);
            EnteringParameters(ref currentBar, ref maxBar, ref frameChars);
            DrawConsoleBar(currentBar, maxBar, ConsoleColor.Blue, 0, 1, frameChars);
        }

        static void DrawConsoleBar(int value, int maxValue, ConsoleColor color, int positionX = 0, int positionY = 0, string frameChars = "[]")
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(frameChars[0]);
            Console.ForegroundColor = color;
            DrowChars(0, value, '#');
            Console.ResetColor();
            DrowChars(value, maxValue, '_');
            Console.Write(frameChars[1]);
        }

        static void DrowChars(int minValue, int maxValue, char haveChar)
        {
            for (int i = minValue; i < maxValue; i++)
            {
                Console.Write(haveChar);
            }
        }

        static void EnteringParameters(ref int currentBar, ref int maxBar,ref string frameChars)
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


