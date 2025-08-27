using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            Player player = new Player();

            dealer.ShuffleDeck();

            player.AcceptСards(dealer.ReturnCards());

            player.ShowCards();
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
        private Queue<Card> _cards = new Queue<Card>();

        private Random _random = new Random();

        private List<Card> Fill()
        {
            List<string> suitsCard = new List<string> { "♥", "♣", "♠", "♦" };
            List<string> namesCard = new List<string> { "6", "7", "8", "9", "10", "V", "D", "K", "A" };

            List<Card> cards = new List<Card>();

            foreach (var name in namesCard)
            {
                foreach (var suits in suitsCard)
                {
                    cards.Add(new Card(name, suits));
                }
            }

            return cards;
        }

        public void Shuffle()
        {
            List<Card> cards = Fill();

            int totalMaps = cards.Count();

            Console.WriteLine("Дилер перемешивает карты в колоде");

            for (int sequentialIndex = 0; sequentialIndex < totalMaps; sequentialIndex++)
            {
                int randomIndex = _random.Next(sequentialIndex, cards.Count);
                (cards[sequentialIndex], cards[randomIndex]) = (cards[randomIndex], cards[sequentialIndex]);
            }

            _cards = new Queue<Card>(cards);
        }

        public Card GiveCard()
        {
            return _cards.Dequeue();
        }

        public int CardLeft()
        {
            return _cards.Count();
        }
    }

    class Dealer
    {
        private Deck _deck = new Deck();

        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }

        public List<Card> ReturnCards()
        {
            int count = 0;
            int maxMaps = _deck.CardLeft();

            Console.WriteLine($"Какое кол-во карт из колоды в карт отдать?");

            count = ReadInt(maxMaps);

            List<Card> cardList = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                cardList.Add(_deck.GiveCard());
            }

            return cardList;



        }
        private int ReadInt(int maxMaps)
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxMaps)
            {
                Console.Clear();
                Console.WriteLine($"Введено не верное значение карт всего {maxMaps}");
            }

            return inputNumber;
        }
    }

    class Player
    {
        private List<Card> Cards = new List<Card>();

        public void AcceptСards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Cards.Add(cards[i]);
            }
        }

        public void ShowCards()
        {
            Console.Write("Карты в руке игрока:\n ");

            foreach (var card in Cards)
            {
                Console.Write(card.Name + card.Suit + " ");
            }
            Console.WriteLine();
        }
    }
}


