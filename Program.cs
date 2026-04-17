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

    class FabricaCar()
    {
        private List<Car> cars = new();
        private List<Detail> details = new();


        public List<Car> CreateCars(int size)
        {
            for (int i = 0; i < size; i++)
            {

            }


            return cars;
        }
    }

    class Car
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
            return $"Name";
        }
    }

    class Detail // деталь
    {
        public string Title { get; private set; }
        public StatusDetail Status { get; private set; }
    
    public Detail(string title, StatusDetail status = StatusDetail.working)
        {
            Title = title; 
            Status = status;
        }
    
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

    public enum StatusDetail
    {
        working = 0,
        notworking = 0
    }
}

