using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayingDeck desc = new PlayingDeck();
            desc.ShuffleDeck();
            Player player = new Player();

            int totalPlayingCards = 0;

            Console.Clear();
            Console.WriteLine("Какое кол-во карт добавить ?");

            totalPlayingCards = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Выдано карт игроку {totalPlayingCards}\n");

            for (int i = 0; i < totalPlayingCards; i++)
            {
                player.AcceptСard(desc.ReturnOneCard());
            }

            player.ShowCardYouHandle();

            Console.WriteLine();
            desc.ShowAllCards();
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

        public PlayingCard ReturnOneCard()
        {
            return _deck.Dequeue();
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

        public void AcceptСard(PlayingCard card)
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


