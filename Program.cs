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
            char LeftParenthesis = '(';
            char RightParenthesis = ')';
            int countDepth = 0;
            int depth = 0;
            string errorMessage = "Не корректное скобочное выражение";
            bool isErrorMessage = false;

            Console.Write("Введите скобочное выражение: ");
            inputParenthesis = Console.ReadLine();
            parenthesis = inputParenthesis.ToCharArray();

            if (parenthesis.Length % 2 == 0)
            {

                foreach (var charSplit in parenthesis)
                {
                    if (charSplit == LeftParenthesis)
                    {
                        countLeftParenthesis++;
                        countDepth++;

                        if (countDepth > depth)
                        {
                            depth = countDepth;
                        }
                    }
                    else if (charSplit == RightParenthesis)
                    {
                        countRightParenthesis++;
                        countDepth--;
                    }

                    if (countLeftParenthesis < countRightParenthesis)
                    {
                        Console.WriteLine(errorMessage);
                        isErrorMessage = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine(errorMessage);
                isErrorMessage = true;
            }

            if (isErrorMessage == false)
            {
                Console.WriteLine($"Глубина вложения {depth}");
            }
        }
    }
}
