namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Иван", "Заядлый игрок", 507);
            Player player2 = new Player("Сергей", "Начинающий", 5);
            Player player3 = new Player();

            player1.ShowInfo();
            player2.ShowInfo();
            player3.ShowInfo();
        }
    }

    class Player
    {
        public string Name;
        public string Description;
        public int GamesPlayed;

        public Player()
        {
            Name = "Пользователь";
            Description = "Безымянный пользователь";
            GamesPlayed = 0;
        }
        public Player(string name, string description, int gamesPlayed)
        {
            Name = name;
            Description = description;

            if (gamesPlayed > 0)
            {
                GamesPlayed = gamesPlayed;
            }
            else
            {
                gamesPlayed = 0;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}");
            Console.WriteLine($"Описание игрока - {Description}");
            Console.WriteLine($"Игр сыграно - {GamesPlayed}\n");
        }
    }
}