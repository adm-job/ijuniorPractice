namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooView ZooView = new ZooView();
            ZooView.Run();
        }
    }

    class ZooView
    {
        private bool _isViewMenu = true;
        private Zoo _zoo;
        private int _inputUser = 0;

        public void Run()
        {
            _zoo = new Zoo();

            while (_isViewMenu)
            {
                Console.Clear();
                Console.WriteLine("Меню зоопарка\n");
                Console.WriteLine("К какому вольеру вы хотите подойти\n");
                Console.WriteLine("Вольер номера");

                _zoo.ShowRoom();

                _inputUser = ReadInt(_zoo.MaxSize) - 1;

                _zoo.ShowAnimals(_inputUser);

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

    public class Zoo
    {
        private int _maxAviarys = 5;
        private List<Aviary> _aviarys = new();
        private AviaryFabric _aviaryFabric = new();

        public Zoo()
        {
            _aviarys = _aviaryFabric.Create(_maxAviarys);
        }

        public int MaxSize => _aviarys.Count;

        public void ShowRoom()
        {
            foreach (var aviary in _aviarys)
            {
                Console.Write(aviary + "  \t  ");
            }
            Console.WriteLine();
        }

        public void ShowAnimals(int number)
        {
            _aviarys[number].ShowAnimals();
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

    public class AviaryFabric
    {
        private List<string> _animalOptions = new()
        {
          "Bear",
          "Lion",
          "Monkey",
          "Horse",
          "Duck"
        };

        private List<string> _soundOptions = new()
        {
          "Arrrrr",
          "Rrarr",
          "Uhaha",
          "Neigh",
          "Quack-quack"
        };

        public List<Aviary> Create(int size)
        {
            int randomNumber;
            List<Aviary> aviary = new();
            Animal animal = new Animal();

            for (int i = 0; i < size; i++)
            {
                randomNumber = UserUtils.GenerateRandomNumber(0, _animalOptions.Count);

                aviary.Add(new Aviary($"Вольер {i + 1}", _animalOptions[randomNumber]));
                animal = new Animal(_animalOptions[randomNumber], (SexAnimal)UserUtils.GenerateRandomBool(), _soundOptions[randomNumber]);
                aviary[i].AddAnimal(animal);
            }

            return aviary;
        }
    }

    public class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public void ShowAnimals()
        {
            foreach (var animal in _animals)
            {
                Console.WriteLine(animal);
            }
        }

        public override string ToString()
        {
            return $"{Title} {Description}";
        }
    }

    public class Animal
    {
        public Animal(string title = "", SexAnimal sex = SexAnimal.Men, string sound = "")
        {
            Title = title;
            Sex = sex;
            Sound = sound;
        }

        public string Title { get; }
        public SexAnimal Sex { get; }
        public string Sound { get; }

        public override string ToString()
        {
            return $"{Title}, пол {Sex}, звук {Sound}";
        }
    }

    public enum SexAnimal
    {

        Men = 0,
        Woman = 1
    }
}

