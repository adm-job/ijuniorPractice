using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberAll = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 1, 1, 1, 1, 1, 4, 6, 6, 6, 6, 7, 8, 9, 9, 6, 6, 7, 7, 7, 6, 6, 3, 4, 2, 4, 2, 2, 2, 9, 9, 9, 0, 8, 6, 4, 3, 2, 1, 1, 2, 3, 3, 3, 4, 5, 6, 7, 8, 6, 6, 6, 7, 9 };
            int numberTemp = numberAll[0];
            int numbersCount = 1;
            int basicValue = 1;
            int numberFound = 0;
            int numbersTotal = 0;

            for (int i = 1; i < numberAll.Length; i++)
            {
                if (numberAll[i] == numberTemp)
                {
                    numbersCount++;
                }
                else
                {
                    if (numbersTotal < numbersCount)
                    {
                        numberFound = numberTemp;
                        numbersTotal = numbersCount;
                        numberTemp = numberAll[i];
                        numbersCount = basicValue;
                    }
                    else
                    {
                        numberTemp = numberAll[i];
                        numbersCount = basicValue;
                    }
                }
            }

            Console.WriteLine($"Число {numberFound} повторяется {numbersTotal} раза подряд.");
        }
    }
}
