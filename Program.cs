using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddCards = "1";
            const string CommandShowCards = "2";
            const string CommandExit = "3";

            PlayingDeck desc = new PlayingDeck();

            string inputUser;

            do
            {
                Console.Clear();
                Console.WriteLine(CommandAddCards + "Какое кол-во карт добавить ?");
                Console.WriteLine(CommandShowCards + " Показать карту");

                Console.WriteLine(CommandExit + " Выход" + "\n");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddCards:
                        desc.ShuffleDeck();
                        break;

                    case CommandShowCards:
                        desc.ShowAllCards();
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
        private List<string> _cards = new List<string>
                                        { "6♥", "7♥", "8♥", "9♥", "10♥", "V♥", "D♥", "K♥", "A♥",
                                          "6♣", "7♣", "8♣", "9♣", "10♣", "V♣", "D♣", "K♣", "A♣",
                                          "6♠", "7♠", "8♠", "9♠", "10♠", "V♠", "D♠", "K♠", "A♠",
                                          "6♦", "7♦", "8♦", "9♦", "10♦", "V♦", "D♦", "K♦", "A♦" };

        private Queue<PlayingCard> _deck = new Queue<PlayingCard>();



        public void ShuffleDeck()
        {
            Random random = new Random();

            List<string> cards = new List<string>(_cards);


            for (int i = 0; i < _cards.Count; i++)
            {
                string gameCard = cards[random.Next(cards.Count)];
                PlayingCard card = new PlayingCard(gameCard);
                cards.Remove(gameCard);
                _deck.Enqueue(card);
            }
        }

        public void ShowAllCards()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                Console.WriteLine(_deck.Dequeue().Name);
            }
        }

        public Queue<PlayingCard> ReturnDesc()
        {
            return _deck;
        }
    }

    class Dealer
    {
        PlayingDeck deck = new PlayingDeck();

        Queue<PlayingCard> playingDecks = new Queue<PlayingCard>();
        
        public void TakeDeck()
        {
            deck.ShuffleDeck();
            playingDecks = deck.ReturnDesc();
        }
    }

    class Player
    {
        List<PlayingCard> CardsYourHand = new List<PlayingCard>();

        public void AcceptСard()
        {

        }
    }

}


