using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck desc = new Deck();
            desc.Shuffle();
            Player player = new Player();

            int totalPlayingCards = 0;

            Console.Clear();
            Console.WriteLine("Какое кол-во карт добавить ?");

            totalPlayingCards = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nВыдано карт игроку {totalPlayingCards}\n");

            for (int i = 0; i < totalPlayingCards; i++)
            {
                player.AcceptСard(desc.ReturnOneCard());
            }

            player.ShowCardYouHandle();

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
        //private List<string> _cards = new List<string>;
        private List<string> _suits = new List<string> { "♥","♣","♠","♦"};
        private List<string> _names = new List<string> { "6", "7", "8", "9", "10", "V", "D", "K", "A" };

        private Queue<Card> _deck = new Queue<Card>();

        public void Shuffle()
        {
            Random random = new Random();

            List<string> cards = new List<string>(_cards);


            for (int i = 0; i < _cards.Count; i++)
            {
                string gameCard = cards[random.Next(cards.Count)];
                Card card = new Card(gameCard);
                cards.Remove(gameCard);
                _deck.Enqueue(card);
            }
        }

        public Queue<Card> Return()
        {
            return _deck;
        }

        public Card ReturnOneCard()
        {
            return _deck.Dequeue();
        }
    }

    class Dealer
    {
        Deck deck = new Deck();

        Queue<Card> playingDecks = new Queue<Card>();

        public void TakeDeck()
        {
            deck.Shuffle();
            playingDecks = deck.Return();
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
                Console.Write(card.Name + " ");
            }
        }
    }
}


