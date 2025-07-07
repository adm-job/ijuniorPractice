namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddPlayer = "1";
            const string CommandShowAllPlayers = "2";
            const string CommandRemovePlayer = "3";
            const string CommandBanPlayer = "4";
            const string CommandUnbanPlayer = "5";
            const string CommandExit = "6";

            Database database = new Database();

            string inputUser;

            do
            {
                Console.Clear();
                Console.WriteLine(CommandAddPlayer + " Добавить нового игрока в базу");
                Console.WriteLine(CommandShowAllPlayers + " Показать всех игроков в базе");
                Console.WriteLine(CommandRemovePlayer + " Удаление игрока из базы");
                Console.WriteLine(CommandBanPlayer + " Забанить игрока");
                Console.WriteLine(CommandUnbanPlayer + " Разбанить игрока");
                Console.WriteLine(CommandExit + " Выход" + "\n");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddPlayer:
                        database.AddPlayer();
                        break;

                    case CommandShowAllPlayers:
                        database.ShowPlayers();
                        break;

                    case CommandRemovePlayer:
                        database.DeletePlayer();
                        break;

                    case CommandBanPlayer:
                        database.BanPlayer();
                        break;

                    case CommandUnbanPlayer:
                        database.UnbanPlayer();
                        break;

                    case CommandExit:
                        Console.WriteLine($"Программа завершила работу");
                        break;

                    default:
                        Console.WriteLine("Данного пункта в меню нет");
                        break;
                }

                Console.ReadKey();
            }
            while (inputUser != CommandExit);
        }
    }

    class Player
    {
        public Player() { }

        public Player(int identifier, string name, int level, bool isBanned)
        {
            Identifier = identifier;
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public int Identifier { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
            Console.WriteLine("Игрок забанен");
        }

        public void Unban()
        {
            IsBanned = false;
            Console.WriteLine("Игрок разбанен");
        }

        public void Show()
        {
            Console.Write("ID: " + Identifier + "\t\t");
            Console.Write("Имя: " + Name + "\t\t\t");
            Console.Write("Уровень: " + Level + "\t\t");
            Console.Write("Забанен: " + (IsBanned ? "Да" : "Нет") + "\t");
            Console.WriteLine();
        }
    }

    class Database
    {
        private int _identifierCounter = 1;

        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            int identifier = _identifierCounter;
            string name = "";
            int level = 0;
            bool isBanned = false;

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

            Console.WriteLine("Введите лвл игрока");
            level = ReadInt();

            Player player = new Player(identifier, name, level, isBanned);
            _identifierCounter++;

            _players.Add(player);
        }

        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                player.Show();
            }
        }

        public void DeletePlayer()
        {
            ShowPlayers();

            Console.WriteLine("\nДля удаления");
            Player player = SerchPlayer();

            _players.Remove(player);
        }

        public void BanPlayer()
        {
            ShowPlayers();

            Console.WriteLine("\nДля бана");
            Player player = SerchPlayer();
            player.Ban();
        }

        public void UnbanPlayer()
        {
            ShowPlayers();

            Console.WriteLine("\nДля разбана");
            Player player = SerchPlayer();
            player.Unban();
        }

        private int ReadInt()
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число");
            }

            return inputNumber;
        }

        private Player SerchPlayer()
        {
            //player = _players.Find(player => player.Identifier == inputPlayerId);
            Player player;
            if (TryGetPlayer(out player) == null)
            {
                Console.WriteLine("Такого игрока нет");
            }

            return player;
        }

        private bool TryGetPlayer(out Player player)
        {
            int inputPlayerId;
            player = null;

            Console.WriteLine("Введите ID игрока");
            inputPlayerId = ReadInt();

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Identifier == inputPlayerId)
                {
                    player = _players[i];
                }
            }

            return player != null;
        }
    }
}

