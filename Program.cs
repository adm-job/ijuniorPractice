using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberInput = new int[1];
            int[] numberTemp;
            int correction = 1;
            int sumNumber = 0;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Введите число \nСумма введенных чисел sum\nexit");
                numberInput[numberInput.Length - correction] = Convert.ToInt32(Console.ReadLine());
                numberTemp = new int[numberInput.Length + correction];

                for (int i = 0; i < numberInput.Length; i++)
                {
                    numberTemp[i] = numberInput[i];
                }

                numberInput = numberTemp;

                for (int i = 0; i < numberInput.Length; i++)
                {
                    Console.Write(numberInput[i] + " ");
                }
            }

        }
    }
}