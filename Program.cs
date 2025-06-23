using System.Linq;

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
                        AddDossier(personnelAccounting);
                        break;

                    case CommandListDossier:
                        ShowListDossier(personnelAccounting);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(personnelAccounting);
                        break;

                    case CommandExit:
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        Console.ReadKey();
                        break;
                }

                SendMessage();
            }
        }

        static void AddDossier(Dictionary<string, List<string>> personnelAccounting)
        {
            string post;
            string fullName;

            Console.WriteLine("Введите должность работника");
            post = ReadLine();
            Console.WriteLine("Введите ФИО работник");
            fullName = ReadLine();

            if (personnelAccounting.ContainsKey(post) == false)
            {
                personnelAccounting.Add(post, new List<string> { fullName });
            }
            else
            {
                personnelAccounting[post].Add(fullName);
            }
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
        }

        static void DeleteDossier(Dictionary<string, List<string>> personnelAccounting)
        {
            string inputDeletePosition;
            int inputDeleteFullName;

            Console.WriteLine($"Введите должность работника для удаления");
            inputDeletePosition = ReadLine();

            if (personnelAccounting.TryGetValue(inputDeletePosition, out List<string> workers))
            {
                ShowingEmployees(workers);

                Console.WriteLine($"\nВведите номер работника из списка для удаления");
                inputDeleteFullName = ReadInt();

                if (inputDeleteFullName > workers.Count || inputDeleteFullName <= 0)
                {
                    Console.WriteLine($"Работника с номером {inputDeleteFullName} не существует");
                    return;
                }

                workers.RemoveAt(inputDeleteFullName - 1);

                Console.WriteLine($"Работник удален");

                if (workers.Count == 0)
                {
                    personnelAccounting.Remove(inputDeletePosition);
                }
            }
            else
            {
                Console.WriteLine($"Должности {inputDeletePosition} не существует");
            }
        }

        static void SendMessage()
        {
            Console.WriteLine("\nДля продолжения нажмите любую кнопку");
            Console.ReadLine();
        }

        static void ShowingEmployees(List<string> workers)
        {
            int count = 0;

            foreach (var worker in workers)
            {
                ++count;
                Console.Write($"{count}-{worker}\t");
            }
        }

        static int ReadInt()
        {
            int inputNumber;

            while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
            {
                Console.WriteLine("Введено не число");
            }

            return inputNumber;
        }

        static string ReadLine()
        {
            return Console.ReadLine().ToLower();
        }

    }
}