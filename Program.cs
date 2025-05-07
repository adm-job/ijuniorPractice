using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 2, 3, 1, 5, 6, 7, 8, 9, 19, 12, 14, 11, 10, 4, 16, 26, 36, 8, 9, 16, 6, 27, 7, 17, 16, 6, 31, 14, 22, 41, 12, 2, 25, 19, 16, 29, 19 };
            bool isSorted = true;
            int correction = 1;

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            while (isSorted)
            {
                isSorted = false;

                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] < numbers[i - correction])
                    {
                        (numbers[i], numbers[i - correction]) = (numbers[i - correction], numbers[i]);
                        isSorted = true;
                    }
                }
            }

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
