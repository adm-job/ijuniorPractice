using System;

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
            Random randomIndex = new Random();
            int randomIndexArray1 = -1;
            int randomIndexArray2 = -1;

            for (int i = 0; i < array.Length; i++)
            {
                randomIndexArray1 = randomIndex.Next(0, array.Length);
                randomIndexArray2 = randomIndex.Next(0, array.Length);

                while (randomIndexArray1 == randomIndexArray2)
                {
                    randomIndexArray1 = randomIndex.Next(0, array.Length);
                    randomIndexArray2 = randomIndex.Next(0, array.Length);
                }
                (array[randomIndexArray1], array[randomIndexArray2]) = (array[randomIndexArray2], array[randomIndexArray1]);
            }
        }
    }
}



