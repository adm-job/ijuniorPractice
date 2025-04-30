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
            char inputChar;
            string inputName;

            Console.Write("Введите символ для рамки: ");
            inputChar = Convert.ToChar(Console.ReadLine());

            Console.Write("Введите ваше имя: ");
            inputName = Console.ReadLine();

            for (int i = 0; i < inputName.Length + 2; i++)
            {
                Console.Write(inputChar);
            }

            Console.WriteLine("\n" + inputChar + inputName + inputChar);

            for (int i = 0; i < inputName.Length + 2; i++)
            {
                Console.Write(inputChar);
            }

        }
    }
}
