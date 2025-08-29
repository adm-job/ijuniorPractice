using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            Player player = new Player();
            Menu menu = new(dealer, player);

            dealer.ShuffleDeck();

            menu.Run();
        }
    }
    class Menu
    {
        private Dealer _dealer;
        private Player _player;
        private bool _isRunMenu = true;

        public Menu(Dealer dealer, Player player)
        {
            _dealer = dealer;
            _player = player;
        }

        public void Run()
        {
            const string IssueСards = "1" ;
            const string ShowCards = "2" ;
            const string Exit = "3" ;

            while (_isRunMenu)
            {
                Console.WriteLine("\nМеню программы");
                Console.WriteLine($"{IssueСards}. Выдать несколько карт игроку");
                Console.WriteLine($"{ShowCards}. Игрок покажет свои карты");
                Console.WriteLine($"{Exit}. Выход");
                Console.WriteLine("Введите номер пункта меню");

                string input = Console.ReadLine();

                switch (input)
                {
                    case IssueСards:
                        _player.AcceptСards(_dealer.ReturnCards());
                        break;
                    case ShowCards:
                        _player.ShowCards();
                        break;
                    case Exit:
                        _isRunMenu = false;
                        break;
                    default:
                        Console.WriteLine($"Пункта под номером {input} не существует");
                        break;
                }
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
        private Random _random = new Random();

        public Queue<Card> Cards { get; private set; } = new();

        public void Shuffle()
        {
            List<Card> cards = Fill();

            int totalMaps = cards.Count();

            for (int i = totalMaps - 1; i > 0; i--)
            {
                int randomIndex = _random.Next(0, i + 1);
                (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
            }

            Cards = new Queue<Card>(cards);
        }

        public Card GiveCard()
        {
            return Cards.Dequeue();
        }

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
    }

    class Dealer
    {
        private Deck _deck = new();

        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }

        public List<Card> ReturnCards()
        {
            int count = 0;
            int maxMaps = _deck.Cards.Count;

            Console.WriteLine("Введите кол=во карт");

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
                Console.WriteLine($"Введено не верное значение карт всего {maxMaps}");
            }

            return inputNumber;
        }
    }

    class Player
    {
        private List<Card> _cards = new();

        public void AcceptСards(List<Card> cards)
        {
            _cards = cards;
        }

        public void ShowCards()
        {
            Console.Write("Карты в руке игрока:\n ");

            foreach (var card in _cards)
            {
                Console.Write(card.Name + card.Suit + " ");
            }
            Console.WriteLine();
        }
    }
}