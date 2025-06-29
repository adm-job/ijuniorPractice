using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> PlayerBase = new List<Player>();

            const string commandAddPlayer = "1";
            const string commandShowAllPlayers = "2";
            const string commandRemovePlayer = "3";
            const string commandBannedPlayer = "4";
            const string commandExit = "5";

            string inputUser;

            do
            {
                Console.Clear();
                Console.WriteLine(commandAddPlayer + " Добавить нового игрока в базу");
                Console.WriteLine(commandShowAllPlayers + " Показать всех игроков в базе");
                Console.WriteLine(commandRemovePlayer + " Удаление игрока из базы");
                Console.WriteLine(commandBannedPlayer + " Забанить игрока");
                Console.WriteLine(commandExit + " Выход" + "\n");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case commandAddPlayer:
                        AddPlayer(PlayerBase);
                        break;

                    case commandShowAllPlayers:
                        ShowPlayer(PlayerBase);
                        break;

                    case commandRemovePlayer:
                        DeletePlayer(PlayerBase);
                        break;

                    case commandBannedPlayer:
                        BannedPlayer(PlayerBase);
                        break;

                    case commandExit:
                        Console.WriteLine($"Программа завершила работу");
                        break;

                    default:
                        Console.WriteLine("Данного пункта в меню нет");
                        break;
                }

                Console.ReadKey();
            }
            while (inputUser != commandExit);
        }

        static void AddPlayer(List<Player> PlayerBase)
        {
            int playerId = 0;
            string name = "";
            int playerLvl = 0;
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

            Console.WriteLine("ВВедите лвл игрока");
            playerLvl = Convert.ToInt32(Console.ReadLine());

            Player newPlayer = new Player(playerId, name, playerLvl, isBanned);

            PlayerBase.Add(newPlayer);
        }

        static void ShowPlayer(List<Player> playerBase)
        {
            for (int i = 0; i < playerBase.Count; i++)
            {
                Console.Write(playerBase[i].PlayerID + ": ");
                Console.Write("Имя: " + playerBase[i].Name + "\t\t\t");
                Console.Write("Уровень: " + playerBase[i].PlayerLvl + "\t\t");
                Console.Write("Забанен: " + (playerBase[i].IsBanned ? "Да" : "Нет") + "\t");
                Console.WriteLine();
            }
        }

        static void DeletePlayer(List<Player> playerBase)
        {
            ShowPlayer(playerBase);

            int inputPlayerId;

            Console.WriteLine("Введите номер игрока для удаления");
            inputPlayerId = Convert.ToInt32(Console.ReadLine()) - 1;

            playerBase.RemoveAt(inputPlayerId);
        }

        static void BannedPlayer(List<Player> playerBase)
        {
            ShowPlayer(playerBase);

            int inputPlayerId;

            Console.WriteLine("Введите номер игрока чтобы забанить или разбанить игрока");
            inputPlayerId = Convert.ToInt32(Console.ReadLine());
            
            Player selectedPlayer = playerBase[inputPlayerId - 1];

            if (selectedPlayer.IsBanned)
            {
                selectedPlayer.IsBanned = false;
            }
            else
            {
                selectedPlayer.IsBanned = true;
            }
        }
    }

    class Player
    {
        public Player(int playerID, string name, int playerLvl, bool isBanned)
        {
            PlayerID = playerID;
            Name = name;
            PlayerLvl = playerLvl;
            IsBanned = isBanned;
        }

        public int PlayerID { get; private set; }
        public string Name { get; private set; }
        public int PlayerLvl { get; private set; }
        public bool IsBanned { get; set; }
    }
}

