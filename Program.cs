using System;
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
            string fullNameAndPosition = "";
            char separator = '|';

            Console.Write("\nВведите ФИО :");
            fullNameAndPosition += Console.ReadLine() + separator;
            Console.Write("\nВведите должность :");
            fullNameAndPosition += Console.ReadLine();

            EnlargeCopyNewArray(ref fullNames, ref positions, fullNameAndPosition);

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
            int inputDeleteDossier;
            bool isRepeat = true;

            do
            {
                Console.WriteLine($"Введите досье для удаления от 1 до {fullNames.Length}");
                inputDeleteDossier = ReadInt();

                if (inputDeleteDossier <= fullNames.Length && inputDeleteDossier > 0)
                {
                    inputDeleteDossier--;
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

        static void EnlargeCopyNewArray(ref string[] fullNames, ref string[] positions, string fullNameAndPosition)
        {
            int sizeArray = fullNames.Length + 1;
            char separator = '|';
            string[] newData = fullNameAndPosition.Split(separator);
            string[] fullNamesTemp = new string[sizeArray];
            string[] positionsTemp = new string[sizeArray];

            fullNamesTemp[fullNames.Length] = newData[0];
            positionsTemp[positions.Length] = newData[1];

            CopyArray(fullNames, fullNamesTemp);
            CopyArray(positions, positionsTemp);

            fullNames = fullNamesTemp;
            positions = positionsTemp;
        }

        static void ReduceCopyNewArray(ref string[] fullNames, ref string[] positions, int deleteDossier)
        {
            int sizeArray = fullNames.Length - 1;
            string[] fullNamesTemp = new string[sizeArray];
            string[] positionsTemp = new string[sizeArray];

            CopyArray(fullNames, fullNamesTemp, deleteDossier);
            CopyArray(positions, positionsTemp, deleteDossier);

            fullNames = fullNamesTemp;
            positions = positionsTemp;
        }

        static void CopyArray(string[] source, string[] destination)
        {
            for (int i = 0; i < source.Length; i++)
            {
                destination[i] = source[i];
            }
        }

        static void CopyArray(string[] source, string[] destination, int deleteIndex)
        {
            for (int i = 0, j = 0; i < source.Length; i++)
            {
                if (i != deleteIndex)
                {
                    destination[j] = source[i];
                    j++;
                }
            }
        }
    }
}

