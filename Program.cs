using System.Threading.Channels;

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

            //Database database = new Database();

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
                        break;

                    case CommandShowAllPlayers:
                        break;

                    case CommandRemovePlayer:
                        break;

                    case CommandBanPlayer:
                        break;

                    case CommandUnbanPlayer:
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

    class PlayingCard
    {
        public PlayingCard(string name)
        {
            Name = name;

        }

        public string Name { get; private set; }

    }

    class PlayingDeck
    {
        private List<string> Cards = new List<string>
                                        { "6♥", "7♥","8♥","9♥","10♥","V♥","D♥","K♥","A♥",
                                        "6♣","7♣","8♣","9♣","10♣","V♣","D♣","K♣","A♣",
                                        "6♠","7♠","8♠","9♠","10♠","V♠","D♠","K♠","A♠",
                                        "6♦","7♦","8♦","9♦","10♦","V♦","D♦","K♦","A♦" };

        private Queue<PlayingCard> _deck = new Queue<PlayingCard>();

        public void AddDesc()
        {
            Random random = new Random();


        }
    }

}


