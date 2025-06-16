using System;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandListDossier = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchDossier = "4";
            const string CommandExit = "5";

            string[] fullNames = new string[0];
            string[] positions = new string[0];
            string inputUser;
            bool isContinue = true;

            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine($"{CommandAddDossier} Добавить досье");
                Console.WriteLine($"{CommandListDossier} Список всех досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandSearchDossier} Поиск по ФИО");
                Console.WriteLine($"{CommandExit} Выход");
                Console.Write("\nВведите номер пункта меню: ");
                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case CommandAddDossier:
                        AddDossier(ref fullNames, ref positions);
                        break;
                    case CommandListDossier:
                        ShowListDossier(fullNames, positions);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case CommandSearchDossier:
                        SearchDossier(fullNames);
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

        static void AddDossier(ref string[] fullNames, ref string[] positions)
        {
            string fullNameAndPositionAddAction = "";
            char separator = '|';

            Console.Write("\nВведите ФИО :");
            fullNameAndPositionAddAction += Console.ReadLine() + separator;
            Console.Write("\nВведите должность :");
            fullNameAndPositionAddAction += Console.ReadLine();

            EnlargeCopyNewArray(ref fullNames, ref positions, fullNameAndPositionAddAction);

            SendMessage();
            Console.ReadLine();
        }

        static void ShowListDossier(string[] fullNames, string[] positions)
        {
            if (fullNames.Length == positions.Length)
            {
                Console.WriteLine();

                for (int i = 0; i < fullNames.Length; i++)
                {
                    Console.Write(i + 1 + ". ");
                    Console.Write(fullNames[i] + " - ");
                    Console.WriteLine(positions[i]);
                }
                Console.WriteLine();
            }

            SendMessage();
            Console.ReadLine();
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] positions)
        {
            int inputDeleteDossier = -1;
            bool isRepeat = true;

            do
            {
                Console.WriteLine($"Введите досье для удаления от 1 до {fullNames.Length}");
                inputDeleteDossier = ReadInt();

                if (inputDeleteDossier <= fullNames.Length && inputDeleteDossier > 0)
                {
                    isRepeat = false;
                }
            }
            while (isRepeat);

            ReduceCopyNewArray(ref fullNames, ref positions, inputDeleteDossier);

            SendMessage();
            Console.ReadLine();
        }

        static void SearchDossier(string[] fullNames)
        {
            string inputSearchString;
            int resultsFound = 0;
            string[] surname;

            Console.Write("\nВведите фамилию для поиска: ");
            inputSearchString = Console.ReadLine().ToLower();
            Console.WriteLine();

            foreach (string fullName in fullNames)
            {
                surname = fullName.Split(' ');

                if (surname[0] == inputSearchString)
                {
                    Console.WriteLine(fullName);
                    resultsFound++;
                }
            }

            if (resultsFound == 0)
            {
                Console.WriteLine("Поиск не дал результатов");
            }

            SendMessage();
            Console.ReadLine();
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
        static void SendMessage()
        {
            Console.WriteLine("\nДля продолжения нажмите любую кнопку");
        }

        static void EnlargeCopyNewArray(ref string[] fullNames, ref string[] positions, string fullNameAndPositionAddAction)
        {
            char separator = '|';
            string[] newData = fullNameAndPositionAddAction.Split(separator);

            string[] fullNamesTemp = new string[fullNames.Length + 1];
            string[] positionsTemp = new string[positions.Length + 1];

            fullNamesTemp[fullNames.Length] = newData[0];
            positionsTemp[positions.Length] = newData[1];

            for (int i = 0; i < fullNames.Length; i++)
            {
                fullNamesTemp[i] = fullNames[i];
                positionsTemp[i] = positions[i];
            }

            fullNames = fullNamesTemp;
            positions = positionsTemp;
        }

        static void ReduceCopyNewArray(ref string[] fullNames, ref string[] positions, int deleteDossier)
        {
            string[] fullNamesTemp = new string[fullNames.Length - 1];
            string[] positionsTemp = new string[positions.Length - 1];

            for (int i = 0; i < deleteDossier - 1; i++)
            {
                fullNamesTemp[i] = fullNames[i];
                positionsTemp[i] = positions[i];
            }

            for (int i = deleteDossier; i <= fullNamesTemp.Length; i++)
            {
                fullNamesTemp[i - 1] = fullNames[i];
                positionsTemp[i - 1] = positions[i];
            }
            fullNames = fullNamesTemp;
            positions = positionsTemp;
        }
    }
}

