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
     
        private RoutePoint _routePoint = new();
        private Train _train;

        private int _numberWagons = 0;
        private int _totalPassengers;
        private int _maxPassengers = 1000;
        private int _minPassengers = 50;
        private int _seatsСarriage = 81;

        public void CreateTrain()
        {
            GetRoutePoints();
            AssignRoute();
            GetNumberPassengers();
            AssembleTrain();
        }

        private void GetRoutePoints()
        {
            _routePoint.GetDeparturePoint();
            _routePoint.GetDestinationPoint();
        }

        private void AssignRoute()
        {
            _train = new Train(_routePoint.DeparturePoint, _routePoint.DestinationPoint);
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
        private List<Wagon> _wagons = new List<Wagon>();
        private string _departurePoint;
        private string _destinationPoint;

        public Train(string departurePoint, string destinationPoint)
        {
            _departurePoint = departurePoint;
            _destinationPoint = destinationPoint;
        }

        public void AddWagon(Wagon wagon)
        {
            _wagons.Add(wagon);
        }

        public override string ToString()
        {
            return $"Поезд следует из {_departurePoint} в {_destinationPoint} у него {_wagons.Count} вагонов";
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
        public string DeparturePoint { get; private set; }
        public string DestinationPoint { get; private set; }

        public void GetDeparturePoint()
        {
            Console.WriteLine("Введите станцию отправления");
            DeparturePoint = Console.ReadLine();
        }

        public void GetDestinationPoint()
        {
            Console.WriteLine("Введите станцию прибытия");
            DestinationPoint = Console.ReadLine();
        }
    }
}
