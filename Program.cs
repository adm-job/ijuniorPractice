using System.Timers;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooView MenuZoo = new ZooView();
            MenuZoo.Run();
        }
    }

    class ZooView
    {
        private bool _isRunMenu = true;
        private Zoo _zoo;
        private int _input = 0;

        public void Run()
        {
            _zoo = new Zoo();

            while (_isRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Меню зоопарка\n");
                Console.WriteLine("К какому вольеру вы хотите подойти\n");
                Console.WriteLine("Вольер номера");

                _zoo.ShowRoom();

                _input = ReadInt(_zoo.MaxIndex) - 1;

                _zoo.ShowAnimals(_input);

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


        public Zoo()
        {
            int randomNumber;

            for (int i = 0; i < _maxAviarys; i++)
            {
                randomNumber = UserUtils.GenerateRandomNumber(0, _animalOptions.Count);

                _aviarys.Add(new Aviary($"Вольер {i + 1}", _animalOptions[randomNumber]));
                _aviarys[i].AddAnimal(_animalOptions[randomNumber], UserUtils.GenerateRandomBool(), _soundOptions[randomNumber]);
            }
        }

        public int MaxIndex
        {
            get
            {
                return _aviarys.Count;
            }
        }

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

        public void AddAnimal(string title, int sex, string sound)
        {
            _animals.Add(new(title, sex, sound));
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
        private enum SexAnimal
        {
            Men = 0,
            Woman = 1
        }

        public Animal(string title = "", int sex = 1, string sound = "")
        {
            Title = title;
            Sex = sex;
            Sound = sound;
        }

        public string Title { get; }
        public int Sex { get; }
        public string Sound { get; }

        public void MakeSound()
        {
            Console.WriteLine(Sound);
        }

        public override string ToString()
        {
            return $"{Title}, пол {(SexAnimal)Sex}, звук {Sound}";
        }
    }
}
