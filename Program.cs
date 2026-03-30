using System.Xml.Linq;


namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            battle.StartAttack();
        }
    }

    class Battle
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
                Console.WriteLine("---------------------------" + round + "---------------------------");

                team1.Attack(team2);

                if (team2.Size > 0)
                {
                    round++;
                    Console.ReadLine();
                    Console.WriteLine(round);
                }
                else
                {
                    return;
                }

                team2.Attack(team1);

                if (team1.Size > 0)
                {
                    round++;
                    Console.ReadLine();
                    Console.WriteLine(round);
                }
                else
                {
                    return;
                }
            }

            team1.RemoveDead();
            team2.RemoveDead();
            Console.WriteLine(team1.Size > 0 ? "\nПобедила первая рота" : "\nПобедила вторая рота");
        }
    }

    class Team
    {
        private SoldierFactory _factory = new SoldierFactory();
        private List<Soldier> _band;
        private int _size;

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
            _band.RemoveAll(value => value.Health <= 0);
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

        public virtual void Attack(IEnumerable<Soldier> enemys)
        {
            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

            Soldier target = GetRandomTarget(enemys);

            target.TakeDamage(Damage);
        }

        protected Soldier GetRandomTarget(IEnumerable<Soldier> enemys)
        {
            var soldier = enemys.Where(enemy => enemy.Health > 0).ToList();

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

            Console.WriteLine($"-Нанесен урон {damage} ранен {Rank} - ({Damage}) - ({Health})");
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

        public override void Attack(IEnumerable<Soldier> enemys)
        {
            float multiplication = 3f;
            float finalDamage = Damage * multiplication;

            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

            Soldier target = GetRandomTarget(enemys);
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

        public override void Attack(IEnumerable<Soldier> enemys)
        {
            float hitProbability = 0.05f;
            int maxEnemys = enemys.Count();
            int minEnemys = 0;
            int takeTarget = Math.Max(1,(int)(enemys.Count() * hitProbability));

            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
            var enemysList = enemys.ToList();

            var targets = Enumerable.Range(0, takeTarget)
                .Select(_ => enemysList[UserUtils.GenerateRandomNumber(0, maxEnemys)])
                .ToList();
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
        }

        public override Soldier Clone()
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
