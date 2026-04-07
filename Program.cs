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
        private Aquarium _aquarium;
        private bool _isRunMenu = true;

        public void Run()
        {
            const string AddFish = "1";
            const string DeleteFish = "2";
            const string AddAllFish = "3";
            const string ClearAllFish = "4";
            const string ShowAllFish = "5";
            const string Exit = "6";

            _aquarium = new Aquarium();

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

                string input = Console.ReadLine();
                switch (input)
                {
                    case AddFish:
                        _aquarium.AddFish();
                        break;

                    case DeleteFish:
                        _aquarium.DeleteFish(); 
                        break;

                    case AddAllFish:
                        _aquarium.AddMaxFish(); 
                        break;

                    case ClearAllFish:
                        _aquarium.ClearAllFish(); 
                        break;

                    case ShowAllFish:
                        _aquarium.ShowAllFish();
                        break;

                    case Exit:
                        _isRunMenu = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в меню управления магазином");
                        break;

                }

                Console.WriteLine();

                _aquarium.ShowAllFish();
                _aquarium.Update(1f);
                Thread.Sleep(1000);
                Console.Read();
            }
        }
    }

    class Fish
    {
        private string _name;
        private float _lifeTime;

        public Fish(int life = 300, string name = "Рыбка")
        {
            _name = name;
            _lifeTime = life;
        }

        public override string ToString()
        {
            return $"Житель аквариума {_name} время жизни {_lifeTime}";
        }

        public bool TryLifeUpdate(float deltaTime)
        {
            _lifeTime -= deltaTime;

            return _lifeTime <= 0;
        }
    }

    class Aquarium
    {
        private List<Fish> _pisces;
        private int _maxFish = 10;

        public Aquarium()
        {
            _pisces = new List<Fish>();
            AddMaxFish();
        }

        public void AddFish()
        {
            if (_pisces.Count < _maxFish)
            {
                _pisces.Add(new Fish(UserUtils.GenerateRandomNumber(100, 300)));
            }
            else
            {
                Console.WriteLine("Аквариум заполнен");
            }
        }

        public void DeleteFish()
        {
            if (_pisces.Count < _maxFish)
            {
                _pisces.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("Аквариум пуст, больше некого убирать");
            }
        }

        public void AddMaxFish()
        {
            for (int i = _pisces.Count; i < _maxFish; i++)
            {
                _pisces.Add(new Fish(UserUtils.GenerateRandomNumber(100, 300)));
            }
        }

        public void ClearAllFish()
        {
            _pisces.Clear();
        }

        public void Update(float deltaTime)
        {
            foreach (var fish in _pisces.ToList())
            {
                if (fish.TryLifeUpdate(deltaTime))
                {
                    Console.WriteLine($"{fish} умерла ☠");
                    Remove(fish);
                }
            }
        }

        public void Remove(Fish fish)
        {
            _pisces.Remove(fish);
        }

        public void ShowAllFish()
        {
            if (_pisces.Count > 0)
            {
                foreach (Fish fish in _pisces)
                {
                    Console.WriteLine(fish);
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст");
            }
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
