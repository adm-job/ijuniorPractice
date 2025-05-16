namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHealth = 10;
            int currentHealth = 4;
            int maxMana = 20;
            int currentMana = 12;
            string frameChars = "<>";

            DrawConsoleBar(currentHealth, maxHealth, ConsoleColor.Red);
            DrawConsoleBar(currentMana, maxMana, ConsoleColor.Blue,0, 1,frameChars);
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
    }
}


