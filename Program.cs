namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buyer buyer = new Buyer();
            Seller seller = new();

            buyer.AddMoney();
            seller.AddProducts();

            Shop shop = new(seller, buyer);
            Menu menu = new(shop);
            menu.Run();
        }
    }

    class Menu
    {
        private Shop _shop;
        private bool _isRunMenu = true;

        public Menu(Shop shop)
        {
            _shop = shop;
        }

        public void Run()
        {
            const string ShowProductsBayer = "1";
            const string ShowWalletSeller = "2";
            const string ShowWalletBayer = "3";
            const string SellProduct = "4";
            const string Exit = "5";

            while (_isRunMenu)
            {
                Console.WriteLine("\nСписок товаров магазина");
                _shop.ShowProducts();

                Console.WriteLine("\nМеню магазина");
                Console.WriteLine($"{ShowProductsBayer}. Показать товары покупателя");
                Console.WriteLine($"{ShowWalletSeller}. Показать деньги продавца");
                Console.WriteLine($"{ShowWalletBayer}. Показать деньги покупателя");
                Console.WriteLine($"{SellProduct}. Продать товар из списка");
                Console.WriteLine($"{Exit}. Выход");
                Console.WriteLine("Введите номер пункта меню");

                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowProductsBayer:
                        _shop.ShowList();
                        break;
                    case ShowWalletSeller:
                        _shop.ShowKassBalans();
                        break;
                    case ShowWalletBayer:
                        _shop.ShowBayerBalans();
                        break;
                    case SellProduct:
                        _shop.Trade();
                        break;
                    case Exit:
                        _isRunMenu = false;
                        break;
                    default:
                        Console.WriteLine($"Пункта под номером {input} не существует");
                        break;
                }
            }
        }
    }

    class Shop
    {
        private Seller _seller;
        private Buyer _buyer;

        public Shop(Seller seller, Buyer buyer)
        {
            _seller = seller;
            _buyer = buyer;
        }

        public void ShowProducts()
        {
            _seller.ShowList();
        }

        public void ShowList()
        {
            _buyer.ShowList();
        }

        public void ShowKassBalans()
        {
            _seller.ShowBalans();
        }

        public void ShowBayerBalans()
        {
            _buyer.ShowBalans();
        }

        public void Trade()
        {
            _seller.SellProduct(_buyer);
        }


    }

    class Product
    {
        public Product(string title, int price = 0)
        {
            Title = title;
            Price = price;
        }

        public string Title { get; private set; }
        public int Price { get; private set; }

        public override string ToString()
        {
            return $"Товар:{Title}\t\t\t\t\t\tЦена:{Price}";
        }
    }

    class Human
    {
        protected List<Product> Products = new();
        public int Money { get; protected set; }

        public void ShowBalans()
        {
            Console.Clear();
            Console.WriteLine($"В кошельке {Money} монет");
        }

        public void ShowList()
        {
            if (Products.Count > 0)
            {
                Console.WriteLine("**********************Список товаров**********************");
                Console.WriteLine(string.Join("\n", Products));
            }
            else
            {
                Console.WriteLine("**********************Список товаров**********************");
                Console.WriteLine("Список товаров пуст");
            }
            Console.WriteLine("**********************************************************");
        }
    }

    class Seller : Human
    {
        public void SellProduct(Buyer buyer)
        {
            Console.Clear();

            if (Products.Count > 0)
            {
                ShowList();
                Console.WriteLine("Введите номер покупки");

                int input = Utils.Read(Products.Count);

                if (Products[input].Price <= buyer.Money)
                {
                    buyer.BayProduct(Products[input]);
                    Sell(Products[input]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Денег не достаточно");
                }
            }
        }

        public void Sell(Product product)
        {
            Products.Remove(product);
            addMoney(product.Price);
        }

        private void addMoney(int price)
        {
            Money += price;
        }
        public void AddProducts()
        {
            Products.Add(new Product("Вода", 50));
            Products.Add(new Product("Мясо", 400));
            Products.Add(new Product("Картошка", 250));
        }
    }

    class Buyer : Human
    {
        public void BayProduct(Product product)
        {
            Products.Add(product);
            Pay(product.Price);
        }
        public void AddMoney()
        {
            Money += 1000;

        }

        private void Pay(int price)
        {
            Money -= price;
        }
    }
    static class Utils
    {
        public static int Read(int maxNumber)
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxNumber)
            {
                Console.WriteLine($"Введено не верный номер продукта максимальный номер {maxNumber + 1}");
            }
            return inputNumber - 1;
        }

        public static int Read()
        {
            int inputNumber;

            if (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0)
            {
                Console.WriteLine($"Введено не число или отрицательное число");
            }

            return inputNumber;
        }
    }
}
