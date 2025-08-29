using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dealer dealer = new Dealer();
            //Player player = new Player();
            //Menu menu = new(dealer, player);

            //dealer.ShuffleDeck();

            //menu.Run();
        }
    }

    class Menu
    {
        //private Dealer _dealer;
        //private Player _player;
        private bool _isRunMenu = true;

        //public Menu(Dealer dealer, Player player)
        //{
        //    _dealer = dealer;
        //    _player = player;
        //}


        public void Run()
        {
            const string IssueСards = "1";
            const string ShowCards = "2";
            const string Exit = "3";

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
                        //_player.AcceptСards(_dealer.ReturnCards());
                        break;
                    case ShowCards:
                        //_player.ShowCards();
                        break;
                    case Exit:
                        //_isRunMenu = false;
                        break;
                    default:
                        Console.WriteLine($"Пункта под номером {input} не существует");
                        break;
                }
            }
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

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string YearRelease { get; private set; }
        public string Description { get; private set; }

        public Book(string name, string author = "", string yearRelease = "", string description = "")
        {
            Name = name;
            Author = author;
            YearRelease = yearRelease;
            Description = description;
        }
    }

    class Library
    {

    }

}