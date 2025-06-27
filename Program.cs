namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(1, "Benn", 55, false);
            Console.WriteLine(player.PlayerID);
            Console.WriteLine(player.Name);
            Console.WriteLine(player.PlayerLvl);
            Console.WriteLine(player.IsBanned);

            const string comandAddPlayer = "Добавить нового игрока в базу";
            const string comandShowAllPlayers = "Показать всех игроков в базе";
            const string comandRemovePlayer = "Удаление игрока из базы";
            const string comandbannedPlayer = "Забанить игрока";
            const string comandExit = "Выход";

            string inputUser;

            do
            {
                inputUser = Console.ReadLine();

                switch (player)
                {

                }

            }
            while (inputUser != comandExit);


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
        public bool IsBanned { get; private set; }
    }

}