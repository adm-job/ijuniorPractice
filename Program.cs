using System.Timers;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuZoo MenuZoo = new MenuZoo();
            MenuZoo.Run();
        }
    }

    class MenuZoo
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
        private UserUtils _userUtils;
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

        private enum Sex
        {
            Men = 1,
            Woman = 2
        }

        public Zoo()
        {
            int randomNumber;
            
            for (int i = 0; i < _maxAviarys; i++)
            {
                randomNumber = UserUtils.GenerateRandomNumber(0, _animalOptions.Count);

                _aviarys.Add(new Aviary($"Вольер {i + 1}", _animalOptions[randomNumber]));
                _aviarys[i].AddAnimal(_animalOptions[randomNumber], "Men", _soundOptions[randomNumber]);
            }


            //_aviarys.Add(new Aviary("Вольер 1", "Медведи"));
            //_aviarys[0].AddAnimal("Bear", "Men", "Arrrrr");
            //_aviarys[0].AddAnimal("Bear", "Woman", "Arrrrr");

            //_aviarys.Add(new Aviary("Вольер 2", "Львы"));
            //_aviarys[1].AddAnimal("Lion", "Men", "Rrarr");
            //_aviarys[1].AddAnimal("Lion", "Woman", "Rrarr");

            //_aviarys.Add(new Aviary("Вольер 3", "Обезьяны"));
            //_aviarys[2].AddAnimal("Monkey", "Men", "Uhaha");
            //_aviarys[2].AddAnimal("Monkey", "Woman", "Uhaha");

            //_aviarys.Add(new Aviary("Вольер 4", "Лошади"));
            //_aviarys[3].AddAnimal("Horse", "Men", "Neigh");
            //_aviarys[3].AddAnimal("Horse", "Woman", "Neigh");

            //_aviarys.Add(new Aviary("Вольер 5", "Утки"));
            //_aviarys[4].AddAnimal("Duck", "Men", "Quack-quack");
            //_aviarys[4].AddAnimal("Duck", "Men", "Quack-quack");
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

        public void AddAnimal(string title, string sex, string sound)
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

        public Animal(string title = "", string sex = "", string sound = "")
        {
            Title = title;
            Sex = sex;
            Sound = sound;
        }

        public string Title { get; }
        public string Sex { get; }
        public string Sound { get; }

        public void MakeSound()
        {
            Console.WriteLine(Sound);
        }

        public override string ToString()
        {
            return $"{Title}, пол {Sex}";
        }
    }
}
