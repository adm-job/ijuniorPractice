namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber;

            GetInput(out inputNumber);
            Console.WriteLine(inputNumber);
        }

        static void GetInput(out int inputNumber)
        {
            Console.WriteLine("Введите число");

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)   
            {
                Console.WriteLine("Введено не число");
            }
        }
    }
}
