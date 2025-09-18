using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            menu.Run();
        }
    }

    class Menu()
    {
        private Dispatcher _dispatcher = new();

        private bool _isRunMenu = true;

        public void Run()
        {
            string input;

            const string GettingStarted = "1";
            const string Exit = "2";

            while (_isRunMenu)
            {
                Console.WriteLine("Работа диспетчера");
                Console.WriteLine($"{GettingStarted} Создать поезд");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case GettingStarted:
                        _dispatcher.CreateTrain();
                        break;

                    case Exit:
                        _isRunMenu = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в списке");
                        break;
                }
            }
        }
    }

    class Dispatcher
    {
        private Random _random = new Random();

        private RoutePoint _route = new();
        private Train _train;

        private int _numberWagons = 0;
        private int _totalPassengers;
        private int _maxPassengers = 1000;
        private int _minPassengers = 50;
        private int _seatsСarriage = 81;
        private List<string> _routePoints;

        public void CreateTrain()
        {
            GetRoutePoints();
            AssignRoute();
            GetNumberPassengers();
            AssembleTrain();
        }

        private void GetRoutePoints()
        {
            _routePoints = _route.RouteRandom();
            Console.WriteLine("\nЗадаю направление маршрута поезда");
        }

        private void AssignRoute()
        {
            _train = new Train(_routePoints[0], _routePoints[1]);
        }
        private void GetNumberPassengers()
        {
            _totalPassengers = _random.Next(_minPassengers, _maxPassengers);
        }

        private void AssembleTrain()
        {

            int capacityWagon = 81;
            _numberWagons = (int)Math.Ceiling((double)_totalPassengers / _seatsСarriage);

            for (int i=0;  i < _numberWagons; i++)
            {
                _train.AddWagon(new Wagon(i + 1, capacityWagon));
            }

            Console.WriteLine($"{_train}");
            Console.WriteLine($"Билетов куплено на поезд - {_totalPassengers}\n"); ;
        }
    }

    class Train
    {
        public Train(string departurePoint, string destinationPoint)
        {
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            Wagons = new List<Wagon>();
        }

        public string DeparturePoint { get; private set; }
        public string DestinationPoint { get; private set; }
        public List<Wagon> Wagons { get; private set; }

        public void AddWagon(Wagon wagon)
        {
            Wagons.Add(wagon);
        }

        public override string ToString()
        {
            return $"Поезд следует из {DeparturePoint} в {DestinationPoint} у него {Wagons.Count} вагонов";
        }
    }

    class Wagon
    {
        public Wagon(int number, int seats)
        {
            Number = number;
            Seats = seats;
        }

        public int Number { get; private set; }
        public int Seats { get; private set; }

    }

    class RoutePoint
    {
        private List<string> _title = new();
        private Random _random = new();

        public RoutePoint()
        {
            RouteAdd();
        }

        private void RouteAdd()
        {
            _title.Add("Москва");
            _title.Add("Екатеринбург");
            _title.Add("Магадан");
            _title.Add("Тюмень");
            _title.Add("Челябинск");
            _title.Add("Воркута");
            _title.Add("Саратов");
            _title.Add("Тверь");
            _title.Add("Пермь");
            _title.Add("Омск");
        }

        public List<string> RouteRandom()
        {
            return _title.OrderBy(City => _random.Next()).Take(2).ToList();
        }
    }
}
