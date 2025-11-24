using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DispatcherView dispatcherView = new();
            //dispatcherView.Begin();
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
                Console.WriteLine("Бои гладиаторов");
                Console.WriteLine($"{StartBattle} Начать поединок");
                Console.WriteLine($"{Exit} Выход");

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
    //class DispatcherView()
    //{
    //    private Dispatcher _dispatcher = new();
    //    private bool _isView = true;

    //    public void Begin()
    //    {
    //        string input;

    //        const string GettingStarted = "1";
    //        const string Exit = "2";

    //        while (_isView)
    //        {
    //            Console.WriteLine("Работа диспетчера");
    //            Console.WriteLine($"{GettingStarted} Создать поезд");
    //            Console.WriteLine($"{Exit} Выход");

    //            input = Console.ReadLine();

    //            switch (input)
    //            {
    //                case GettingStarted:
    //                    _dispatcher.CreateTrain();
    //                    break;

    //                case Exit:
    //                    _isView = false;
    //                    break;

    //                default:
    //                    Console.WriteLine("Выбранного пункта нет в списке");
    //                    break;
    //            }
    //        }
    //    }
    //}

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
