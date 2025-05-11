using System;
using static System.Net.Mime.MediaTypeNames;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] parenthesis;
            string inputParenthesis;
            int countLeftParenthesis = 0;
            int countRightParenthesis = 0;
            int countDepth = 0;
            int depth = 0;
            string errorMessage = "Не корректное скобочное выражение";
            bool iserrorMessage = false;

            Console.Write("Введите скобочное выражение: ");
            inputParenthesis = Console.ReadLine();
            parenthesis = inputParenthesis.ToCharArray();

            if (parenthesis.Length % 2 == 0)
            {

                foreach (var charSplit in parenthesis)
                {
                    if (charSplit == '(')
                    {
                        countLeftParenthesis++;
                        countDepth++;

                        if (countDepth > depth)
                        {
                            depth = countDepth;
                        }
                    }
                    else if (charSplit == ')')
                    {
                        countRightParenthesis++;
                        countDepth--;
                    }

                    if (countLeftParenthesis < countRightParenthesis)
                    {
                        Console.WriteLine(errorMessage);
                        iserrorMessage = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
                iserrorMessage = true;
            }

            if (iserrorMessage)
            {
                Console.WriteLine($"Глубина вложения {depth}");
            }

        }
    }
}
