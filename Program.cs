namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bayer bayer = new Bayer();
            Seller seller = new();
            Menu menu = new(seller, bayer);
            menu.Run();
        }
    }

    class Menu
    {
        private Bayer _bayer;
        private Seller _seller;
        private bool _isRunMenu = true;

        public Menu(Seller seller, Bayer bayer)
        {
            _seller = seller;
            _bayer = bayer;
        }

        public void Run()
        {
            const string ShowProductsSeller = "1";
            const string ShowProductsBayer = "2";
            const string ShowWalletSeller = "3";
            const string ShowWalletBayer = "4";
            const string SellProduct = "5";
            const string AddProductSeller = "6";
            const string AddBayerMoney = "7";
            const string Exit = "8";

            while (_isRunMenu)
            {
                Console.WriteLine("\nСписок товаров магазина");
                _seller.ShowList();

                Console.WriteLine("\nМеню магазина");
                Console.WriteLine($"{ShowProductsSeller}. Показать товары продавца");
                Console.WriteLine($"{ShowProductsBayer}. Показать товары покупателя");
                Console.WriteLine($"{ShowWalletSeller}. Показать деньги продавца");
                Console.WriteLine($"{ShowWalletBayer}. Показать деньги покупателя");
                Console.WriteLine($"{SellProduct}. Продать товар из списка");
                Console.WriteLine($"{AddProductSeller}. Добавить товары продавцу");
                Console.WriteLine($"{AddBayerMoney}. Добавить деньги покупателю");
                Console.WriteLine($"{Exit}. Выход");
                Console.WriteLine("Введите номер пункта меню");

                string input = Console.ReadLine();

                switch (input)
                {
                    case ShowProductsSeller:
                        _seller.ShowList();
                        break;
                    case ShowProductsBayer:
                        _bayer.ShowList();
                        break;
                    case ShowWalletSeller:
                        _seller.ShowBalans();
                        break;
                    case ShowWalletBayer:
                        _bayer.ShowBalans();
                        break;
                    case SellProduct:
                        _seller.SellProduct(_bayer);
                        break;
                    case AddProductSeller:
                        _seller.AddProducts();
                        break;
                    case AddBayerMoney:
                        _bayer.AddMoney();
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

    class People
    {
        protected List<Product> List = new();
        public int Money { get; protected set; }

        public void ShowBalans()
        {
            Console.Clear();
            Console.WriteLine($"В кошельке {Money} монет");
        }

        public void ShowList()
        {
            Console.WriteLine("**********************Список товаров**********************");

            if (List.Count > 0)
            {
                Console.WriteLine(string.Join("\n", List));
            }
            else
            {
                Console.WriteLine("Список товаров пуст");
            }
            Console.WriteLine("**********************************************************");
        }

        public void AddProducts()
        {

            Console.Clear();
            Console.WriteLine("Введите название товара");
            string inputProduct = Console.ReadLine();

            Console.WriteLine("Введите цену товара");
            int inputPrice = ReadInt.Read();

            List.Add(new Product(inputProduct, inputPrice));

        }
    }

    class Seller : People
    {
        public void SellProduct(Bayer bayer)
        {
            Console.Clear();

            if (List.Count > 0)
            {
                ShowList();
                Console.WriteLine("Введите номер покупки");

                int input = ReadInt.Read(List.Count);

                if (List[input].Price <= bayer.Money)
                {
                    bayer.BayProduct(List[input]);
                    Sell(List[input]);
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
            List.Remove(product);
            Sell(product.Price);
        }

        private void Sell(int price)
        {
            Money += price;
        }
    }

    class Bayer : People
    {
        public void BayProduct(Product product)
        {
            List.Add(product);
            Pay(product.Price);
        }
        public void AddMoney()
        {
            Console.Clear();
            Console.WriteLine("Введите сумму денег клиента");

            int input = ReadInt.Read();
            Money += input;

        }

        private void Pay(int price)
        {
            Money -= price;
        }
    }
    static class ReadInt
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
