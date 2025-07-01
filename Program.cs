using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddPlayer = "1";
            const string CommandShowAllPlayers = "2";
            const string CommandRemovePlayer = "3";
            const string CommandBannedPlayer = "4";
            const string CommandExit = "5";

            List<Player> PlayerBase = new List<Player>();

            string inputUser;

            do
            {
                Console.Clear();
                Console.WriteLine(CommandAddPlayer + " Добавить нового игрока в базу");
                Console.WriteLine(CommandShowAllPlayers + " Показать всех игроков в базе");
                Console.WriteLine(CommandRemovePlayer + " Удаление игрока из базы");
                Console.WriteLine(CommandBannedPlayer + " Забанить игрока");
                Console.WriteLine(CommandExit + " Выход" + "\n");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddPlayer:
                        AddPlayer(PlayerBase);
                        break;

                    case CommandShowAllPlayers:
                        ShowPlayer(PlayerBase);
                        break;

                    case CommandRemovePlayer:
                        DeletePlayer(PlayerBase);
                        break;

                    case CommandBannedPlayer:
                        BannedPlayer(PlayerBase);
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

        static void AddPlayer(List<Player> PlayerBase)
        {
            int playerId = 0;
            string name = "";
            int level = 0;
            bool isBanned = false;

            if (PlayerBase.Count > 0)
            {
                playerId = PlayerBase.Count + 1;
            }
            else
            {
                playerId++;
            }

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

            Console.WriteLine("Введите лвл игрока");
            level = ReadInt();

            Player newPlayer = new Player(playerId, name, level, isBanned);

            PlayerBase.Add(newPlayer);
        }

        static void ShowPlayer(List<Player> playerBase)
        {
            foreach (var player in playerBase)
            {
                player.ShowThis();
            }
        }

        static void DeletePlayer(List<Player> playerBase)
        {
            ShowPlayer(playerBase);

            int inputPlayerId;

            do
            {
                Console.WriteLine("Введите номер игрока для удаления");
                inputPlayerId = ReadInt();
            }
            while (inputPlayerId <= 0 || inputPlayerId > playerBase.Count);

            playerBase.RemoveAt(inputPlayerId - 1);
        }

        static void BannedPlayer(List<Player> playerBase)
        {
            ShowPlayer(playerBase);

            int inputPlayerId;

            do
            {
                Console.WriteLine("Введите номер игрока чтобы забанить или разбанить игрока");
                inputPlayerId = ReadInt();
            }
            while (inputPlayerId <= 0 || inputPlayerId > playerBase.Count);

            playerBase[inputPlayerId - 1].Banned();
        }

        static int ReadInt()
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число");
            }

            return inputNumber;
        }
    }

    class Player
    {
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

        public void Banned()
        {
            if (IsBanned)
                IsBanned = false;
            else
                IsBanned = true;
        }

        public void ShowThis()
        {
            Console.Write(Identifier + ": ");
            Console.Write("Имя: " + Name + "\t\t\t");
            Console.Write("Уровень: " + Level + "\t\t");
            Console.Write("Забанен: " + (IsBanned ? "Да" : "Нет") + "\t");
            Console.WriteLine();
        }
    }
}

