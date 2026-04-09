using System.Timers;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuAquarist MenuAquarist = new MenuAquarist();
            MenuAquarist.Run();
        }
    }

    class MenuAquarist
    {
        private bool _isRunMenu = true;

        public void Run()
        {
            const string AddFish = "1";
            const string DeleteFish = "2";
            const string AddAllFish = "3";
            const string ClearAllFish = "4";
            const string ShowAllFish = "5";
            const string Exit = "6";


            while (_isRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Меню аквариума");

                Console.WriteLine(AddFish + " Добавить рыбку");
                Console.WriteLine(DeleteFish + " Убрать рыбку");
                Console.WriteLine(AddAllFish + " Заполнить аквариум полностью");
                Console.WriteLine(ClearAllFish + " Очистить аквариум от жителей");
                Console.WriteLine(ShowAllFish + " Посмотреть в аквариум");
                Console.WriteLine(Exit + " Уйти от аквариума");

                Console.WriteLine("\nВведите номер пункта меню");

                string input = Console.ReadLine().ToString();
                switch (input)
                {
                    case AddFish:
                        break;

                    case DeleteFish:
                        break;

                    case AddAllFish:
                        break;

                    case ClearAllFish:
                        break;

                    case ShowAllFish:
                        break;

                    case Exit:
                        _isRunMenu = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в меню управления магазином");
                        break;

                }

                Console.WriteLine();
            }
        }
    }

    public class Zoo
    {
        private List<Animal> animals;



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
        public Monkey(string sex = "Men") : base ("Monkey", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Uhaha");
        }
    }

    public class Horse : Animal
    {
        public Horse(string sex = "Men"): base ("Horse", sex)
        {
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Neigh");
        }
    }

    public class Duck : Animal
    {
        public Duck(string sex = "Men"):base("Duck", sex)
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
