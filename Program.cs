namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = 100;

            Healthbar(inputNumber);
        }

        static void Healthbar(int inputNumber)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("[");
            Console.SetCursorPosition(12, 0);
            Console.WriteLine("]");
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 10; i++)
            {
                if ((inputNumber / 10) > i)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write("_");
                }
            }
        }
    }
}
