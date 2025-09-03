using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Library library = new Library();
            //Menu menu = new(library);
            //menu.Run();
        }
    }

    class Products
    {
        public Products(string title, int price = 0)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; private set; }
        public int Price { get; private set; }

        public override string ToString()
        {
            return $"Товар:{Title}\t\t\t\t\t\tЦена:{Price}";
        }
    }

    class People
    {
        protected List<Products> _list = new();
        public int Money { get; private set; }

        public void ShowBalans()
        {
            Console.WriteLine($"В кошельке {Money} монет");
        }

        public void ShowList()
        {
            Console.WriteLine(string.Join("\n", _list));
        }
    }

    class Seller : People
    {
        public Products SellPrice()
        {
            return new Products("1", 1);//??????????????????????
        }
    }

    class Bayer : People
    {
        public void BayPrice(Products price)
        {
            _list.Add(price);
        }
    }








    /* class Menu
    {
        private Library _library;
        private bool _isRunMenu = true;

        public Menu(Library library)
        {
            _library = library;
        }

        public void Run()
        {
            const string AddBook = "1";
            const string ShowAll = "2";
            const string RemoveBook = "3";
            const string SearchName = "4";
            const string SearchAuthor = "5";
            const string SearchYear = "6";
            const string Exit = "7";

            while (_isRunMenu)
            {
                Console.WriteLine("\nПолка с книгами");
                Console.WriteLine($"{AddBook}. Добавить книгу");
                Console.WriteLine($"{ShowAll}. Показать всю полку");
                Console.WriteLine($"{RemoveBook}. Удалить книгу");
                Console.WriteLine($"{SearchName}. Поиск по названию");
                Console.WriteLine($"{SearchAuthor}. Поиск по автору");
                Console.WriteLine($"{SearchYear}. Поиск по году");
                Console.WriteLine($"{Exit}. Выход");
                Console.WriteLine("Введите номер пункта меню");

                string input = Console.ReadLine();

                switch (input)
                {
                    case AddBook:
                        _library.AddBook();
                        break;
                    case ShowAll:
                        _library.ShowAll();
                        break;
                    case RemoveBook:
                        _library.RemoveBook();
                        break;
                    case SearchName:
                        _library.SearchName();
                        break;
                    case SearchAuthor:
                        _library.SearchAuthor();
                        break;
                    case SearchYear:
                        _library.SearchYear();
                        break;
                    case Exit:
                        _isRunMenu = false;
                        break;
                    default:
                        Console.WriteLine($"Пункта под номером {input} не существует");
                        break;
                }
            }
        }*/

    /*    class Book
        {
            public Book(string name, string author = "", string yearRelease = "", string description = "")
            {
                Name = name;
                Author = author;
                YearRelease = yearRelease;
                Description = description;
            }

            public string Name { get; private set; }
            public string Author { get; private set; }
            public string YearRelease { get; private set; }
            public string Description { get; private set; }

            public override string ToString()
            {
                return $"Название {Name}\t\t\t : Автор {Author}\t\t\t : Год {YearRelease}\t : Примечание {Description}";
            }
        }*/

    /*        private int ReadInt(int maxIndex)
            {
                int inputNumber;

                while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxIndex)
                {
                    Console.WriteLine($"Введено не верное значение индекса всего {maxIndex}");
                }

                return inputNumber;
            }*/

}