using System;
using System.Xml.Linq;

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
        private Arena _arena = new();

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

                input = Console.ReadLine();

                switch (input)
                {
                    case StartBattle:
                        _arena.WarriorShow();
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

    class Arena
    {
        private List<Warrior> _warriors = new List<Warrior>
        {
            new Assassine("Убийца"),
            new Barbarian("Варвар"),
            new Berserker("Берсерк"),
            new Mage("Маг"),
            new Monkey("Изворотливый"),
            new Tank("Бронированный")
        };

        internal List<Warrior> Warriors { get => _warriors; set => _warriors = value; }

        public void WarriorShow()
        {
            int number = 1;
            foreach (var warrior in _warriors)
            {
                Console.Write(number + " ");
                Console.WriteLine(warrior);
                number++;
            }
        }

    }

    class Warrior
    {
        protected float percent = 100f;

        public Warrior(string name, float damage = 25, float protection = 10, float health = 1000)
        {
            Name = name;
            Damage = damage;
            Protection = protection;
            Health = health;
        }

        public string Name { get; private set; }
        public float Damage { get; protected set; }
        public float Protection { get; protected set; }
        public float Health { get; protected set; }

        public void ShowCurrentHelth()
        {
            Console.WriteLine($"Гладиатор {Name} имеет {Health} жизней");
        }

        public virtual float Attack()
        {
            return Damage;
        }
        public virtual float TakeDamage(float damage)
        {
            return Health -= (damage - (damage * Protection / percent));
        }

        public override string ToString()
        {
            return $"Гладиатор\n ---{Name}---\t\t Урон-{Damage}-\t\t Защита-{Protection}-\t\t Жизни-{Health}-";
        }
    }

    class Assassine : Warrior
    {
        private float _chanceDubleDamage = 15f;
        public Assassine(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float Attack()
        {
            if (UserUtils.GenerateRandomNumber() < _chanceDubleDamage)
                return Damage * 2;
            else
                return Damage;
        }

    }

    class Barbarian : Warrior
    {
        private int _scoreAttack = 3;
        private int _score = 0;

        public Barbarian(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float Attack()
        {
            if (_scoreAttack > _score)
            {
                _score++;
                return Damage;
            }
            else
            {
                _score = 0;
                return Damage + Damage;
            }

        }

    }

    class Berserker : Warrior
    {
        private int _rageCounter = 0;
        private int _rageGetting = 25;
        private int _rageMax = 100;

        public Berserker(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float TakeDamage(float damage)
        {
            _rageCounter += _rageGetting;

            float healedAmount = 375;
            float remainingHealth = base.TakeDamage(damage);

            if (_rageCounter >= _rageMax)
            {
                _rageCounter = 0;


                Health += healedAmount;

                return Health;
            }

            return Health;
        }
    }

    class Mage : Warrior
    {
        private int _mana = 100;
        private int _fireballDamage = 100;
        private int _manaFireball = 25;

        public Mage(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float Attack()
        {
            if (_mana >= _manaFireball)
            {
                Damage = _fireballDamage;
            }
            else
            {
                Damage = 25;
            }

            return Damage;
        }


    }

    class Monkey : Warrior
    {
        private int _evasion = 35;

        public Monkey(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float TakeDamage(float damage)
        {
            if (UserUtils.GenerateRandomNumber() < _evasion)
            {
                Console.WriteLine($"{Name} Уклонился от атаки");
                damage = 0;
            }

            return base.TakeDamage(damage);
        }

    }

    class Tank : Warrior
    {
        private float _boostProtection = 1;
        private float _startProtection = 0;

        public Tank(string name, float damage = 25, float protection = 10, float health = 1000) : base(name, damage, protection, health)
        {
        }

        public override float TakeDamage(float damage)
        {
            Protection += _startProtection;

            _startProtection += _boostProtection;

            return base.TakeDamage(damage);
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
