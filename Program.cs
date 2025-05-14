namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = 0;

            ReadInt(ref inputNumber);
            Console.WriteLine(inputNumber);
        }

        static int ReadInt(ref int inputNumber)
        {
            Console.WriteLine("Введите число");

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число");
            }
            
            return inputNumber;
        }
    }
}
