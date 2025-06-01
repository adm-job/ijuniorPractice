namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MainMenu();
            static void Main(string[] args)
            {
                /*
                string pangram = "The quick brown fox jumps over the lazy dog";
                System.Console.WriteLine(pangram);
                string[] result = pangram.Split(" ");
                for (int i = 0; i< result.Length;i++)
                {
                    char[] chars = result[i].ToCharArray();
                    Array.Reverse(chars);
                    result[i] = new string(chars);
                }
                Console.WriteLine(String.Join(" ",result));
                */

                // string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
                // string[] arrayOrder = orderStream.Split(",");
                // Array.Sort(arrayOrder);
                // foreach(string order in arrayOrder)
                // {
                //     if(order.Length == 4)
                //         System.Console.WriteLine(order);
                //     else
                //         System.Console.WriteLine(order + "\t-ERROR");
                // }   
                Dictionary<string, string> dictionaryMeanings = new Dictionary<string, string>();


            }

            static void FillDictionary(ref Dictionary<string, string> dictionary)
            {
                dictionary.Add("Синоним", "Слова одной части речи или словосочетания с полным или частичным совпадением значения");
                dictionary.Add("Антоним", "Слова одной части речи, различные по звучанию и написанию, имеющие прямо противоположные лексические значения, например: «правда» — «ложь»");
                dictionary.Add("Омоним", "Одинаковые по написанию и звучанию, но разные по значению слова и другие единицы языка");
                dictionary.Add("Пароним", "Слова, сходные по звучанию и морфемному составу, но различающиеся лексическим значением");
                dictionary.Add("Омофон", "Одинаково произносящиеся, но по-разному пишущиеся слова: плот и плод");
                dictionary.Add("Омоним", "Одинаково произносящиеся и пишущиеся, но не связанные по значению слова: коса (вид причёски), коса (сельскохозяйственный инструмент), коса (узкая полоска земли, окружённая водой)");
            }
        
    
/*
        static void MainMenu()
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
                string[] fullNamesTemp = new string[fullNames.Length + 1];
                string[] positionTemp = new string[positions.Length + 1];

                Console.Write("\nВведите ФИО :");
                fullNamesTemp[fullNames.Length] = Console.ReadLine();
                Console.Write("\nВведите должность :");
                positionTemp[positions.Length] = Console.ReadLine();

                CopyNewArray(ref fullNames, ref positions, ref fullNamesTemp, ref positionTemp);

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
                int resultsFound = 0;
                string[] surname;

                Console.Write("\nВведите фамилию для поиска: ");
                inputSearchString = Console.ReadLine().ToLower();
                Console.WriteLine();

                foreach (string fullName in fullNames)
                {
                    surname = fullName.Split(' ');

                    if (surname[0].ToLower().IndexOf(inputSearchString, 0) != -1)
                    {
                        Console.WriteLine(fullName);
                        resultsFound++;
                    }
                }
                if (resultsFound == 0)
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
        }*/
        }
    }
}



