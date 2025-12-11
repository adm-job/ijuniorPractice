namespace ijuniorPractice

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.AddProductsShowcase();
            supermarket.StartStore();

        }
    }

    class Supermarket
    {
        private List<Product> _products = new List<Product>();
        private Queue<Buyer> _bayer = new Queue<Buyer>();
        private float _money = 0;
        private bool _isWork = true;

        public void AddProductsShowcase()
        {
            _products.Add(new("Банан", 75.5f, "Желтый"));
            _products.Add(new("Тушенка", 245f, "Вкусная"));
            _products.Add(new("Колбаса", 345.8f, "Из мяса"));
            _products.Add(new("Молоко", 90f, "Свежее"));
            _products.Add(new("Пельмени", 419.2f, "Свинина-Говядина"));
            _products.Add(new("Вода", 39.9f, "Не газированная"));
            _products.Add(new("Чипсы", 189.9f, "Сметана с зеленью"));
            _products.Add(new("Хлеб", 55f, "Бородинский"));
            _products.Add(new("Соль", 25.4f, "Экстра мелкая"));
            _products.Add(new("Сахар", 65.7f, "Рафинад"));
            _products.Add(new("Сыр", 465.7f, "Твердый"));
            _products.Add(new("Кефир", 115.7f, "Обезжиренный 1%"));
            _products.Add(new("Йогурт", 55.3f, "Клубника-банан"));
            _products.Add(new("Булочка", 35.7f, "С наполнителем вишня"));
            _products.Add(new("Шоколадка", 150.5f, " Наполнитель орехи"));
            _products.Add(new("Икра", 1599.9f, "Банка 250г"));
        }

        public void ShowProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }

        public void StartStore()
        {
            const string LaunchBuyers = "1";
            const string ShowAllProducts = "2";
            const string Exit = "3";

            string input;

            while (_isWork)
            {
                Console.WriteLine("Супермаркет");
                Console.WriteLine($"{LaunchBuyers} Запустить случайное количество покупателей");
                Console.WriteLine($"{ShowAllProducts} Показать товары");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case LaunchBuyers:
                        break;

                    case ShowAllProducts:
                        ShowProducts();
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
                _bayer.Enqueue(new("Покупатель" + i + 1, UserUtils.GenerateRandomNumber(minWalletMoney, maxWalletMoney)));
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




    class Product
    {
        private string _title;
        private float _price;
        private string _description;

        public Product(string title, float price, string description = "")
        {
            _title = title;
            _price = price;
            _description = description;
        }

        public override string ToString()
        {
            return $"Продукт {_title}, цена {_price}, ({_description})";
        }
    }

    class Buyer
    {
        private string _name;
        private float _wallet;

        private Basket _basket;
        private Bag _bag;

        public Buyer(string name, float wallet)
        {

        }

    }

    class Bag
    {
        protected List<Product> _products = new();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void Show()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product);
            }
        }
    }

    class Basket : Bag
    {
        public Product GetProduct(int index)
        {
            Product product = _products[index];
            _products.RemoveAt(index);

            return product;
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



