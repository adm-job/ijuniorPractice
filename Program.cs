namespace ijuniorPractice

{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Supermarket
    {
        private List<Products> _products = new List<Products>();
        private Queue<Buyer> _bayer = new Queue<Buyer>();
        private float _money = 0;
        private bool _isWork = true;

        public void AddProductsShowcase()
        {
            _products.Add(new("Банан", 75.5f));
            _products.Add(new("Тушенка", 245f));
            _products.Add(new("Колбаса", 345.8f));
            _products.Add(new("Молоко", 90f));
            _products.Add(new("Пельмени", 419.2f));
            _products.Add(new("Вода", 39.9f));
            _products.Add(new("Чипсы", 189.9f));
            _products.Add(new("Хлеб", 55f));
            _products.Add(new("Соль", 25.4f));
            _products.Add(new("Сахар", 65.7f));
            _products.Add(new("Сыр", 465.7f));
            _products.Add(new("Кефир", 115.7f));
            _products.Add(new("Йогурт", 55.3f));
            _products.Add(new("Булочка", 35.7f));
            _products.Add(new("Шоколадка", 150.5f));
            _products.Add(new("Икра", 1599.9f));
        }

        public void StartStore()
        {
            const string LaunchBuyers = "1";
            const string ShowProducts = "2";
            const string Exit = "3";

            string input;

            while (_isWork)
            {
                Console.WriteLine("Супермаркет");
                Console.WriteLine($"{} Запустить случайное количество покупателей");
                Console.WriteLine($"{} Показать товары");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case LaunchBuyers:
                        break;

                    case ShowProducts:
                        break;

                    case Exit:
                        _isWork = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в меню управления магазином");
                        break;
                }
            }
        }

        public void AddRandomBuyer()
        {
            int minBuyer = 1;
            int maxBuyer = 15;
            int minWalletMoney = 1000;
            int maxWalletMoney = 5000;


            int TotalBuyer = UserUtils.GenerateRandomNumber(minBuyer, minBuyer);

            for (int i = 0; i < TotalBuyer; i++)
            {
                _bayer.Enqueue(new("Покупатель" + i + 1, UserUtils.GenerateRandomNumber(minWalletMoney,maxWalletMoney)));
            }
        }

    }
    class Kassa
    {

    }


    //private static int ReadFighterInt(int totalFighters)
    //{
    //    int inputNumber;
    //    bool isNotCorrect = true;

    //    do
    //    {
    //        if ((int.TryParse(Console.ReadLine(), out inputNumber)) == false)
    //        {
    //            Console.WriteLine("Введено не число");
    //            continue;
    //        }
    //        else
    //        {
    //            if (inputNumber <= totalFighters && inputNumber > 0)
    //            {
    //                isNotCorrect = false;
    //            }
    //            else
    //            {
    //                Console.WriteLine("Бойца с данным номером нет");
    //            }
    //        }
    //    } while (isNotCorrect);

    //    return inputNumber;
    //}

    //public abstract Warrior Clone();

    //public override Warrior Clone()
    //{
    //    return new Assassine(Name, Damage, Defence, Health);
    //}




    class Products
    {
        private string _title;
        private float _price;
        private string _description;

        public Products(string title, float price, string description = "")
        {
            _title = title;
            _price = price;
            _description = description;
        }

        public override string ToString()
        {
            return $"Продукт {_title}, цена {_price}, примечание {_description}";
        }
    }

    class Buyer
    {
        private string _name;
        private float _wallet;

        private List<Products> _shoppingBasket;
        private List<Products> _bag;

        public Buyer(string name, float wallet)
        {

        }

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



