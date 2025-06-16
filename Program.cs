using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            List<int> numberList = new List<int>();
            int sumNumber = 0;
            string comandInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine($"Введите число \nСумма чисел - {CommandSum}\nВыход - {CommandExit}");
                comandInput = ReadInput();
                Console.Clear();

                switch (comandInput)
                {
                    case CommandExit:
                        isExit = true;
                        break;
                    case CommandSum:
                        Console.WriteLine($"Сумма введенных чисел: {sumNumber}\n");
                        break;

                    default:
                        numberList.Add(Convert.ToInt32(comandInput));
                        sumNumber += Convert.ToInt32(comandInput);

                        foreach (int number in numberList)
                        {
                            Console.Write(number + " ");
                        }

                        Console.WriteLine("\n");
                        break;
                }
            }

            static string ReadInput()
            {
                string input = "";
                bool isCheck = true;

                while (isCheck)
                {
                    input = Console.ReadLine();

                    if (int.TryParse(input, out _) || input == "sum" || input == "exit")
                    {
                        isCheck = false;
                    }
                    else
                    {
                        Console.WriteLine("Не верный ввод");
                    }
                }
                return input;
            }
        }
    }
}
