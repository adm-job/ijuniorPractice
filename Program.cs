using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleBoard battleBoard = new BattleBoard();
            battleBoard.Begin();
        }
    }

    class BattleBoard
    {
        private bool _isShowBattle = true;
        private Arena _arena = new();

        public void Begin()
        {
            string input;

            const string StartBattle = "1";
            const string ShowGladiators = "2";
            const string Exit = "3";

            while (_isShowBattle)
            {
                Console.WriteLine("Колизей");
                Console.WriteLine($"{StartBattle} Начать поединок");
                Console.WriteLine($"{ShowGladiators} Показать гладиаторов");
                Console.WriteLine($"{Exit} Выход");

                input = Console.ReadLine();

                switch (input)
                {
                    case StartBattle:
                        _arena.Battle();
                        break;

                    case ShowGladiators:
                        _arena.WarriorShow();
                        break;

                    case Exit:
                        _isShowBattle = false;
                        break;

                    default:
                        Console.WriteLine("Выбранного пункта нет в списке");
                        break;
                }
            }
        }
    }

    class Arena
    {
        private int _fighterNomber;
        private Warrior _firstFighter;
        private Warrior _secondFighter;

        private List<Warrior> _warriors = new List<Warrior>
        {
            new Assassine("Убийца"),
            new Barbarian("Варвар"),
            new Berserker("Берсерк"),
            new Mage("Маг"),
            new Monkey("Изворотливый"),
            new Tank("Бронированный")
        };

        public void WarriorShow()
        {
            int number = 1;

            Console.Clear();

            foreach (var warrior in _warriors)
            {
                Console.Write(number + " ");
                Console.WriteLine(warrior);
                number++;
            }
        }

        public void Battle()
        {
            WarriorShow();

            Console.WriteLine("Выберете первого бойца");
            _fighterNomber = ReadCorrectInt(_warriors.Count) - 1;
            _firstFighter = _warriors[_fighterNomber].Clone();

            Console.WriteLine("Выберете второго бойца");
            _fighterNomber = ReadCorrectInt(_warriors.Count) - 1;
            _secondFighter = _warriors[_fighterNomber].Clone();

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                float damage1 = _firstFighter.Attack();
                _secondFighter.TakeDamage(damage1);
                Console.Write($"Гладиатор {_firstFighter.Name} нанес {damage1}\t");
                Console.WriteLine(_secondFighter.ShowCurrentHealth());

                if (_secondFighter.Health <= 0)
                    break;

                float damage2 = _secondFighter.Attack();
                _firstFighter.TakeDamage(damage2);
                Console.Write($"Гладиатор {_secondFighter.Name} нанес {damage2}\t");
                Console.WriteLine(_firstFighter.ShowCurrentHealth());

            }
        }

        private static int ReadCorrectInt(int totalFighters)
        {
            int inputNumber;
            bool isNotCorrect = true;

            do
            {
                if ((int.TryParse(Console.ReadLine(), out inputNumber)) == false)
                {
                    Console.WriteLine("Введено не число");
                    continue;
                }
                else
                {
                    if (inputNumber <= totalFighters && inputNumber > 0)
                    {
                        isNotCorrect = false;
                    }
                    else
                    {
                        Console.WriteLine("Бойца с данным номером нет");
                    }
                }
            }while (isNotCorrect);


            return inputNumber;
        }
    }


    abstract class Warrior
    {
        protected float PercentMax = 100f;

        public Warrior(string name, float damage = 25, float defence = 10, float health = 1000)
        {
            Name = name;
            Damage = damage;
            Defence = defence;
            Health = health;
        }

        public string Name { get; private set; }
        public float Damage { get; protected set; }
        public float Defence { get; protected set; }
        public float Health { get; protected set; }

        public string ShowCurrentHealth()
        {
            return $"Гладиатор {Name} имеет {Health} жизней и {Defence} зашиты";
        }

        public virtual float Attack()
        {
            //return Damage; <<<<<-----
        }

        public virtual void TakeDamage(float damage)
        {
            float totalDamage = (damage - (damage * Defence / PercentMax));
            Health -= totalDamage > 0 ? totalDamage : 1;
        }

        public override string ToString()
        {
            return $"Гладиатор\n {Name}: Урон({Damage}), Защита({Defence}), Жизни({Health}) \n";
        }

        public abstract Warrior Clone();
    }

    class Assassine : Warrior
    {
        private float _chanceDubleDamage = 19f;
        private float _damageMultiplier = 3;

        public Assassine(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override float Attack()
        {
            if (UserUtils.GenerateRandomNumber() < _chanceDubleDamage)
            {
                Console.WriteLine($"{this.Name} нанес увеличенный на {_damageMultiplier} урон");
                return Damage * _damageMultiplier;
            }
            else
            {
                return Damage;
            }
        }

        public override Warrior Clone()
        {
            return new Assassine(this.Name, this.Damage, this.Defence, this.Health);
        }
    }

    class Barbarian : Warrior
    {
        private int _scoreMaxAttack = 3;
        private int _score = 0;

        public Barbarian(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override float Attack()
        {
            if (_score < _scoreMaxAttack)
            {
                _score++;

                return Damage;
            }
            else
            {
                _score = 0;
                Console.WriteLine($"{this.Name} произвел серию из {_scoreMaxAttack} ударов и нанес двойной урон");

                return Damage + Damage;
            }
        }

        public override Warrior Clone()
        {
            return new Barbarian(this.Name, this.Damage, this.Defence, this.Health);
        }


    }

    class Berserker : Warrior
    {
        private int _rageCounter = 0;
        private int _rageGetting = 25;
        private int _rageMax = 100;

        public Berserker(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override void TakeDamage(float damage)
        {
            float healedAmount = 50f;

            _rageCounter += _rageGetting;

            if (_rageCounter >= _rageMax)
            {
                _rageCounter = 0;
                Console.WriteLine($"{this.Name} ярость накоплена, получено лечение {healedAmount}");

                Health += healedAmount;
            }

            base.TakeDamage(damage);
        }

        public override Warrior Clone()
        {
            return new Berserker(this.Name, this.Damage, this.Defence, this.Health);
        }
    }

    class Mage : Warrior
    {
        private int _mana = 100;
        private int _fireballDamage = 100;
        private int _manaFireball = 25;

        public Mage(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override float Attack()
        {
            if (_mana >= _manaFireball)
            {
                _mana -= _manaFireball;
                Console.WriteLine($"{this.Name} читает заклинание с уроном {_fireballDamage}");
                return _fireballDamage;
            }

            return Damage;
        }

        public override Warrior Clone()
        {
            return new Mage(this.Name, this.Damage, this.Defence, this.Health);
        }

    }

    class Monkey : Warrior
    {
        private int _evasion = 45;

        public Monkey(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override void TakeDamage(float damage)
        {
            if (UserUtils.GenerateRandomNumber() < _evasion)
            {
                Console.WriteLine($"{Name} Уклонился от атаки");
                damage = 0;
            }

            base.TakeDamage(damage);
        }

        public override Warrior Clone()
        {
            return new Monkey(this.Name, this.Damage, this.Defence, this.Health);
        }
    }

    class Tank : Warrior
    {
        private float _boostProtection = 1;
        private float _maxBoostProtection = 60;

        public Tank(string name, float damage = 25, float defence = 10, float health = 1000) : base(name, damage, defence, health)
        {
        }

        public override void TakeDamage(float damage)
        {
            Console.WriteLine($"{Name} защита увеличена на {_boostProtection}");

            if (Defence < _maxBoostProtection)
                Defence += _boostProtection;

            base.TakeDamage(damage);
        }

        public override Warrior Clone()
        {
            return new Tank(Name, Damage, Defence, Health);
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



