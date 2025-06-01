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
            const string CommandNextMenu = "\nДля продолжения нажмите любую кнопку";
            const string CommandSuccessful = "\nИзменения внесены";

            string[] fullName = new string[0];
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
                        AddDossier(ref fullName, ref positions);
                        break;
                    case CommandListDossier:
                        ListDossier(ref fullName, ref positions);
                        break;
                    case CommandDeleteDossier:
                        DeleteDossier(ref fullName, ref positions);
                        break;
                    case CommandSearchDossier:
                        SearchDossier(fullName, positions);
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

            static void AddDossier(ref string[] fullName, ref string[] positions)
            {
                string[] addFullName = new string[fullName.Length + 1];
                string[] addPosition = new string[positions.Length + 1]; ;

                Console.Write("\nВведите ФИО :");
                addFullName[fullName.Length] = Console.ReadLine();
                Console.Write("\nВведите должность :");
                addPosition[positions.Length] = Console.ReadLine();


                CopyNewArray(ref  fullName, ref positions, ref addFullName, ref  addPosition);

/*                for (int i = 0; i < fullName.Length; i++)
                {
                    addFullName[i] = fullName[i];
                    addPosition[i] = positions[i];
                }

                fullName = addFullName;
                positions = addPosition;
*/
                Console.WriteLine(CommandSuccessful);
                Console.WriteLine(CommandNextMenu);
                Console.ReadLine();
            }

            static void ListDossier(ref string[] fullName, ref string[] positions)
            {
                if (fullName.Length == positions.Length)
                {
                    Console.WriteLine();

                    for (int i = 0; i < fullName.Length; i++)
                    {
                        Console.Write(i + 1 + ". ");
                        Console.Write(fullName[i] + " - ");
                        Console.WriteLine(positions[i]);
                    }

                    Console.WriteLine(CommandNextMenu);
                    Console.ReadLine();
                }
            }

            static void DeleteDossier(ref string[] fullName, ref string[] positions)
            {
                int inputDeleteDossier = -1;
                bool isRepeat = true;
                string[] fullNameCutBack = new string[fullName.Length - 1];
                string[] positionsCutBack = new string[positions.Length - 1];

                do
                {
                    Console.WriteLine($"Введите досье для удаления от 1 до {fullName.Length}");
                    inputDeleteDossier = ReadInt(inputDeleteDossier);

                    if (inputDeleteDossier <= fullName.Length && inputDeleteDossier > 0)
                    {
                        isRepeat = false;
                    }
                }
                while (isRepeat);

                fullName[inputDeleteDossier - 1] = fullName[fullName.Length - 1];
                positions[inputDeleteDossier - 1] = positions[positions.Length - 1];

                CopyNewArray(ref fullName, ref positions, ref fullNameCutBack, ref positionsCutBack);

                /*for (int i = 0; i < fullName.Length - 1; i++)
                {
                    fullNameCutBack[i] = fullName[i];
                    positionsCutBack[i] = positions[i];
                }

                fullName = fullNameCutBack;
                positions = positionsCutBack;*/

                Console.WriteLine(CommandSuccessful);
                Console.WriteLine(CommandNextMenu);
                Console.ReadKey();
            }

            static void SearchDossier(string[] fullName, string[] positions)
            {
                string inputSearchString;
                int showing = 0;

                Console.Write("\nВведите строку для поиска: ");
                inputSearchString = Console.ReadLine().ToLower();
                Console.WriteLine();

                foreach (string index in fullName)
                {
                    if (index.ToLower().IndexOf(inputSearchString, 0) != -1)
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
                for (int i = 0; i < fullNameTemp.Length; i++)
                {
                    fullName[i] = fullName[i];
                    positionsTemp[i] = positions[i];
                }

                fullName = fullNameTemp;
                positions = positionsTemp;
            }
        }
    }
}



