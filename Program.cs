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
            Battle battle = new Battle();
            battle.StartAttack();
        }
    }

    class Battle
    {
        private static readonly int CompanySize = 100;
        private bool isAttack = true;

        private List<Soldier> _firstCompany = new();
        private List<Soldier> _secondCompany = new();

        public void StartAttack()
        {
            CreateCompany();

            int round = 1;


            while (isAttack)
            {
                Console.WriteLine(round);

                foreach (var soldier in _firstCompany)
                {
                    soldier.Attack(_secondCompany);

                    if (_secondCompany.Count == 0)
                    {
                        isAttack = false;
                        break;
                    }
                }

                round++;
                Console.ReadLine();
                Console.WriteLine(round);

                foreach (var soldier in _secondCompany)
                {
                    soldier.Attack(_firstCompany);

                    if (_firstCompany.Count == 0)
                    {
                        isAttack = false;
                        break;
                    }
                }

                round++;
                Console.ReadLine();
            }

            Console.WriteLine(_firstCompany.Count > 0 ? "\nПобедила первая рота" : "\nПобедила вторая рота");
        }

        public void CreateCompany()
        {
            for (int i = 0; i < CompanySize; i++)
            {
                _firstCompany.Add(CreateRandomSoldier());
                _secondCompany.Add(CreateRandomSoldier());
            }
        }

        private Soldier CreateRandomSoldier()
        {
            int SizeList = 10;
            int RandomNumber = UserUtils.GenerateRandomNumber(0, SizeList);

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

        public virtual void Attack(List<Soldier> soldiers)
        {
            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");

            int target = UserUtils.GenerateRandomNumber(0, soldiers.Count);

            soldiers[target].TakeDamage(Damage);
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

        public override void Attack(List<Soldier> soldiers)
        {
            float multiplication = 3f;
            float finalDamage = Damage * multiplication;

            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
            
            int index = UserUtils.GenerateRandomNumber(0, soldiers.Count);
            Soldier target = soldiers[index];
            target.TakeDamage(finalDamage);

            if (target.Health <= 0)
            {
                soldiers.Remove(target);
            }
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

        public override void Attack(List<Soldier> soldiers)
        {
            float hitProbability = 0.05f;
            int takeTarget = (int)(soldiers.Count * hitProbability);

            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
            
            var targets = Enumerable.Range(0, takeTarget)
                .Select(_ => soldiers[UserUtils.GenerateRandomNumber(0, soldiers.Count)])
                .ToList();

            foreach (var target in targets)
            {
                target.TakeDamage(Damage);

                if (target.Health <= 0)
                {
                    soldiers.Remove(target);
                }
            }
        }

        public Soldier Clone()
        {
            return new Gunner(Rank, Damage, Health);
        }
    }

    class Grenadier : Soldier
    {
        public Grenadier(string rank = "Гранатометчик", float damage = 20, float health = 100) : base(rank, damage, health)
        {
        }

        public override void Attack(List<Soldier> soldiers)
        {
            float hitProbability = 0.15f;
            int takeTarget = (int)(soldiers.Count * hitProbability);

            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
        
            var targets = soldiers
                .OrderBy(_ => UserUtils.GenerateRandomNumber())
                .Take(takeTarget)
                .ToList();

            foreach (var target in targets)
            {
                target.TakeDamage(Damage);

                if (target.Health <= 0)
                {
                    soldiers.Remove(target);
                }
            }
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
