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

    public abstract class Animal
    {
        public abstract string Title { get; }

        public abstract string Sex { get; }

        public abstract void MakeSound();
    }


    public class Bear : Animal
    {
        private string _title;
        private string _sex;

        public Bear(string title = "Bear", string sex = "Men")
        {
            _title = title;
            _sex = sex;
        }

        public override string Title => _title;

        public override string Sex => _sex;

        public override void MakeSound()
        {
            Console.WriteLine("Arrrrrrr");
        }
    }

    public class Lion : Animal
    {
        private string _title;
        private string _sex;

        public Lion(string title = "Lion", string sex = "Men")
        {
            _title = title;
            _sex = sex;
        }
        public override string Title => _title;

        public override string Sex => _sex;

        public override void MakeSound()
        {
            Console.WriteLine("Rrrrrrr");
        }
    }

    public class Monkey : Animal
    {
        private string _title;
        private string _sex;

        public Monkey(string title = "Monkey", string sex = "Men")
        {
            _title = title;
            _sex = sex;
        }

        public override string Title => _title;

        public override string Sex => _sex;

        public override void MakeSound()
        {
            Console.WriteLine("Uhaha");
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
