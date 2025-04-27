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
            Random random = new Random();
            int number;
            int sumNumbers = 0;
            number = random.Next(1,101);

            for (int i = 1; i <= number; i++) 
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                { 
                    sumNumbers += i;
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\nВыпавешее сисло " + number);
            Console.WriteLine($"Сумма чисел кратные 3 или 5 равна {sumNumbers}");
        }
    }
}
