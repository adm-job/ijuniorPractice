using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            dealer.TakeDeck();

            Player player = new Player();

            int totalPlayingCards = 0;
            int totalMaps = dealer.CheckingQuantity();

            Console.Clear();

            do
            {
                Console.WriteLine($"Какое кол-во карт из колоды в {totalMaps} карт отдать?");
                totalPlayingCards = ReadInt();
            }
            while (totalMaps < totalPlayingCards);
            

            Console.WriteLine($"\nВыдано карт игроку {totalPlayingCards}\n");

            for (int i = 0; i < totalPlayingCards; i++)
            {
                
                player.AcceptСard(dealer.ReturnOneCard());
            }

            player.ShowCardYouHandle();


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
    }

    class Card
    {
        public Card(string name, string suit)
        {
            Name = name;
            Suit = suit;
        }

        public string Name { get; private set; }
        public string Suit { get; private set; }

    }

    class Deck
    {
        private List<string> _suits = new List<string> { "♥", "♣", "♠", "♦" };
        private List<string> _names = new List<string> { "6", "7", "8", "9", "10", "V", "D", "K", "A" };

        private Queue<Card> _deck = new Queue<Card>();

        private Random _random = new Random();

        public List<Card> Take()
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < _suits.Count; i++)
            {
                for (int j = 0; j < _names.Count; j++)
                {
                    Card card = new Card(_names[j], _suits[i]);
                    cards.Add(card);
                }
            }

            return cards;
        }

        public Queue<Card> Shuffle()
        {
            List<Card> cards = Take();
            int totalMaps = cards.Count();

            for (int i = 0; i < totalMaps; i++)
            {
                Card gameCard = cards[_random.Next(cards.Count)];
                cards.Remove(gameCard);
                _deck.Enqueue(gameCard);
            }

            return _deck;
        }

        public Queue<Card> Return()
        {
            return _deck;
        }


    }

    class Dealer
    {
        private Deck _deck = new Deck();

        Queue<Card> playingDecks = new Queue<Card>();

        public void TakeDeck()
        {
            playingDecks = _deck.Shuffle();
        }

        public Card ReturnOneCard()
        {
            return playingDecks.Dequeue();
        }

        public int CheckingQuantity()
        {
            return playingDecks.Count;
        }

    }

    class Player
    {
        List<Card> CardsYourHand = new List<Card>();

        public void AcceptСard(Card card)
        {
            CardsYourHand.Add(card);
        }

        public void ShowCardYouHandle()
        {
            Console.Write("Карты в руке игрока: ");

            foreach (var card in CardsYourHand)
            {
                Console.Write(card.Name + card.Suit + " ");
            }
        }
    }
}


