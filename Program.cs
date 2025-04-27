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
            string messageInput;
            int repetitionСounter;

            Console.Write("Введите строку для сообшения в консоли: ");
            messageInput = Console.ReadLine();

            Console.Write("Введите кол-во посторов сообщения: ");
            repetitionСounter = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < repetitionСounter; i++)
            {
                Console.WriteLine(messageInput);
            }
        }
    }
}
