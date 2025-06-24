namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> generalList = new List<int>();

            int[] differentNumbers1 = { 3, 9, 15, 6, 2, 9, 11, 1, 7, 2, 19, 4 };
            int[] differentNumbers2 = { 1, 2, 6, 4, 18, 19, 5, 7, 8, 10, 6, 15, 1 };

            AddUniqueNumbers(generalList, differentNumbers1);
            AddUniqueNumbers(generalList, differentNumbers2);

            Console.WriteLine("Обший не сортированный список");
            OutputList(generalList);

            generalList.Sort();

            Console.WriteLine("Обший отсортированный список");
            OutputList(generalList);
        }

        static void AddUniqueNumbers(List<int> generalList, int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (generalList.Contains(list[i]) == false)
                {
                    generalList.Add(list[i]);
                }
            }
        }

        static void OutputList(List<int> generalList)
        {
            foreach (var number in generalList)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}