using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

            Console.WriteLine("Исходный массив");

            ArrayOutput(arrayNumbers);
            Shuffle(arrayNumbers);

            Console.WriteLine("Перемешанный массив");

            ArrayOutput(arrayNumbers);
        }

        static void ArrayOutput(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static void Shuffle(int[] array)
        {
            int indexArray1 = -1;
            int indexArray2 = -1;

            for (int i = 0; i < array.Length; i++)
            {
                indexArray1 = RandomIndex(array.Length);
                indexArray2 = RandomIndex(array.Length);

                while (indexArray1 == indexArray2)
                {
                    indexArray1 = RandomIndex(array.Length);
                    indexArray2 = RandomIndex(array.Length);
                }
                (array[indexArray1], array[indexArray2]) = (array[indexArray2], array[indexArray1]);
            }
        }

        static int RandomIndex(int maxIndex)
        {
            Random randomIndex = new Random();

            return randomIndex.Next(0, maxIndex);
        }
    }
}



