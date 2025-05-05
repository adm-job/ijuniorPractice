using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberInputAll = new int[1];
            int[] numberTemp;
            int correction = 1;
            int sumNumber = 0;
            string numberInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Введите число \nСумма чисел - sum\nВыход - exit");
                numberInput = Console.ReadLine().ToLower();
                Console.Clear();

                if (numberInput == "exit")
                {
                    isExit = true;
                    continue;
                }
                else if (numberInput == "sum")
                {
                    Console.WriteLine($"Сумма введенных чисел: {sumNumber}\n");
                    continue;
                }
                else
                {
                    numberInputAll[numberInputAll.Length - correction] = Convert.ToInt32(numberInput);

                    foreach (int number in numberInputAll)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine("\n");
                    numberTemp = new int[numberInputAll.Length + correction];
                    sumNumber += numberInputAll[numberInputAll.Length - correction];

                    for (int i = 0; i < numberInputAll.Length; i++)
                    {
                        numberTemp[i] = numberInputAll[i];
                    }

                    numberInputAll = numberTemp;
                }
            }
        }
    }
}