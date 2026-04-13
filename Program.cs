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
        int input = 0;

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

                input = ReadInt(_zoo.MaxIndex());

                _zoo.ShowAnimals(input);

                Console.WriteLine();
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
        private Dictionary<int, List<Animal>> _cage = new();

        public Zoo()
        {
            _cage[1] = new() { new Bear(), new Bear("Woman") };
            _cage[2] = new() { new Lion(), new Lion("Woman") };
            _cage[3] = new() { new Monkey("Woman"), new Monkey("Woman") };
            _cage[4] = new() { new Horse(), new Horse("Woman") };
            _cage[5] = new() { new Duck(), new Duck() };
        }

        public void ShowRoom()
        {
            foreach (var cage in _cage.Keys)
            {
                Console.Write(cage + "\t");
            }
            Console.WriteLine("\n");
        }

        public void ShowAnimals(int number)
        {
            foreach (var animal in _cage[number])
            {
                Console.WriteLine(animal);
                animal.MakeSound();
                Console.WriteLine();
            }
        }

        public int MaxIndex()
        {
            return _cage.Count;
        }
    }

    public abstract class Animal
    {
        protected Animal(string title = "", string sex = "")
        {
            Title = title;
            Sex = sex;
        }

        public string Title { get; }
        public string Sex { get; }

        public abstract void MakeSound();

        public override string ToString()
        {
            return $"{Title}, пол {Sex}";
        }
    }

    public class Bear : Animal
    {
        public Bear(string sex = "Men") : base("Bear", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Arrrrrrr");
        }
    }

    public class Lion : Animal
    {
        public Lion(string sex = "Men") : base("Lion", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Rrarr");
        }
    }

    public class Monkey : Animal
    {
        public Monkey(string sex = "Men") : base("Monkey", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Uhaha");
        }
    }

    public class Horse : Animal
    {
        public Horse(string sex = "Men") : base("Horse", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Neigh");
        }
    }

    public class Duck : Animal
    {
        public Duck(string sex = "Men") : base("Duck", sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Quack-quack");
        }

    }
}
