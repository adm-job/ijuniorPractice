using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> amountBuyersReceipt = new Queue<int>();
            int sumAllBuyers = 0;

            amountBuyersReceipt = FillingQueue();

            while(amountBuyersReceipt.Count > 0)
            {
                Console.Clear();
                sumAllBuyers += amountBuyersReceipt.Peek();
                Console.WriteLine($"Сумма покупки: {amountBuyersReceipt.Dequeue()}");
                Console.WriteLine($"Всего на счету: {sumAllBuyers}\n");
                Console.WriteLine("нажмите любую клавишу");
                Console.ReadKey();
            }
        }

        static Queue<int> FillingQueue()
        {
            Random random = new Random();
            Queue<int> amountBuyersReceipt = new Queue<int>();

            int minQueueSize = 15;
            int maxQueueSize = 25;
            int minAmount = 100;
            int maxAmount = 1000;

            int queueSize = random.Next(minQueueSize, maxQueueSize + 1);

            for (int i = 0; i < queueSize; i++)
            {
                amountBuyersReceipt.Enqueue(random.Next(minAmount, maxAmount));
            }

            return amountBuyersReceipt;
        }
    }
}