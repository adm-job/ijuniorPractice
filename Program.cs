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
            const string CommandSearchDossier = "4";
            const string CommandExit = "5";

            Dictionary<string, List<string>> personnelAccounting = new Dictionary<string, List<string>>();

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
                        AddDossier(ref personnelAccounting);
                        break;

                    case CommandListDossier:
                        ShowListDossier(personnelAccounting);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(ref personnelAccounting);
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

        static void AddDossier(ref Dictionary<string, List<string>> perpersonnelAccounting)
        {
            string[] positionsAndFullname = new string[2];

            Console.WriteLine("Ввдедите должность работника");
            positionsAndFullname[0] = Console.ReadLine().ToLower();
            Console.WriteLine("Ввдедите ФИО работник");
            positionsAndFullname[1] = Console.ReadLine().ToLower();

            AddElement(ref perpersonnelAccounting, positionsAndFullname);

            SendMessage();
        }

        static void ShowListDossier(Dictionary<string, List<string>> perpersonnelAccounting)
        {
            foreach (var position in perpersonnelAccounting)
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
                    isRepeat = false;
                }
            }
            while (isRepeat);

            RemoveElement(ref fullNames, inputDeleteDossier);
            RemoveElement(ref positions, inputDeleteDossier);

            SendMessage();
        }

        static void DeleteDossier(ref Dictionary<string,Lazy<string>> perpersonnelAccounting)
        {
            string inputDeleteFullName = "";
            bool isRepeat = true;

            do
            {
                Console.WriteLine($"Введите ФИО работника для удаления");
                inputDeleteFullName = Console.ReadLine().ToLower();

                for (int i = 0; i < perpersonnelAccounting.Count;  i++)
                {
                    perpersonnelAccounting.ContainsValue(new List<string> { inputDeleteFullName});

                }
                        
                        
                    
                
                
                
/*                if (inputDeleteFullName <= fullNames.Length && inputDeleteFullName > 0)
                {
                    isRepeat = false;
                }*/
            }
            while (isRepeat);

            //RemoveElement(ref fullNames, inputDeleteDossier);
           
            SendMessage();
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
                surname = fullName.Split();

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
                personnelAccounting[position].Add( positionsAndFullname[1]);
            }
            else
            {
                personnelAccounting.Add(position, new List<string> { positionsAndFullname[1] });
            }
        }
        
        static void RemoveElement(ref string[] array, int idElement)
        {
            int sizeArray = array.Length - 1;
            string[] tempArray = new string[sizeArray];

            for (int i = 0; i < idElement; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = idElement; i <= sizeArray; i++)
            {
                tempArray[i - 1] = array[i];
            }

            array = tempArray;
        }
    }
}