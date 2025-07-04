﻿using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddPlayer = "1";
            const string CommandShowAllPlayers = "2";
            const string CommandRemovePlayer = "3";
            const string CommandBannedPlayer = "4";
            const string CommandExit = "5";

            Database database = new Database();

            string inputUser;

            do
            {
                Console.Clear();
                Console.WriteLine(CommandAddPlayer + " Добавить нового игрока в базу");
                Console.WriteLine(CommandShowAllPlayers + " Показать всех игроков в базе");
                Console.WriteLine(CommandRemovePlayer + " Удаление игрока из базы");
                Console.WriteLine(CommandBannedPlayer + " Забанить игрока");
                Console.WriteLine(CommandExit + " Выход" + "\n");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddPlayer:
                        database.AddPlayer();
                        break;

                    case CommandShowAllPlayers:
                        database.ShowPlayers();
                        break;

                    case CommandRemovePlayer:
                        database.DeletePlayer();
                        break;

                    case CommandBannedPlayer:
                        database.BanPlayer();
                        break;

                    case CommandExit:
                        Console.WriteLine($"Программа завершила работу");
                        break;

                    default:
                        Console.WriteLine("Данного пункта в меню нет");
                        break;
                }

                Console.ReadKey();
            }
            while (inputUser != CommandExit);
        }
    }

    class Player
    {
        public Player(int identifier, string name, int level, bool isBanned)
        {
            Identifier = identifier;
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public int Identifier { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
                IsBanned = true;
            Console.WriteLine("Игрок забанен");
        }

        public void UnBan()
        {
                IsBanned = false;
            Console.WriteLine("Игрок разбанен");
        }

        public void Show()
        {
            Console.Write("ID: " + Identifier + "\t\t");
            Console.Write("Имя: " + Name + "\t\t\t");
            Console.Write("Уровень: " + Level + "\t\t");
            Console.Write("Забанен: " + (IsBanned ? "Да" : "Нет") + "\t");
            Console.WriteLine();
        }
    }

    class Database
    {
        private int _identifierCounter = 1;

        private List<Player> _players = new List<Player>();

        public void AddPlayer()
        {
            int identifier = _identifierCounter;
            string name = "";
            int level = 0;
            bool isBanned = false;

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();

            Console.WriteLine("Введите лвл игрока");
            level = ReadInt();

            Player player = new Player(identifier, name, level, isBanned);
            _identifierCounter++;

            _players.Add(player);
        }

        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                player.Show();
            }
        }

        public void DeletePlayer()
        {
            ShowPlayers();

            Console.WriteLine("\nДля удаления");
            Player player = SerchPlayer();

            _players.Remove(player);
        }

        public void BanPlayer()
        {
            ShowPlayers();

            Console.WriteLine("\nДля бана или разбана");
            Player player = SerchPlayer();

            if (player.IsBanned)
                player.UnBan();
            else
                player.Ban();
        }

        private int ReadInt()
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число");
            }

            return inputNumber;
        }

        private Player SerchPlayer()
        {
            int inputPlayerId;
            Player player;

            do
            {
                Console.WriteLine("Введите ID игрока");
                inputPlayerId = ReadInt();
                player = _players.Find(item => item.Identifier == inputPlayerId);
            }
            while (player == null);

            return player;
        }
    }
}

