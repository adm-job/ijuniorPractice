using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 1, 22, 31, 4, 7, 16, 17, 8, 2, 10, 1, 15, 10, 14, 3, 17, 5, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0 && number[i] > number[i + 1])
                {
                    Console.Write(number[i] + " ");
                }
                else if (i == number.Length - 1 && number[i] > number[i - 1])
                {
                    Console.Write(number[i] + " ");
                }
                else if (number[i] > number[i + 1] && number[i] > number[i - 1])
                {
                    Console.Write(number[i] + " ");
                }
            }
        }
    }
}