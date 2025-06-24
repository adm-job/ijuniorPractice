namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();

            player1.Name = "Иван";
            player1.Description = "Заядлый игрок";

            player2.Name = "Сергей";
            player2.Description = "Начинающий";

            player1.ShowInfo();
            player2.ShowInfo();

        }


    }
    class Player
    {
        public string Name;
        public string Description;

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}");
            Console.WriteLine($"Описание игрока - {Description}");
        }
    }
}