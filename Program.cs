namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuAquarist MenuAquarist = new MenuAquarist();
            MenuAquarist.Run();
        }
    }

    class MenuAquarist
    {
        private Tank _tank;
        private bool _isRunMenu = true;

        public void Run()
        {
            const string AddFish = "1";
            const string AddAllFish = "2";
            const string ShowAllFhsh = "3";
            const string Exit = "4";

            _tank = new Tank();

            while (_isRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Меню аквариума");

                Console.WriteLine(AddFish + " Добавить рыбку");
                Console.WriteLine(AddAllFish + " Заполнить аквариум полностью");
                Console.WriteLine(ShowAllFhsh + " Посмотреть в аквариум");
                Console.WriteLine(Exit + " Уйти от аквариума");

                Console.WriteLine("\nВведите номер пункта меню");

                string input = Console.ReadLine();
                Console.WriteLine();

                _tank.ShowAllFish();

                Console.Read();
            }
        }
    }

    class Fish
    {
        private string _name;
        private float _timeLife;

        public Fish(string name = "Рыбка", int life = 300)
        {
            _name = name;
            _timeLife = life;
        }

        public override string ToString()
        {
            return $"Житель аквариума {_name} время жизни {_timeLife}";
        }

        public void live()
        {
            _timeLife--;
        }

        private void Die()
        {
            _timeLife = 0;
        }
    }

    class Tank
    {
        private List<Fish> _pisces;
        private int maxFish = 10;

        public Tank()
        {
            _pisces = new List<Fish>();
            AddMaxFish();
        }

        public void AddFish()
        {
            if (_pisces.Count < maxFish)
            {
                _pisces.Add(new Fish());
            }
            else
            {
                Console.WriteLine("Аквариум заполнен");
            }
        }

        public void AddMaxFish()
        {
            for (int i = _pisces.Count; i < maxFish; i++)
            {
                _pisces.Add(new Fish());
            }
        }

        public void ClearAllFish()
        {
            _pisces.Clear();
        }

        public void ShowAllFish()
        {
            if (_pisces.Count > 0)
            {
                foreach (Fish fish in _pisces)
                {
                    Console.WriteLine(fish);
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст");
            }
        }

    }



    /*    class Battle
        {
            private static readonly int TeamSize = 100;
            private bool isAttack = true;

            private Team team1 = new Team(TeamSize);
            private Team team2 = new Team(TeamSize);

            public void StartAttack()
            {
                int round = 1;

                while (isAttack)
                {
                    if (team1.Size > 0 && team2.Size > 0)
                    {
                        Console.WriteLine("---------------------------" + round + "---------------------------");
                        round++;

                        Console.WriteLine("Атакует 1 отряд");
                        team1.Attack(team2);

                        Console.WriteLine("Атакует 2 отряд");
                        team2.Attack(team1);


                        team1.RemoveDead();
                        Console.WriteLine("\n" + team1.Size + "РАЗМЕР ГРУППУ РАВЕН");
                        team2.RemoveDead();
                        Console.WriteLine(team2.Size + "РАЗМЕР ГРУППУ РАВЕН\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        isAttack = false;
                    }
                }

                Console.WriteLine(team1.Size > 0 ? "Победила первая рота" : "Победила вторая рота");
            }
        }

        class Team
        {
            private SoldierFactory _factory = new SoldierFactory();
            private List<Soldier> _band;

            public int Size { get; private set; }

            public Team(int totalSize)
            {
                _band = _factory.Conscription(totalSize).ToList();
                Size = _band.Count;
            }

            public void Attack(Team team)
            {
                foreach (var soldier in _band)
                {
                    soldier.Attack(team.ReturnSoldiers());
                }
            }

            public IEnumerable<Soldier> ReturnSoldiers()
            {
                return _band;
            }

            public void RemoveDead()
            {
                _band.RemoveAll(soldier => soldier.Health <= 0);
                Size = _band.Count();
            }
        }

        class SoldierFactory
        {
            private int _size;
            private List<Soldier> _soldiers = new List<Soldier>();

            public int Size { get; private set; }

            public List<Soldier> Conscription(int size)
            {
                _size = size;

                CreateCompany();

                return _soldiers;
            }

            private void CreateCompany()
            {
                for (int i = 0; i < _size; i++)
                {
                    _soldiers.Add(CreateRandom());
                }
            }

            private Soldier CreateRandom()
            {
                int sizeList = 10;
                int RandomNumber = UserUtils.GenerateRandomNumber(0, sizeList);

                return RandomNumber switch
                {
                    0 => new Soldier().Clone(),
                    1 => new Soldier().Clone(),
                    2 => new Soldier().Clone(),
                    3 => new Soldier().Clone(),
                    4 => new Sniper().Clone(),
                    5 => new Sniper().Clone(),
                    6 => new Sniper().Clone(),
                    7 => new Gunner().Clone(),
                    8 => new Gunner().Clone(),
                    9 => new Grenadier().Clone(),
                    _ => new Soldier().Clone()
                };
            }
        }

        class Soldier
        {
            public Soldier(string rank = "Солдат", float damage = 10, float health = 100)
            {
                Rank = rank;
                Damage = damage;
                Health = health;
            }

            public string Rank { get; private set; }
            public float Damage { get; private set; }
            public float Health { get; private set; }

            public virtual void Attack(IEnumerable<Soldier> enemies)
            {
                Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

                Soldier target = GetRandomTarget(enemies);

                if (target == null)
                {
                    return;
                }

                target.TakeDamage(Damage);
            }

            protected Soldier GetRandomTarget(IEnumerable<Soldier> enemies)
            {
                var soldier = enemies.Where(enemy => enemy.Health > 0).ToList();
                if (soldier.Count == 0)
                {
                    return null;
                }

                int index = UserUtils.GenerateRandomNumber(0, soldier.Count());

                return soldier[index];
            }

            public void TakeDamage(float damage)
            {
                Health -= damage;

                if (Health < 0)
                {
                    Health = 0;
                }

                Console.WriteLine($"-Нанесен урон {damage} \nранен {Rank} - ({Damage}) - ({Health})");
            }


            public override string ToString()
            {
                return $"{Rank} - ({Damage}) - ({Health})";
            }

            public virtual Soldier Clone()
            {
                return new Soldier(Rank, Damage, Health);
            }
        }

        class Sniper : Soldier
        {
            public Sniper(string rank = "Снайпер", float damage = 10, float health = 100) : base(rank, damage, health)
            {
            }

            public override void Attack(IEnumerable<Soldier> enemies)
            {
                float multiplication = 3f;
                float finalDamage = Damage * multiplication;

                Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

                Soldier target = GetRandomTarget(enemies);

                if (target == null)
                {
                    return;
                }

                target.TakeDamage(finalDamage);
            }

            public override Soldier Clone()
            {
                return new Sniper(Rank, Damage, Health);
            }
        }

        class Gunner : Soldier
        {
            public Gunner(string rank = "Пулеметчик", float damage = 11, float health = 100) : base(rank, damage, health)
            {
            }

            public override void Attack(IEnumerable<Soldier> enemies)
            {
                float hitProbability = 0.05f;
                int maxEnemys = enemies.Count();
                int minEnemys = 0;
                int takeTarget = Math.Max(1, (int)(enemies.Count() * hitProbability));

                Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
                var enemiesList = enemies.ToList();

                var targets = Enumerable.Range(0, takeTarget)
                    .Select(_ => enemiesList[UserUtils.GenerateRandomNumber(0, maxEnemys)])
                    .ToList();

                if (targets == null)
                {
                    return;
                }

                foreach (Soldier target in targets)
                {
                    target.TakeDamage(Damage);
                }
            }

            public override Soldier Clone()
            {
                return new Gunner(Rank, Damage, Health);
            }
        }

        class Grenadier : Soldier
        {
            public Grenadier(string rank = "Гранатометчик", float damage = 20, float health = 100) : base(rank, damage, health)
            {
            }

            public override void Attack(IEnumerable<Soldier> enemys)
            {
                float hitProbability = 0.15f;
                int takeTarget = Math.Max(1, (int)(enemys.Count() * hitProbability));

                Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

                var targets = enemys
                    .OrderBy(_ => UserUtils.GenerateRandomNumber())
                    .Take(takeTarget)
                    .ToList();

                if (targets == null)
                {
                    return;
                }

                foreach (Soldier target in targets)
                {
                    target.TakeDamage(Damage);
                }
            }

            public override Soldier Clone()
            {
                return new Grenadier(Rank, Damage, Health);
            }
        }*/

    class UserUtils
    {
        private static Random s_random = new();

        public static int GenerateRandomNumber(int min = 0, int max = 100)
        {
            return s_random.Next(min, max);
        }
    }


}
