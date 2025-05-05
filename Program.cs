using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] numberInputAll = new int[0];
            int[] numberTemp;
            int correction = 1;
            int sumNumber = 0;
            string numberInput;
            bool isExit = false;

            while (isExit == false)
            {
                numberTemp = new int[numberInputAll.Length + correction];

                Console.WriteLine($"Введите число \nСумма чисел - {CommandSum}\nВыход - {CommandExit}");
                numberInput = Console.ReadLine().ToLower();
                Console.Clear();

                switch (numberInput)
                {
                    case CommandExit:
                        isExit = true;
                        break;

                    case CommandSum:
                        Console.WriteLine($"Сумма введенных чисел: {sumNumber}\n");
                        break;

                    default:
                        numberInputAll[numberInputAll.Length - correction] = Convert.ToInt32(numberInput);

                        foreach (int number in numberInputAll)
                        {
                            Console.Write(number + " ");
                        }

                        Console.WriteLine("\n");
                        sumNumber += numberInputAll[numberInputAll.Length - correction];

                        for (int i = 0; i < numberInputAll.Length; i++)
                        {
                            numberTemp[i] = numberInputAll[i];
                        }

                        numberInputAll = numberTemp;
                        break;
                }
            }
        }
    }
}
