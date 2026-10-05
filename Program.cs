namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.Run();
        }
    }

    class CarService
    {
        private int maxClients = 15;
        private List<Car> _clientCars;
        private bool _isWorking = true;
        private int _inputUser = 0;
        private FactoryCar _factoryCars = new();
        private Price _price = new();
        private CashRegister _cashRegister = new();

        public void AddСlientsQueue(int maxClients)
        {
            _clientCars = _factoryCars.CreateCars(maxClients);
        }

        public void Run()
        {
            const int ShowСlients = 1;
            const int ShowPrice = 2;
            const int ShowCashRegister = 3;
            const int Exit = 4;

            AddСlientsQueue(maxClients);

            while (_isWorking)
            {
                Console.Clear();
                Console.WriteLine("Автосервис\n");
                Console.WriteLine("Выберите пункт меню\n");
                Console.WriteLine(ShowСlients + " показать очередь клиентов");
                Console.WriteLine(ShowPrice + " показать цены на детали и работы");
                Console.WriteLine(ShowCashRegister + " показать деньги в кассе");
                Console.WriteLine(Exit + " выход из программы");

                _inputUser = ReadInt(); // Править все

                switch (_inputUser)
                {
                    case ShowСlients: // Переделать
                        int y = 0;
                        foreach (var car in _clientCars)
                        {
                            Console.SetCursorPosition(100, y);
                            Console.WriteLine(car);
                            y += 1;
                        }
                        break;

                    case ShowPrice:
                        _price.Show();
                        break;

                    case ShowCashRegister:
                        Console.WriteLine(_cashRegister);
                        break;

                    case Exit:
                        _isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в меню автосервиса");
                        break;
                }

                Console.WriteLine("\nНажмите ввод что бы продолжить выбор");
                Console.ReadLine();
            }
        }


        private int ReadInt()
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine($"Введено не число");
            }

            return inputNumber;
        }
    }

    class CashRegister // касса сервиса
    {
        private float _amountСash = 0f;

        public void ShowCash()
        {
            Console.WriteLine($"Сумма в кассе = {_amountСash}");
        }

        public void AcceptCash(float cash)
        {
            _amountСash += cash;
        }

        public override string ToString()
        {
            return $"Сумма в кассе = {_amountСash}";
        }
    }

    record PartInfo(float partPrice, float workPrice, float forfeit);

    class Price
    {
        private Dictionary<DetailsCar, PartInfo> _prices;

        public Price()
        {
            _prices = new Dictionary<DetailsCar, PartInfo>()
            {
                {DetailsCar.engine, new PartInfo(5000, 1500, 500) },
                {DetailsCar.transmission, new PartInfo(3500,1000, 500) },
                {DetailsCar.chassis, new PartInfo(3000, 900, 500) },
                {DetailsCar.wheels, new PartInfo(12000, 3500, 500) },
                {DetailsCar.fuelTank, new PartInfo(4000, 1900, 500) },
                {DetailsCar.steeringWheel, new PartInfo(6000,2400, 500) },
                {DetailsCar.seats, new PartInfo(34000, 9000, 500) }
            };
        }

        public void Show()
        {
            foreach (var line in _prices)
            {
                Console.WriteLine($"{line.Key}| Деталь: {line.Value.partPrice}| Работа: {line.Value.workPrice}| Отказ(Штраф): {line.Value.forfeit}");
            }
        }


    }

    class Warehouse //Склад
    {
        private Dictionary<Detail, float> _storage = new();

        public void AddDetail(Detail detailsCar, float amount)
        {
            if (_storage.TryAdd(detailsCar, amount) == false)
            {
                Console.WriteLine("Деталь уже есть на складе");
            }
        }

        public Detail GetDetail(Detail detailsCar)
        {
            float amount = 0f;
            var part = _storage;

            if (_storage.ContainsKey(detailsCar))
            {
                _storage.TryGetValue(detailsCar, out amount);
                if (amount > 0)
                {
                    _storage[detailsCar] = amount--;
                    return detailsCar;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    public enum DetailsCar // список деталей
    {
        engine = 0,
        transmission = 1,
        chassis = 2,
        wheels = 3,
        fuelTank = 4,
        steeringWheel = 5,
        seats = 6
    }

    class FactoryCar //фабрика по созданию автомобилкей
    {
        private List<Car> _cars = new();

        public List<Car> CreateCars(int size)
        {
            List<Detail> details = new();

            for (int i = 0; i < size; i++)
            {
                details.Clear();
                _cars.Add(new Car("Машина " + (i + 1)));

                for (int j = 0; j < sizeof(DetailsCar); j++)
                {
                    details.Add(new((DetailsCar)j, (StatusDetail)UserUtils.GenerateRandomBool()));
                }

                _cars[i].AddDetail(details);
            }

            return _cars;
        }
    }

    class Car //автомобиль
    {
        private List<Detail> _details = new();

        public string Name { get; private set; }

        public Car(string name)
        {
            Name = name;
        }

        public void AddDetail(List<Detail> details)
        {
            foreach (var detail in details)
            {
                _details.Add(detail);
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    class Detail // деталь
    {
        public DetailsCar Title { get; private set; }
        public StatusDetail Status { get; private set; }

        public Detail(DetailsCar title, StatusDetail status = StatusDetail.working)
        {
            Title = title;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Title} - {Status}";
        }
    }

    public enum StatusDetail // статус детали
    {
        working = 1,
        notworking = 0
    }

    class UserUtils
    {
        private static Random s_random = new();

        public static int GenerateRandomNumber(int min = 0, int max = 100)
        {
            return s_random.Next(min, max);
        }

        public static int GenerateRandomBool(int max = 2)
        {
            return s_random.Next(max);
        }
    }
}



