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
        private string _name;
        private string _description;
        private int _gamesPlayed;

        public Player()
        {
            _name = "Пользователь";
            _description = "Безымянный пользователь";
            _gamesPlayed = 0;
        }

        public Player(string name, string description, int gamesPlayed)
        {
            _name = name;
            _description = description;

            if (gamesPlayed > 0)
            {
                _gamesPlayed = gamesPlayed;
            }
            else
            {
                gamesPlayed = 0;
                _gamesPlayed = gamesPlayed;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {_name}");
            Console.WriteLine($"Описание игрока - {_description}");
            Console.WriteLine($"Игр сыграно - {_gamesPlayed}\n");
        }
    }
}