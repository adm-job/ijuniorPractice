namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ZooView ZooView = new ZooView();
            //ZooView.Run();
        }
    }

    class CarService
    {
        private bool _isPrice = true;
        private int _inputUser = 0;

        public void Run()
        {
            while (_isPrice)
            {
                Console.Clear();
                Console.WriteLine("Автосервис\n");
                Console.WriteLine("Выберите пункт меню\n");

                _inputUser = ReadInt(5) - 1; // Править все

                Console.WriteLine("\nНажмите ввод что бы продолжить выбор");
                Console.ReadLine();
            }
        }

        private int ReadInt(int maxIndex)
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxIndex)
            {
                Console.WriteLine($"Введено не верное значение индекса всего {maxIndex}");
            }

            return inputNumber;
        }
    }

    class CashRegister // касса сервиса
    {
        private float _amountСash = 0f;

        public void ShowCash()
        {
            Console.WriteLine($"Семма в кассе = {_amountСash}");
        }

        public void AcceptCash(float cash)
        {
            _amountСash += cash;
        }
    }

    class Price
    {
        private DetailsCar _detailsCar;

    }

    class Warehouse //Склад
    {
        private Dictionary<Detail, float> _storage = new();

        public void AddDetail(Detail detailsCar, float amount)
        {
            if (_storage.TryAdd(detailsCar, amount) == false)
            {
                Console.WriteLine("Деталь уже усть на склде");
            }
        }

        public Detail GetDetail(Detail detailsCar)
        {
            float amount = 0f;

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



    class FabricaCar //фабрика по созданию автомобилкей
    {
        private List<Car> cars = new();
        //private List<String> detailsCar = new()
        //{
        //    "engine",
        //    "transmission",
        //    "chassis",
        //    "wheels",
        //    "fuel tank",
        //    "steering wheel",
        //    "seats"
        //};

        public List<Car> CreateCars(int size)
        {
            List<Detail> details = new();

            for (int i = 0; i < size; i++)
            {
                details.Clear();
                cars.Add(new Car("Машина " + (i + 1)));

                for (int j = 0; j < sizeof(DetailsCar); j++)
                {
                    details.Add(new((DetailsCar)j, (StatusDetail)UserUtils.GenerateRandomBool()));
                }

                cars[i].AddDetail(details);
            }

            return cars;
        }
    }

    class Car //автомобиль
    {
        private List<Detail> _decimals = new();

        public string Name { get; private set; }

        public Car(string name)
        {
            Name = name;
        }

        public void AddDetail(List<Detail> details)
        {
            foreach (var detail in details)
            {
                _decimals.Add(detail);
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



