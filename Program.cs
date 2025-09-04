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
            const string ShowWolletSeller = "3";
            const string ShowWolletBayer = "4";
            const string SellProduct = "5";
            const string AddProductSeller = "6";
            const string AddBayerMoney = "7";
            const string Exit = "8";

            while (_isRunMenu)
            {
                Console.WriteLine("\nМеню программы");
                Console.WriteLine($"{ShowProductsSeller}. Показать товары продавца");
                Console.WriteLine($"{ShowProductsBayer}. Показать товары покупателя");
                Console.WriteLine($"{ShowWolletSeller}. Показать деньги продавца");
                Console.WriteLine($"{ShowWolletBayer}. Показать деньги покупателя");
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
                    case ShowWolletSeller:
                        _seller.ShowBalans();
                        break;
                    case ShowWolletBayer:
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

    class Products
    {
        public Products(string title, int price = 0)
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
        protected List<Products> _list = new();
        public int Money { get; protected set; }
        public string Name { get; private set; }

        public void ShowBalans()
        {
            Console.Clear();
            Console.WriteLine($"В кошельке {Money} монет");
        }

        public void ShowList()
        {
            Console.Clear();

            if (_list.Count > 0)
            {
                Console.WriteLine(string.Join("\n", _list));
            }
            else
            {
                Console.WriteLine("Список товаров пуст");
            }
        }

        public void AddProducts()
        {
            int inputPrice = 0;

            Console.Clear();
            Console.WriteLine("Введите название товара");
            string inputProduct = Console.ReadLine();
            
            Console.WriteLine("Введите цену товара");
            int.TryParse(Console.ReadLine(), out inputPrice);
            
            _list.Add(new Products(inputProduct, inputPrice));

        }
    }

    class Seller : People
    {
        public void SellProduct(Bayer bayer)
        {
            Console.Clear();
            ShowList();

            Console.WriteLine("Введите номер покупки");
         
            int input = ReadInt(_list.Count) - 1;

            if (_list[input].Price <= bayer.Money)
            {
                bayer.BayProduct(_list[input]);
                Sell(_list[input]);
            }
            else
            {
                Console.WriteLine("Денег не достаточно");
            }
        }

        public void Sell(Products product)
        {
            _list.Remove(product);
            Sell(product.Price);
        }

        private void Sell(int price)
        {
            Money += price;
        }

        private int ReadInt(int maxIndex)
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false || inputNumber <= 0 || inputNumber > maxIndex)
            {
                Console.WriteLine($"Введено не верный номер продукта максимальный номер {maxIndex + 1}");
            }

            return inputNumber;
        }
    }

    class Bayer : People
    {
        public void BayProduct(Products product)
        {
            _list.Add(product);
            Pay(product.Price);
        }

        private void Pay(int price)
        {
            Money -= price;
        }

        public void AddMoney()
        {
            int input = 0;

            Console.Clear();
            Console.WriteLine("Введите сумму денег клиента");
         
            if (int.TryParse(Console.ReadLine(), out input))
            {
                Money += input;
            }
        }
    }
}