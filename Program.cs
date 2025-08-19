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
            while (totalPlayingCards < totalMaps  && totalPlayingCards <= 0);


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
        private Queue<Card> _allCards = new Queue<Card>();

        private Random _random = new Random();

        public Queue<Card> AllCards { get; private set; }

        public List<Card> Fill()
        {
            AllCards = _allCards;

            List<string> suitsCard = new List<string> { "♥", "♣", "♠", "♦" };
            List<string> namesCard = new List<string> { "6", "7", "8", "9", "10", "V", "D", "K", "A" };

            List<Card> cards = new List<Card>();

            for (int i = 0; i < suitsCard.Count; i++)
            {
                for (int j = 0; j < namesCard.Count; j++)
                {
                    Card card = new Card(namesCard[j], suitsCard[i]);
                    cards.Add(card);
                }
            }

            return cards;
        }

        public Queue<Card> Shuffle()
        {
            List<Card> cards = Fill();

            int totalMaps = cards.Count();

            for (int i = 0; i < totalMaps; i++)
            {
                Card gameCard = cards[_random.Next(cards.Count)];
                cards.Remove(gameCard);
                _allCards.Enqueue(gameCard);
            }

            return AllCards;
        }

         public Card ReturnOneCard()
        {
            return AllCards.Dequeue();
        }

        public int TotalMaps()
        {
            return AllCards.Count;
        }
    }

    class Dealer
    {
        private Deck _deck = new Deck();

        public void TakeDeck()
        {
            _deck.Shuffle();
        }

        public Card ReturnOneCard()
        {
            return _deck.ReturnOneCard();
        }

        public int CheckingQuantity()
        {
            return _deck.TotalMaps();
        }
    }

    class Player
    {
        private List<Card> CardsYourHand = new List<Card>();

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


