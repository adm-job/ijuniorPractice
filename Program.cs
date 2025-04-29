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
            const string CommandRubToUsd = "1";
            const string CommandRubToEur = "2";
            const string CommandUsdToEur = "3";
            const string CommandEurToUsd = "4";
            const string CommandUsdToRub = "5";
            const string CommandEurToRub = "6";
            const string CommandExit = "7";

            float amountRub = 1000;
            float amountUsd = 100;
            float amountEur = 50;
            float rateRubToUsd = 90;
            float rateRubToEur = 100;
            float rateUsdToEur = 1.11f;
            float amountExchange;
            string inputComand;
            string errorMassage = "На счету нет такой суммы";

            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Пункт обмена открыт!");
                Console.WriteLine($"{CommandRubToUsd} Обмен RUB на USD");
                Console.WriteLine($"{CommandRubToEur} Обмен RUB на EUR");
                Console.WriteLine($"{CommandUsdToEur} Обмен USD на EUR");
                Console.WriteLine($"{CommandEurToUsd} Обмен EUR на USD");
                Console.WriteLine($"{CommandUsdToRub} Обмен USD на RUB");
                Console.WriteLine($"{CommandEurToRub} Обмен EUR на RUB");
                Console.WriteLine($"{CommandExit} Выход");
                Console.WriteLine($"\n RUB {amountRub} \t USD {amountUsd} \t EUR {amountEur}\n");

                Console.WriteLine("Введите операцию обмена");
                inputComand = Console.ReadLine();

                if ( inputComand == CommandExit )
                {
                    isOpen = false;
                    continue;
                }
                
                Console.WriteLine("Введите сумму для обмена");
                amountExchange = Convert.ToSingle(Console.ReadLine());

                switch (inputComand)
                {
                    case CommandRubToUsd:
                        if (amountExchange > amountRub)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountRub -= amountExchange;
                        amountUsd += amountExchange / rateRubToUsd;
                        break;
                    
                    case CommandRubToEur:
                        if (amountExchange > amountRub)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountRub -= amountExchange;
                        amountEur += amountExchange / rateRubToEur;
                        break;

                    case CommandUsdToEur:
                        if (amountExchange > amountUsd)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountUsd -= amountExchange;
                        amountEur += amountExchange / rateUsdToEur;
                        break;

                    case CommandEurToUsd:
                        if (amountExchange > amountEur)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountEur -= amountExchange;
                        amountUsd += amountExchange / rateUsdToEur;
                        break;

                    case CommandUsdToRub:
                        if (amountExchange > amountUsd)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountUsd -= amountExchange;
                        amountRub += amountExchange / rateRubToUsd;
                        break;

                    case CommandEurToRub:
                        if (amountExchange > amountEur)
                        {
                            Console.WriteLine(errorMassage);
                            break;
                        }

                        amountEur -= amountExchange;
                        amountRub += amountExchange / rateRubToEur;
                        break;

                }

            }

        }
    }
}
