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

        private List<Soldier> _firstCompany = new();
        private List<Soldier> _secondCompany = new();

        public void StartAttack()
        {
            CreateCompany();

            int round = 1;

            while (_firstCompany.Count > 0 && _secondCompany.Count > 0)
            {
                Console.WriteLine($"\n--- Раунд {round} ---");

                AttackCompany(_firstCompany, _secondCompany);
                AttackCompany(_secondCompany, _firstCompany);

                round++;
            }

            Console.WriteLine(_firstCompany.Count > 0 ? "\nПобедила первая рота" : "\nПобедила вторая рота");
        }

        private void AttackCompany(List<Soldier> attackers, List<Soldier> defenders)
        {
            if (defenders.Count == 0)
            {
                return;
            }

            foreach (var attacker in attackers.ToList())
            {
                if (defenders.Count == 0)
                {
                    break;
                }

                if (attacker is Grenadier)
                {
                    float hitProbability = 0.40f;
                    int takeTarget = (int)(defenders.Count * hitProbability);
                    var targets = defenders
                        .OrderBy(_ => UserUtils.GenerateRandomNumber())
                        .Take(takeTarget)
                        .ToList();

                    foreach (var target in targets)
                    {
                        attacker.Attack(target);
                        if (target.Health <= 0)
                        {
                            defenders.Remove(target);
                        }
                    }
                }
                else if (attacker is Gunner)
                {
                    int takeTarget = (int)(defenders.Count * 0.25);

                    var targets = Enumerable.Range(0, takeTarget)
                        .Select(_ => defenders[UserUtils.GenerateRandomNumber(0, defenders.Count)])
                        .ToList();

                    foreach (var target in targets)
                    {
                        attacker.Attack(target);

                        if (target.Health <= 0)
                        {
                            defenders.Remove(target);
                        }
                    }
                }
                else
                {
                    Soldier target = defenders[UserUtils.GenerateRandomNumber(0, defenders.Count)];

                    attacker.Attack(target);

                    if (target.Health <= 0)
                    {
                        Console.WriteLine($"☠ {target.Rank} погиб");
                        {
                            defenders.Remove(target);
                        }
                    }
                }
            }
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
                0 => new Soldier(),
                1 => new Soldier(),
                2 => new Soldier(),
                3 => new Soldier(),
                4 => new Sniper(),
                5 => new Sniper(),
                6 => new Sniper(),
                7 => new Gunner(),
                8 => new Gunner(),
                9 => new Grenadier(),
                _ => new Soldier()
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

        public virtual void Attack(Soldier target)
        {
            Console.WriteLine($"Атакует {Rank} - ({Damage}) - ({Health})");
            target.TakeDamage(Damage);
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

        public override void Attack(Soldier soldiers)
        {
            float multiplication = 3f;
            float finalDamage = Damage * multiplication;

            Console.WriteLine($"{Rank}");
            soldiers.TakeDamage(finalDamage);
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
