namespace ijuniorPractice

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.StartStore();
        }
    }

    class Supermarket
    {
        private List<Product> _products = new();
        private Queue<Buyer> _bayers = new();
        private Cashier _cashier = new();
        private float _moneyCashDesk = 0;
        private bool _isWork = true;

        public Supermarket()
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
            const string Seller = "2";
            const string ShowAllProducts = "3";
            const string Exit = "4";

            string input;

            while (_isWork)
            {
                Console.WriteLine("Супермаркет");
                Console.WriteLine($"{LaunchBuyers} Запустить случайное количество покупателей");
                Console.WriteLine($"{Seller} Обработать заказы текущей очереди покупателей");
                Console.WriteLine($"{ShowAllProducts} Показать товары");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case LaunchBuyers:
                        AddRandomBuyer();
                        break;
                    
                    case Seller:
                        ServeBuyer();
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
            int minBuyer = 3;
            int maxBuyer = 15;
            int minWalletMoney = 1000;
            int maxWalletMoney = 5000;

            int TotalBuyer = UserUtils.GenerateRandomNumber(minBuyer, maxBuyer);

            for (int i = 0; i < TotalBuyer; i++)
            {
                Buyer buyer = new("Покупатель" + (i + 1), UserUtils.GenerateRandomNumber(minWalletMoney, maxWalletMoney));
        
                Console.WriteLine(buyer);
                
                buyer.AddRandomProduct(_products);
                
                _bayers.Enqueue(buyer);
            }
        }

        public void ServeBuyer()
        {
            if (_bayers.Count == 0)
            {
                Console.WriteLine($"\nПокупателей нет впустите их\n");
            }
            
            while (_bayers.Count > 0)
            {
                Buyer buyer = _bayers.Dequeue();
                
                _cashier.PurchaseProcessing(buyer);
                
                _moneyCashDesk += _cashier.RemoveCashDesk();
            }
            
            Console.WriteLine($"\nСумма в кассе = {_moneyCashDesk}\n");
        }
    }

    class Cashier
    {
        private Buyer _buyer;
        private List<Product> _sellProducts;
        private float _sumPriceProduct;
        private float _money;

        public void PurchaseProcessing(Buyer buyer)
        {
            bool isNoMoney = true;

            PunchProduct(buyer);

            do
            {
                SumProduct();

                if (EnoughMoney())
                {
                    isNoMoney = false;
                    
                    _buyer.TakeOutAllProduct();
            
                    _money = _buyer.GiveMoney(_sumPriceProduct);
                    
                    Console.WriteLine($"{_buyer} купил товары на сумму {_money}\n");
                    
                    _sellProducts.Clear();
                }
                else
                {
                    _buyer.RemoveRandomProduct();
                }
            }
            while (isNoMoney);
        }

        private void PunchProduct(Buyer buyer)
        {
            _buyer = buyer;
            _sellProducts = _buyer.TransferProduct();
            
            _buyer.BuyProduct( _sellProducts );
        }

        private void SumProduct()
        {
            _sumPriceProduct = 0;

            foreach (var product in _sellProducts)
            {
                _sumPriceProduct += product.ShowPrice();
            }
        }

        private bool EnoughMoney()
        {
            return _sumPriceProduct < _buyer.ShowMoney();
        }

        public float RemoveCashDesk()
        {
            float cash = _money;
            _money = 0;
            return cash;
        }
    }

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
     
        public Product Take()
        {
            return new Product(_title, _price, _description);
        }

        public override string ToString()
        {
            return $"Продукт {_title}, цена {_price}, ({_description})";
        }

        public float ShowPrice()
        {
            return _price;
        }
    }

    class Buyer
    {
        private string _name;
        private float _wallet;
        private Basket _basket = new();
        private Bag _bag = new();

        public Buyer(string name, float wallet)
        {
            _name = name;
            _wallet = wallet;
        }

        public void AddRandomProduct(List<Product> products)
        {
            int minQuantityProducts = 1;
            int maxQuantityProducts = products.Count();
            int randomNumber = UserUtils.GenerateRandomNumber(minQuantityProducts, maxQuantityProducts);

            for (int i = 0; i < randomNumber; i++)
            {
                int randomIndex = UserUtils.GenerateRandomNumber(minQuantityProducts, maxQuantityProducts);

                Product product = products[randomIndex - 1].Take();

                Console.WriteLine($"В корзине - {product}");

                _basket.AddProduct(products[randomIndex - 1].Take());
            }

            Console.WriteLine();
        }

        public void BuyProduct(List<Product> products)
        {
            foreach (var product in products)
            {
                _bag.AddProduct(product);
            }
        }

        public List<Product> TransferProduct()
        {
            return _basket.PullProduct();
        }

        public float ShowMoney()
        {
            return _wallet;
        }

        public void TakeOutAllProduct()
        {
            _basket.RemoveAllProduct();
        }

        public void RemoveRandomProduct()
        {
            Console.Write($"{_name} выкладывает: ");
            int indexProduct = UserUtils.GenerateRandomNumber(0, _basket.TotalProducts());
            _basket.RemoveProduct(indexProduct);
        }

        public float GiveMoney(float needMoney)
        {
            _wallet -= needMoney;
            return needMoney;
        }

        public override string ToString()
        {
            return $"{_name} денег {_wallet}";
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
        
        public List<Product> PullProduct()
        {
            return _products;
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

        public int TotalProducts()
        {
            return _products.Count;
        }
        public void RemoveAllProduct()
        {
            _products = null;
        }


        public void RemoveProduct(int index)
        {
            Console.WriteLine($"Товар {_products[index]} ----- УБРАН ИЗ КОРЗИРНЫ");
            _products.RemoveAt(index);
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





