using System.Timers;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuZoo MenuZoo = new MenuZoo();
            MenuZoo.Run();
        }
    }

    class MenuZoo
    {
        private bool _isRunMenu = true;
        private Zoo _zoo;

        public void Run()
        {
            const string ShowRoom = "1";
            const string AddAllFish = "2";
            const string ClearAllFish = "3";
            const string ShowAllFish = "4";
            const string ShowAllAnimals = "5";
            const string Exit = "6";


            while (_isRunMenu)
            {
                _zoo = new Zoo();

                Console.Clear();
                Console.WriteLine("Меню зоопарка");

                Console.WriteLine(ShowRoom + " Показать клетки");
                Console.WriteLine(AddAllFish + " Заполнить аквариум полностью");
                Console.WriteLine(ClearAllFish + " Очистить аквариум от жителей");
                Console.WriteLine(ShowAllAnimals + " Показать всех животных");
                Console.WriteLine(Exit + " Уйти от аквариума");

                Console.WriteLine("\nВведите номер пункта меню");

                string input = Console.ReadLine().ToString();
                switch (input)
                {
                    case ShowRoom:
                        _zoo.ShowRoom();
                        break;

                    case AddAllFish:
                        break;

                    case ClearAllFish:
                        break;

                    case ShowAllAnimals:
                        _zoo.Show();
                        break;

                    case Exit:
                        _isRunMenu = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в меню управления магазином");
                        break;

                }

                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }

    public class Zoo
    {
        private Dictionary<String, List<Animal>> _cage = new ();

        public Zoo()
        {
            _cage["Вольер 1"] = new List<Animal>();
            _cage["Вольер 2"] = new List<Animal>();
            _cage["Вольер 3"] = new List<Animal>();
            _cage["Вольер 4"] = new List<Animal>();
            _cage["Вольер 5"] = new List<Animal>();

            _cage["Вольер 1"].Add(new Bear());
            _cage["Вольер 1"].Add(new Bear("Woman"));
            _cage["Вольер 2"].Add(new Lion());
            _cage["Вольер 2"].Add(new Lion("Woman"));
            _cage["Вольер 3"].Add(new Monkey("Woman"));
            _cage["Вольер 3"].Add(new Monkey("Woman"));
            _cage["Вольер 4"].Add(new Horse());
            _cage["Вольер 4"].Add(new Horse("Woman"));
            _cage["Вольер 5"].Add(new Duck());
            _cage["Вольер 5"].Add(new Duck());

        }

        public void ShowRoom()
        {
            foreach (var cage in _cage.Keys)
            {
                Console.WriteLine(cage);
            }
        }



    }

        public abstract class Animal
        {
            public string Title { get; }
            public string Sex { get; }

            protected Animal(string title = "", string sex = "")
            {
                Title = title;
                Sex = sex;
            }

            public abstract void MakeSound();

            public override string ToString()
            {
                return $"{Title}, пол {Sex}";
            }
        }


        public class Bear : Animal
        {
            public Bear(string sex = "Men") : base("Bear", sex)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Arrrrrrr");
            }
        }

        public class Lion : Animal
        {
            public Lion(string sex = "Men") : base("Lion", sex)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Rrarr");
            }
        }

        public class Monkey : Animal
        {
            public Monkey(string sex = "Men") : base("Monkey", sex)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Uhaha");
            }
        }

        public class Horse : Animal
        {
            public Horse(string sex = "Men") : base("Horse", sex)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Neigh");
            }
        }

        public class Duck : Animal
        {
            public Duck(string sex = "Men") : base("Duck", sex)
            {
            }

            public override void MakeSound()
            {
                Console.WriteLine("Quack-quack");
            }

        }
        class UserUtils
        {
            private static Random s_random = new();

            public static int GenerateRandomNumber(int min = 0, int max = 100)
            {
                return s_random.Next(min, max);
            }
        }
    }
