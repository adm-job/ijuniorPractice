using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowText = "1";
            const string CommandRandomNumber = "2";
            const string CommandClearConsole = "3";
            const string CommandExit = "4";

            int startRandomNumber = 0;
            int finisfRandomNumber = 1000;
            int numberRandom;
            string numberInput = "";

            Random random = new Random();

            while (numberInput != CommandExit)
            {
                Console.WriteLine("\nМеню");
                Console.WriteLine($"{CommandShowText}. Вывод текста на консоль");
                Console.WriteLine($"{CommandRandomNumber}. Вывод случайного числа от {startRandomNumber} до {finisfRandomNumber}");
                Console.WriteLine($"{CommandClearConsole}. Очистка консоли");
                Console.WriteLine($"{CommandExit}. Выход");
                Console.Write("Введите пункт меню: ");
                numberInput = Console.ReadLine();

                switch (numberInput)
                {
                    case CommandShowText:
                        Console.WriteLine("Просто бессмыссленный текст");
                        Console.WriteLine("Дополнительный текст к первому сообщению");
                        Console.WriteLine("=)");
                        break;
                    case CommandRandomNumber:
                        numberRandom = random.Next(startRandomNumber, finisfRandomNumber);
                        Console.WriteLine("" + numberRandom);
                        break;
                    case CommandClearConsole:
                        Console.Clear(); 
                        break;
                    case CommandExit:   
                        break;
                }

            }
            Console.WriteLine("До свидания");
        }
    }
}
