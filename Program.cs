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
            int addNameCharacters = 2;

            Console.Write("Введите символ для рамки: ");
            inputChar = Convert.ToChar(Console.ReadLine());

            Console.Write("Введите ваше имя: ");
            inputName = Console.ReadLine();

            for (int i = 0; i < inputName.Length + addNameCharacters; i++)
            {
                Console.Write(inputChar);
            }

            Console.WriteLine("\n" + inputChar + inputName + inputChar);

            for (int i = 0; i < inputName.Length + addNameCharacters; i++)
            {
                Console.Write(inputChar);
            }

        }
    }
}
