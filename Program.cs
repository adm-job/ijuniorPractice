using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandListDossier = "2";
            const string CommandDeleteDossier = "3";
            const string CommandExit = "4";

            Dictionary<string, List<string>> personnelAccounting = new Dictionary<string, List<string>>();

            string inputUser;
            bool isContinue = true;

            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine($"{CommandAddDossier} Добавить досье");
                Console.WriteLine($"{CommandListDossier} Список всех досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandExit} Выход");
                Console.Write("\nВведите номер пункта меню: ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddDossier:
                        AddDossier(ref personnelAccounting);
                        break;

                    case CommandListDossier:
                        ShowListDossier(personnelAccounting);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref personnelAccounting);
                        break;

                    case CommandExit:
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddDossier(ref Dictionary<string, List<string>> personnelAccounting)
        {
            string[] positionsAndFullname = new string[2];

            Console.WriteLine("Введите должность работника");
            positionsAndFullname[0] = Console.ReadLine()
                                             .ToLower();
            Console.WriteLine("Введите ФИО работник");
            positionsAndFullname[1] = Console.ReadLine()
                                             .ToLower();

            AddElement(ref personnelAccounting, positionsAndFullname);

            SendMessage();
        }

        static void ShowListDossier(Dictionary<string, List<string>> personnelAccounting)
        {
            foreach (var position in personnelAccounting)
            {
                Console.Write($"Должность: {position.Key} - Работники:");

                foreach (var value in position.Value)
                {
                    Console.Write($" {value}");
                }

                Console.WriteLine();
            }

            SendMessage();
        }

        static void DeleteDossier(ref Dictionary<string, List<string>> personnelAccounting)
        {
            string inputDeleteFullName;

            Console.WriteLine($"Введите ФИО работника для удаления");
            inputDeleteFullName = Console.ReadLine()
                                         .ToLower();

            foreach (string key in personnelAccounting.Keys)
            {
                if (personnelAccounting[key].Contains(inputDeleteFullName))
                {
                    personnelAccounting[key].Remove(inputDeleteFullName);

                    Console.WriteLine($"Работник удален");

                    if (personnelAccounting[key].Count == 0)
                    {
                        personnelAccounting.Remove(key);
                    }
                }
                else
                {
                    Console.WriteLine($"На должности {key} работник с фио {inputDeleteFullName} не найден");
                }
            }

            SendMessage();
        }

        static void SendMessage()
        {
            Console.WriteLine("\nДля продолжения нажмите любую кнопку");
            Console.ReadLine();
        }

        static void AddElement(ref Dictionary<string, List<string>> personnelAccounting, string[] positionsAndFullname)
        {
            string position;

            position = positionsAndFullname[0];

            if (personnelAccounting.ContainsKey(position))
            {
                personnelAccounting[position].Add(positionsAndFullname[1]);
            }
            else
            {
                personnelAccounting.Add(position, new List<string> { positionsAndFullname[1] });
            }
        }
    }
}