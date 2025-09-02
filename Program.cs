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
        }
    }

    class Book
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
    }

    class Library
    {
        private List<Book> _books = new();

        public void ShowAll()
        {
            Console.Clear();

            if (_books.Count <= 0)
            {
                Console.WriteLine("Книг на полке нет");
            }

            foreach (var book in _books)
            {
                Console.WriteLine(book);
            }
        }

        public void AddBook()
        {
            string? name;
            string? author;
            string? yearRelease;
            string? description;

            Console.Clear();
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
            int number = 1;
            int indexRemove = -1;

            Console.Clear();
            Console.WriteLine("Введите название книги");

            string name = InputUser();

            List<Book> booksRemove = _books.FindAll(book => book.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (booksRemove != null)
            {
                foreach (var book in booksRemove)
                {
                    Console.Write(number++ + ": ");
                    Console.WriteLine(book);
                }

                Console.WriteLine("Введите номер книги для удаления");

                indexRemove = ReadInt(booksRemove.Count) - 1;

                Book bookRemove = booksRemove[indexRemove];

                _books.Remove(bookRemove);
                Console.WriteLine($"Книга {name} удалена");
            }
            else
            {
                Console.WriteLine($"Введенная книга {name} не найдена");
            }
        }

        public void SearchName()
        {
            Console.Clear();
            Console.WriteLine("Введите название для поиска");

            string? input = InputUser();

            List<Book> result = _books.FindAll(name => name.Name.Contains(input, StringComparison.OrdinalIgnoreCase));

            PrintBooks(result);
        }

        public void SearchAuthor()
        {
            Console.Clear();
            Console.WriteLine("Введите автора для поиска");

            string? input = InputUser();

            List<Book> result = _books.FindAll(name => name.Author.Contains(input, StringComparison.OrdinalIgnoreCase));

            PrintBooks(result);
        }

        public void SearchYear()
        {
            Console.Clear();
            Console.WriteLine("Введите год книги для поиска");

            string? input = InputUser();

            List<Book> result = _books.FindAll(name => name.YearRelease.Contains(input, StringComparison.OrdinalIgnoreCase));

            PrintBooks(result);
        }

        private string InputUser()
        {
            return Console.ReadLine()
                          .ToLower();
        }

        private void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private int ReadInt(int maxIndex)
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxIndex)
            {
                Console.WriteLine($"Введено не верное значение индекса всего {maxIndex}");
            }

            return inputNumber;
        }
    }
}