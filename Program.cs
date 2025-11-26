using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DispatcherView dispatcherView = new();
            //dispatcherView.Begin();

            BattleBoard battleBoard = new BattleBoard();
            battleBoard.Begin();
        }
    }

    class BattleBoard
    {
        private bool _isShowBattle = true;

        public void Begin()
        {
            string input;

            const string StartBattle = "1";
            const string Exit = "2";

            while (_isShowBattle)
            {
                Console.WriteLine("Колизей");
                Console.WriteLine($"{StartBattle} Начать поединок");
                Console.WriteLine($"{Exit} Выход");

                Console.WriteLine(UserUtils.GenerateRandomNumber());

                input = Console.ReadLine();

                switch (input)
                {
                    case StartBattle:
                        break;

                    case Exit:
                        _isShowBattle = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в списке");
                        break;
                }
            }
        }
    }

    class Warrior
    {
        public Warrior(string title, int damage = 25, int protection = 10, int health = 1000)
        {
            Titel = title;
            Damage = damage;
            Protection = protection;
            Health = health;
        }

        public string Titel { get; private set; }
        public int Damage { get; private set; }
        public int Protection { get; private set; }
        public int Health { get; private set; }

    }

    class Assassine : Warrior
    {
        private float _chanceDubleDamage = 15f;
        public Assassine(string title, int damage = 25, int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }

    }

    class Barbarian : Warrior
    {
        private int _scoreAttack = 3;

        public Barbarian(string title, int damage = 25, int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }
    }

    class Berserker : Warrior
    {
        private int _rageCounter = 0;
        private int _rageGetting = 25;

        public Berserker(string title, int damage = 25, int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }
    }

    class Mage : Warrior
    {
        private int _mana = 100;
        private int _fireballDamage = 100;
        private int _manaFireball = 25;

        public Mage(string title, int damage = 25 int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }
    }

    class Monkey : Warrior
    {
        private int _evasion = 35;

        public Monkey(string title, int damage = 25, int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }

    }

    class Tank : Warrior
    {
        private float _boostProtection = 5;

        public Tank(string title, int damage = 25, int protection = 10, int health = 1000) : base(title, damage, protection, health)
        {
        }
    }





    class UserUtils
    {
        private static Random s_random = new();

        public static int GenerateRandomNumber(int min = 1, int max = 100)
        {
            return s_random.Next(min, max);
        }
    }
    //class Dispatcher
    //{
    //    private RoutePoint _routePoint = new();
    //    private Train _train;
    //    private Passenger _passenger = new();
    //    private Wagon _wagon ;
    //    private int _totalPassengers;
    //    private int _seatsWagon = 81;


    //    public void CreateTrain()
    //    {
    //        GetRoutePoints();
    //        AssignRoute();
    //        GetNumberPassengers();
    //        AssembleTrain();
    //    }

    //    private void GetRoutePoints()
    //    {
    //        _routePoint.GetDeparturePoint();
    //        _routePoint.GetDestinationPoint();
    //    }

    //    private void AssignRoute()
    //    {
    //        _train = new Train(_routePoint.DeparturePoint, _routePoint.DestinationPoint);
    //    }
    //    private void GetNumberPassengers()
    //    {
    //        _totalPassengers = _passenger.GetQuantity();
    //    }

    //    private void AssembleTrain()
    //    {
    //        int _numberWagons = (int)Math.Ceiling((double)_totalPassengers / _seatsWagon);

    //        for (int i = 0; i < _numberWagons; i++)
    //        {
    //            _train.AddWagon(new Wagon(i + 1));
    //        }

    //        Console.WriteLine($"{_train}");
    //        Console.WriteLine($"Билетов куплено на поезд - {_totalPassengers}\n"); ;
    //    }
    //}

    //class Train
    //{
    //    private List<Wagon> _wagons = new List<Wagon>();
    //    private string _departurePoint;
    //    private string _destinationPoint;

    //    public Train(string departurePoint, string destinationPoint)
    //    {
    //        _departurePoint = departurePoint;
    //        _destinationPoint = destinationPoint;
    //    }

    //    public void AddWagon(Wagon wagon)
    //    {
    //        _wagons.Add(wagon);
    //    }

    //    public override string ToString()
    //    {
    //        return $"Поезд следует из {_departurePoint} в {_destinationPoint} у него {_wagons.Count} вагонов";
    //    }
    //}

    //class Wagon
    //{
    //    public Wagon(int number)
    //    {
    //        Number = number;
    //    }

    //    public int Number { get; private set; }
    //    public int Seats { get; private set; }
    //}

    //class Passenger
    //{
    //    private Random _random = new Random();

    //    private int _maxPassengers = 1000;
    //    private int _minPassengers = 50;

    //    public int GetQuantity()
    //    {
    //        return _random.Next(_minPassengers, _maxPassengers);
    //    }
    //}

    //class RoutePoint
    //{
    //    public string DeparturePoint { get; private set; }
    //    public string DestinationPoint { get; private set; }

    //    public void GetDeparturePoint()
    //    {
    //        Console.WriteLine("Введите станцию отправления");
    //        DeparturePoint = Console.ReadLine();
    //    }

    //    public void GetDestinationPoint()
    //    {
    //        Console.WriteLine("Введите станцию прибытия");
    //        DestinationPoint = Console.ReadLine();
    //    }
    //}
}
