using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Menu menu = new(library);
            menu.Run();
        }
    }

    class Menu
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
            const string Exit = "5";

            while (_isRunMenu)
            {
                Console.WriteLine("\nПолка с книгами");
                Console.WriteLine($"{AddBook}. Добавить книгу");
                Console.WriteLine($"{ShowAll}. Показать всю полку");
                Console.WriteLine($"{RemoveBook}. Удалить книгу");
                Console.WriteLine($"{SearchName}. Поиск на полке");
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
        private List<Book> _books = new();

        public void ShowAll()
        {
            foreach (var book in _books)
            {
                Show(book);
            }
        }

        public void AddBook()
        {
            string? name;
            string? author;
            string? yearRelease;
            string? description;

            Console.WriteLine("Введите название книги");
            name = InputUser();
            Console.WriteLine("Введите автора книги");
            author = InputUser();
            Console.WriteLine("Введите год книги");
            yearRelease = InputUser();
            Console.WriteLine("Введите примечание");
            description = InputUser();

            _books.Add(new Book(name, author, yearRelease, description));
        }

        public void RemoveBook()
        {
            Console.WriteLine("Введите название книги");

            string name = InputUser();

            _books.Remove(new Book(name));
        }

        public void SearchName()
        {
            Console.WriteLine("Введите строку для поиска");
            string? input = InputUser();

            List<Book> result = _books.FindAll(name => name.Name.StartsWith(input) || name.Author.StartsWith(input) || name.YearRelease.StartsWith(input));

            foreach (var book in result)
            {
                Show(book);
            }
        }

        private void Show(Book book)
        {
            Console.Write($"Название {book.Name} : Автор {book.Author} : Год {book.YearRelease} : Примечание {book.Description}\n");
        }

        private string InputUser()
        {
            return Console.ReadLine()
                          .ToLower();
        }
    }
}