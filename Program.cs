using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> amountBuyersReceipt = new Queue<int>();
            int sumAllBuyers = 0;

            amountBuyersReceipt = RandomAmountChecks();

            foreach (int purchaseAmount in amountBuyersReceipt)
            {
                Console.Clear();
                Console.WriteLine($"Сумма покупки: {purchaseAmount}");
                sumAllBuyers += purchaseAmount;
                Console.WriteLine($"Всего на счету: {sumAllBuyers}\n");
                Console.WriteLine("нажмите любую клавишу");
                Console.ReadKey(); 
            }
        }
        static Queue<int> RandomAmountChecks()
        {
            Random randomInteger = new Random();
            Queue<int> amountBuyersReceipt = new Queue<int>();

            int queueSize = randomInteger.Next(15, 25);


            for (int i = 0; i < queueSize; i++)
            {
                amountBuyersReceipt.Enqueue(randomInteger.Next(100, 1000));
            }

            return amountBuyersReceipt;
        }
    }
}



