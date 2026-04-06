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
        private Tank _tank;
        private bool _isRunMenu = true;

        public void Run()
        {
            const string AddFish = "1";
            const string DelFish = "2";
            const string AddAllFish = "3";
            const string ClearAllFish = "4";
            const string ShowAllFish = "5";
            const string Exit = "6";

            _tank = new Tank();

            while (_isRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Меню аквариума");

                Console.WriteLine(AddFish + " Добавить рыбку");
                Console.WriteLine(DelFish + " Убрать рыбку");
                Console.WriteLine(AddAllFish + " Заполнить аквариум полностью");
                Console.WriteLine(ClearAllFish + " Очистить аквариум от жителей");
                Console.WriteLine(ShowAllFish + " Посмотреть в аквариум");
                Console.WriteLine(Exit + " Уйти от аквариума");

                Console.WriteLine("\nВведите номер пункта меню");

                string input = Console.ReadLine();
                Console.WriteLine();

                _tank.ShowAllFish();
                _tank.Update(1f);
                Thread.Sleep(1000);
                Console.Read();
            }
        }
    }

    class Fish
    {
        private string _name;
        private float _maxLifeTime;
        private float _lifeTime;

        public Fish(int life = 300, string name = "Рыбка")
        {
            _name = name;
            _lifeTime = life;
            _maxLifeTime = life;
        }

        public override string ToString()
        {
            return $"Житель аквариума {_name} время жизни {_lifeTime}";
        }

        public bool LifeUpdate(float deltaTime)
        {
            _lifeTime -= deltaTime;

            return _lifeTime <= 0;
        }
    }

    class Tank
    {
        private List<Fish> _pisces;
        private int maxFish = 10;

        public Tank()
        {
            _pisces = new List<Fish>();
            AddMaxFish();
        }

        public void AddFish()
        {
            if (_pisces.Count < maxFish)
            {
                _pisces.Add(new Fish(UserUtils.GenerateRandomNumber(100,300)));
            }
            else
            {
                Console.WriteLine("Аквариум заполнен");
            }
        }

        public void DelFish()
        {
            if (_pisces.Count < maxFish)
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
            for (int i = _pisces.Count; i < maxFish; i++)
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
                if (fish.LifeUpdate(deltaTime))
                {
                    Console.WriteLine($"{fish} умерла ☠");
                    _pisces.Remove(fish);
                }
            }
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
