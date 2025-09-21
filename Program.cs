using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DispatcherView dispatcherView = new();
            dispatcherView.Begin();
        }
    }

    class DispatcherView()
    {
        private Dispatcher _worker = new();
        private bool _isView = true;

        public void Begin()
        {
            string input;

            const string GettingStarted = "1";
            const string Exit = "2";

            while (_isView)
            {
                Console.WriteLine("Работа диспетчера");
                Console.WriteLine($"{GettingStarted} Создать поезд");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case GettingStarted:
                        _worker.CreateTrain();
                        break;

                    case Exit:
                        _isView = false;
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
        public void CreateTrain()
        {
            TicketOffice _ticketOffice = new();
            List<Wagon> _wagonList = new();
            int _seatsWagon = 81;

            Console.WriteLine("Введите станцию отправления");
            string Departure = Console.ReadLine();
            Console.WriteLine("Введите станцию прибытия");
            string Destination = Console.ReadLine();

            Point _point = new(Departure, Destination);

            int numberWagons = (int)Math.Ceiling((double)_ticketOffice.Generate() / _seatsWagon);

            for (int i = 0; i < numberWagons; i++)
            {
                _wagonList.Add(new(i+1));
            }

            Train _train = new Train(_point, _wagonList);

            Console.WriteLine($"{_train}");
            Console.WriteLine($"Билетов куплено на поезд - {_ticketOffice.Generate()}\n"); ;
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private Point _point;

        public Train(Point point, List<Wagon> wagons)
        { 
            _point = point;
           _wagons = wagons; 
        }

        public override string ToString()
        {
            return $"Поезд следует из {_point.DeparturePoint} в {_point.DestinationPoint} у него {_wagons.Count} вагонов";
        }
    }

    class Wagon
    {
        public Wagon(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }
    }

    class TicketOffice
    {
        private Random _random = new Random();

        private int _maxPassengers;
        private int _minPassengers;

        public TicketOffice(int minPassengers = 50, int maxPassengers = 1000)
        {
            _maxPassengers = maxPassengers;
            _minPassengers = minPassengers;
        }

        public int Generate()
        {
            return _random.Next(_minPassengers, _maxPassengers);
        }
    }

    class Point
    {
        public Point(string departurePoint, string destinationPoint)
        {
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
        }

        public string DeparturePoint { get; private set; }
        public string DestinationPoint { get; private set; }
    }
}
