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
            const string CommandNextMenu = "\nДля продолжения нажмите любую кнопку";
            const string CommandSuccessful = "\nИзменения внесены";

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
                        ListDossier(fullNames, positions);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case CommandSearchDossier:
                        SearchDossier(fullNames, positions);
                        break;
                    case CommandExit:
                        isContinue = false;
                        Console.WriteLine("До свидания");
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        Console.WriteLine(CommandNextMenu);
                        Console.ReadKey();
                        break;
                }
            }

            static void AddDossier(ref string[] fullNames, ref string[] positions)
            {
                string[] addFullNames = new string[fullNames.Length + 1];
                string[] addPosition = new string[positions.Length + 1]; ;

                Console.Write("\nВведите ФИО :");
                addFullNames[fullNames.Length] = Console.ReadLine();
                Console.Write("\nВведите должность :");
                addPosition[positions.Length] = Console.ReadLine();

                CopyNewArray(ref fullNames, ref positions, ref addFullNames, ref addPosition);

                Console.WriteLine(CommandSuccessful);
                Console.WriteLine(CommandNextMenu);
                Console.ReadLine();
            }

            static void ListDossier(string[] fullNames, string[] positions)
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

                    Console.WriteLine(CommandNextMenu);
                    Console.ReadLine();
                }
            }

            static void DeleteDossier(ref string[] fullNames, ref string[] positions)
            {
                int inputDeleteDossier = -1;
                bool isRepeat = true;
                string[] fullNameCutBack = new string[fullNames.Length - 1];
                string[] positionsCutBack = new string[positions.Length - 1];

                do
                {
                    Console.WriteLine($"Введите досье для удаления от 1 до {fullNames.Length}");
                    inputDeleteDossier = ReadInt(inputDeleteDossier);

                    if (inputDeleteDossier <= fullNames.Length && inputDeleteDossier > 0)
                    {
                        isRepeat = false;
                    }
                }
                while (isRepeat);

                fullNames[inputDeleteDossier - 1] = fullNames[fullNames.Length - 1];
                positions[inputDeleteDossier - 1] = positions[positions.Length - 1];

                CopyNewArray(ref fullNames, ref positions, ref fullNameCutBack, ref positionsCutBack);

                Console.WriteLine(CommandSuccessful);
                Console.WriteLine(CommandNextMenu);
                Console.ReadKey();
            }

            static void SearchDossier(string[] fullNames, string[] positions)
            {
                string inputSearchString;
                int showing = 0;
                string[] surname;

                Console.Write("\nВведите фамилию для поиска: ");
                inputSearchString = Console.ReadLine().ToLower();
                Console.WriteLine();

                foreach (string index in fullNames)
                {
                    surname = index.Split(' ');

                    if (surname[0].ToLower().IndexOf(inputSearchString, 0) != -1)
                    {
                        Console.WriteLine(index);
                        showing++;
                    }
                }
                if (showing == 0)
                {
                    Console.WriteLine("Поиск не дал результатов");
                }

                Console.WriteLine(CommandNextMenu);
                Console.ReadKey();
            }

            static int ReadInt(int inputNumber)
            {
                while (int.TryParse(Console.ReadLine(), out inputNumber) == false)
                {
                    Console.WriteLine("Введено не число");
                }

                return inputNumber;
            }

            static void CopyNewArray(ref string[] fullName, ref string[] positions, ref string[] fullNameTemp, ref string[] positionsTemp)
            {
                int sizeArray = 0;

                if (fullName.Length < fullNameTemp.Length)
                {
                    sizeArray = fullName.Length;
                }
                else
                {
                    sizeArray = fullName.Length - 1;
                }

                for (int i = 0; i < sizeArray; i++)
                {
                    fullNameTemp[i] = fullName[i];
                    positionsTemp[i] = positions[i];
                }

                fullName = fullNameTemp;
                positions = positionsTemp;
            }
        }
    }
}



