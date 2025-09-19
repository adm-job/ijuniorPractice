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
        private Dispatcher _dispatcher = new();
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
                        _dispatcher.CreateTrain();
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
            AssembleTrain();
        }

        private void AssembleTrain()
        {
            Point _point = new();
            TicketOffice _ticketOffice = new();
            int _seatsWagon = 81;

            int numberWagons = (int)Math.Ceiling((double)_ticketOffice.GetQuantity() / _seatsWagon);

            Train _train = new Train(_point.GetDeparturePoint(), _point.GetDestinationPoint(), numberWagons);

            Console.WriteLine($"{_train}");
            Console.WriteLine($"Билетов куплено на поезд - {_ticketOffice.GetQuantity()}\n"); ;
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private string _departurePoint;
        private string _destinationPoint;

        public Train(string departurePoint, string destinationPoint, int tikets)
        {
            _departurePoint = departurePoint;
            _destinationPoint = destinationPoint;

            for (int i = 0; i < tikets; i++)
            {
                _wagons.Add(new Wagon(i + 1));
            }
        }

        public override string ToString()
        {
            return $"Поезд следует из {_departurePoint} в {_destinationPoint} у него {_wagons.Count} вагонов";
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

        private int _maxPassengers = 1000;
        private int _minPassengers = 50;

        public int GetQuantity()
        {
            return _random.Next(_minPassengers, _maxPassengers);
        }
    }

    class Point
    {
        public string DeparturePoint { get; private set; }
        public string DestinationPoint { get; private set; }

        public string GetDeparturePoint()
        {
            Console.WriteLine("Введите станцию отправления");
            return DeparturePoint = Console.ReadLine();
        }

        public string GetDestinationPoint()
        {
            Console.WriteLine("Введите станцию прибытия");
            return DestinationPoint = Console.ReadLine();
        }
    }
}
