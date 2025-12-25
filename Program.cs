using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Supermarket supermarket = new Supermarket();
            //supermarket.StartStore();

            Battle battle = new Battle();
            battle.StartAttack();
        }
    }

    class Battle
    {
        private Soldier[] SquadSoldiers = new Soldier[10];
        private static readonly int CompanySize = 100;

        //private Soldier[] FirstCompany = new Soldier[CompanyMax];
        //private Soldier[] SecondCompany = new Soldier[CompanyMax];

        private List<Soldier> _firstCompany = new();
        private List<Soldier> _secondCompany = new();

        public Battle()
        {
            SquadSoldiers[0] = new Soldier();
            SquadSoldiers[1] = new Soldier();
            SquadSoldiers[2] = new Soldier();
            SquadSoldiers[3] = new Soldier();
            SquadSoldiers[4] = new Sniper();
            SquadSoldiers[5] = new Sniper();
            SquadSoldiers[6] = new Sniper();
            SquadSoldiers[7] = new Gunner();
            SquadSoldiers[8] = new Gunner();
            SquadSoldiers[9] = new Grenadier();
        }

        public void StartAttack()
        {
            SetSoldiers();

            do
            {
                for (int i = 0; i < FirstCompany?.Length; i++)
                {
                    FirstCompany[i].Attack(SecondCompany);
                }

                for (int i = 0; i < SecondCompany?.Length; i++)
                {
                    SecondCompany[i].Attack(FirstCompany);
                }
            
            } while (FirstCompany.Length != 0 && SecondCompany.Length != 0);


        }

        public void SetSoldiers()
        {
            for (int i = 0; i < CompanySize; i++)
            {
                FirstCompany[i] = RandomObjectSoldier();
                SecondCompany[i] = RandomObjectSoldier();
            }
        }

        private Soldier RandomObjectSoldier()
        {
            int RandomIndex = -1;
            RandomIndex = UserUtils.GenerateRandomNumber(0, SquadSoldiers.Length);

            return SquadSoldiers[RandomIndex].Clone();
        }
    }

    class Soldier
    {
        protected string Rank;
        protected float Damage;
        protected float Health;

        public Soldier(string rank = "Солдат", float damage = 10, float health = 100)
        {
            Rank = rank;
            Damage = damage;
            Health = health;
        }

        public virtual void Attack(Soldier[] soldiers)
        {
            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
            soldiers[SelectSoldierIndex(soldiers)].TakeDamage(Damage);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            Console.WriteLine($"-Нанесен урон {damage} ранен {Rank} - ({Damage}) - ({Health})");
        }

        protected int SelectSoldierIndex(Soldier[] soldiers)
        {
            return UserUtils.GenerateRandomNumber(0, soldiers.Length);
        }

        public override string ToString()
        {
            return $"{Rank} - ({Damage}) - ({Health})";
        }

        public Soldier Clone()
        {
            return new Soldier(Rank, Damage, Health);
        }
    }

    class Sniper : Soldier
    {
        public Sniper(string rank = "Снайпер", float damage = 10, float health = 100) : base(rank, damage, health)
        {
        }

        public override void Attack(Soldier[] soldiers)
        {
            float multiplication = 3f;
            float finalDamage = Damage * multiplication;

            Console.WriteLine($"{Rank}");
            soldiers[SelectSoldierIndex(soldiers)].TakeDamage(finalDamage);
        }

        public Soldier Clone()
        {
            return new Sniper(Rank, Damage, Health);
        }
    }

    class Gunner : Soldier
    {
        public Gunner(string rank = "Пулеметчик", float damage = 11, float health = 100) : base(rank, damage, health)
        {
        }

        public override void Attack(Soldier[] soldiers)
        {
            int[] HitSoldiersIndex = SelectListIndexAttack(soldiers);
            Console.WriteLine($"{this.Rank}");
            foreach (var index in HitSoldiersIndex)
            {
                soldiers[index].TakeDamage(Damage);
            }
        }

        private int[] SelectListIndexAttack(Soldier[] soldiers)
        {
            float percentageHits = 0.25f;
            int totalSoldiersHit = (int)(soldiers.Length * percentageHits);
            int[] indexSolder = new int[totalSoldiersHit];

            for (int i = 0; i < totalSoldiersHit; i++)
            {
                indexSolder[i] = SelectSoldierIndex(soldiers);
            }

            return indexSolder;
        }

        public Soldier Clone()
        {
            return new Gunner(Rank, Damage, Health);
        }
    }

    class Grenadier : Soldier
    {
        private string _rank;
        public Grenadier(string rank = "Гранатометчик", float damage = 20, float health = 100) : base(rank, damage, health)
        {
            _rank = rank;
        }

        public override void Attack(Soldier[] soldiers)
        {
            int[] HitSoldiersIndex = SelectListIndexAttack(soldiers);

            Console.WriteLine($"{_rank}");
            foreach (var index in HitSoldiersIndex)
            {
                soldiers[index].TakeDamage(Damage);
            }
        }

        private int[] SelectListIndexAttack(Soldier[] soldiers)
        {
            float percentageHits = 0.40f;
            int totalSoldiersHit = (int)(soldiers.Length * percentageHits);
            int[] indexSolder = new int[totalSoldiersHit];
            int countAddSoldiers = 0;

            do
            {
                int index = SelectSoldierIndex(soldiers);
                int duplicate = Array.IndexOf(indexSolder, index);

                if (duplicate <= 0)
                {
                    indexSolder[countAddSoldiers] = index;
                    countAddSoldiers++;
                }

            } while (countAddSoldiers != totalSoldiersHit);

            return indexSolder;
        }

        public Soldier Clone()
        {
            return new Grenadier(Rank, Damage, Health);
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



//class Supermarket
//{
//    private List<Product> _products = new();
//    private Queue<Buyer> _bayers = new();
//    private Cashier _cashier = new();
//    private float _moneyCashDesk = 0;
//    private bool _isWork = true;

//    public Supermarket()
//    {
//        _products.Add(new("Банан", 75.5f, "Желтый"));
//        _products.Add(new("Тушенка", 245f, "Вкусная"));
//        _products.Add(new("Колбаса", 345.8f, "Из мяса"));
//        _products.Add(new("Молоко", 90f, "Свежее"));
//        _products.Add(new("Пельмени", 419.2f, "Свинина-Говядина"));
//        _products.Add(new("Вода", 39.9f, "Не газированная"));
//        _products.Add(new("Чипсы", 189.9f, "Сметана с зеленью"));
//        _products.Add(new("Хлеб", 55f, "Бородинский"));
//        _products.Add(new("Соль", 25.4f, "Экстра мелкая"));
//        _products.Add(new("Сахар", 65.7f, "Рафинад"));
//        _products.Add(new("Сыр", 465.7f, "Твердый"));
//        _products.Add(new("Кефир", 115.7f, "Обезжиренный 1%"));
//        _products.Add(new("Йогурт", 55.3f, "Клубника-банан"));
//        _products.Add(new("Булочка", 35.7f, "С наполнителем вишня"));
//        _products.Add(new("Шоколадка", 150.5f, " Наполнитель орехи"));
//        _products.Add(new("Икра", 1599.9f, "Банка 250г"));
//    }

//    public void ShowProducts()
//    {
//        foreach (var product in _products)
//        {
//            Console.WriteLine(product);
//        }
//    }

//    public void StartStore()
//    {
//        const string LaunchBuyers = "1";
//        const string Seller = "2";
//        const string ShowAllProducts = "3";
//        const string Exit = "4";

//        string input;

//        while (_isWork)
//        {
//            Console.WriteLine("Супермаркет");
//            Console.WriteLine($"{LaunchBuyers} Запустить случайное количество покупателей");
//            Console.WriteLine($"{Seller} Обработать заказы текущей очереди покупателей");
//            Console.WriteLine($"{ShowAllProducts} Показать товары");
//            Console.WriteLine($"{Exit} Выход");

//            input = Console.ReadLine();

//            switch (input)
//            {
//                case LaunchBuyers:
//                    AddRandomBuyer();
//                    break;

//                case Seller:
//                    ServeBuyer();
//                    break;

//                case ShowAllProducts:
//                    ShowProducts();
//                    break;

//                case Exit:
//                    _isWork = false;
//                    break;

//                default:
//                    Console.WriteLine("Выбранного пункта нет в меню управления магазином");
//                    break;
//            }
//        }
//    }

//    public void AddRandomBuyer()
//    {
//        int minBuyer = 3;
//        int maxBuyer = 15;
//        int minWalletMoney = 1000;
//        int maxWalletMoney = 5000;
//        int totalBuyer = UserUtils.GenerateRandomNumber(minBuyer, maxBuyer);

//        for (int i = 0; i < totalBuyer; i++)
//        {
//            Buyer buyer = new("Покупатель" + (i + 1), UserUtils.GenerateRandomNumber(minWalletMoney, maxWalletMoney));

//            Console.WriteLine(buyer);

//            buyer.AddRandomProduct(_products);

//            _bayers.Enqueue(buyer);
//        }
//    }

//    public void ServeBuyer()
//    {
//        if (_bayers.Count == 0)
//        {
//            Console.WriteLine($"\nПокупателей нет впустите их\n");
//        }

//        while (_bayers.Count > 0)
//        {
//            Buyer buyer = _bayers.Dequeue();

//            _cashier.PurchaseProcessing(buyer);

//            _moneyCashDesk += _cashier.RemoveCashDesk();
//        }

//        Console.WriteLine($"\nСумма в кассе = {_moneyCashDesk}\n");
//    }
//}

//class Cashier
//{
//    private Buyer _buyer;
//    private List<Product> _sellProducts;
//    private float _sumPriceProduct;
//    private float _money;

//    public void PurchaseProcessing(Buyer buyer)
//    {
//        bool isNoMoney = true;
//        int totalProductBasket = 0;

//        _buyer = buyer;

//        do
//        {
//            totalProductBasket = _buyer.TotalProduct();

//            SumProduct(totalProductBasket);

//            if (EnoughMoney())
//            {
//                isNoMoney = false;

//                _money = _buyer.GiveMoney(_sumPriceProduct);

//                _buyer.BuyProduct();

//                Console.WriteLine($"{_buyer} купил товары на сумму {_money}\n");
//            }
//            else
//            {
//                _buyer.RemoveRandomProduct();
//            }
//        }
//        while (isNoMoney);
//    }

//    private void SumProduct(int totalProduct)
//    {
//        _sumPriceProduct = 0;

//        for (int i = 0; i < totalProduct; i++)
//        {
//            _sumPriceProduct += _buyer.ReturnPrice(i);
//        }
//    }

//    private bool EnoughMoney()
//    {
//        return _sumPriceProduct < _buyer.ReturnMoney();
//    }

//    public float RemoveCashDesk()
//    {
//        float cash = _money;
//        _money = 0;
//        return cash;
//    }
//}

//class Product
//{
//    private string _title;
//    private float _price;
//    private string _description;

//    public Product(string title, float price, string description = "")
//    {
//        _title = title;
//        _price = price;
//        _description = description;
//    }

//    public Product Take()
//    {
//        return new Product(_title, _price, _description);
//    }

//    public override string ToString()
//    {
//        return $"Продукт {_title}, цена {_price}, ({_description})";
//    }

//    public float GetPrice()
//    {
//        return _price;
//    }
//}

//class Buyer
//{
//    private string _name;
//    private float _wallet;
//    private Basket _basket = new();
//    private Bag _bag = new();

//    public Buyer(string name, float wallet)
//    {
//        _name = name;
//        _wallet = wallet;
//    }

//    public void AddRandomProduct(List<Product> products)
//    {
//        int minQuantityProducts = 1;
//        int maxQuantityProducts = products.Count();
//        int randomNumber = UserUtils.GenerateRandomNumber(minQuantityProducts, maxQuantityProducts);

//        for (int i = 0; i < randomNumber; i++)
//        {
//            int randomIndex = UserUtils.GenerateRandomNumber(minQuantityProducts, maxQuantityProducts);

//            Product product = products[randomIndex - 1].Take();

//            Console.WriteLine($"В корзине - {product}");

//            _basket.AddProduct(products[randomIndex - 1].Take());
//        }

//        Console.WriteLine();
//    }

//    public int TotalProduct()
//    {
//        return _basket.ReturnTotalProducts();
//    }

//    public void BuyProduct()
//    {
//        _bag = _basket;
//        _basket = null;
//    }

//    public float ReturnMoney()
//    {
//        return _wallet;
//    }

//    public float ReturnPrice(int index)
//    {
//        return _basket.ReturnPriceProduct(index);
//    }

//    public void RemoveRandomProduct()
//    {
//        Console.Write($"{_name} выкладывает: ");
//        int indexProduct = UserUtils.GenerateRandomNumber(0, _basket.ReturnTotalProducts());
//        _basket.RemoveProduct(indexProduct);
//    }

//    public float GiveMoney(float needMoney)
//    {
//        _wallet -= needMoney;
//        return needMoney;
//    }

//    public override string ToString()
//    {
//        return $"{_name} денег {_wallet}";
//    }
//}

//class Bag
//{
//    protected List<Product> Products = new();

//    public void AddProduct(Product product)
//    {
//        Products.Add(product);
//    }

//    public void Show()
//    {
//        foreach (var product in Products)
//        {
//            Console.WriteLine(product);
//        }
//    }
//}

//class Basket : Bag
//{
//    public int ReturnTotalProducts()
//    {
//        return Products.Count;
//    }

//    public void RemoveProduct(int index)
//    {
//        Console.WriteLine($"Товар {Products[index]} ----- УБРАН ИЗ КОРЗИРНЫ");

//        Products.RemoveAt(index);
//    }

//    public float ReturnPriceProduct(int index)
//    {
//        return Products[index].GetPrice();
//    }
//}

