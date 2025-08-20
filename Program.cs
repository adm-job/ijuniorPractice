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

            Console.Clear();

            player.AcceptСards(dealer.ReturnCards());

            player.ShowCards();
        }
    }

    class InputUser
    {

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

        public List<Card> ReturnCards()
        {
            int count = 0;
            int maxMaps = _deck.TotalMaps();

            Console.WriteLine($"Какое кол-во карт из колоды в карт отдать?");

            count = ReadInt(maxMaps);

            List<Card> cardList = new List<Card>();
            
            for (int i = 0; i < count; i++)
            {
                cardList.Add(_deck.ReturnOneCard());
            }

            return cardList;
            

            static int ReadInt(int maxMaps)
            {
                int inputNumber;

                while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxMaps)
                {
                    Console.WriteLine($"Введено не верное значение карт всего {maxMaps}");
                }

                return inputNumber;
            }
        }
    }

    class Player
    {
        private List<Card> CardsYourHand = new List<Card>();

        public void AcceptСards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                CardsYourHand.Add(cards[i]);
            }
        }

        public void ShowCards()
        {
            Console.Write("Карты в руке игрока: ");

            foreach (var card in CardsYourHand)
            {
                Console.Write(card.Name + card.Suit + " ");
            }
        }
    }
}


