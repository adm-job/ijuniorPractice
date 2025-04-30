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
            string password = "123321";
            string inputUser;
            int inputAttempts = 3;

            while (inputAttempts-- > 0)
            {
                Console.Write("Введите пароль: ");
                inputUser = Console.ReadLine();

                if (inputUser == password)
                {
                    Console.WriteLine("Password successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Password error");
                }
            }
            if (inputAttempts < 0)
            {
                Console.WriteLine("There are no more attempts");
            }

        }
    }
}