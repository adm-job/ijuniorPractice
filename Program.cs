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

            List<int> numberList = new List<int>();
            int sumNumber = 0;
            string comandInput;
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine($"Введите число \nСумма чисел - {CommandSum}\nВыход - {CommandExit}");
                comandInput = ReadInput();
                Console.Clear();

                switch (comandInput)
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
            Console.Write("\nВведите ФИО :");
            AddElement(ref fullNames, Console.ReadLine());
            Console.Write("\nВведите должность :");
            AddElement(ref positions, Console.ReadLine());

            SendMessage();
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
            Console.ReadLine();
        }

        static void AddElement(ref string[] array, string element)
        {
            int sizeArray = array.Length + 1;
            string[] tempArray = new string[sizeArray];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[array.Length] = element;

            array = tempArray;
        }

        static void RemoveElement(ref string[] array, int idElement)
        {
            int sizeArray = array.Length - 1;
            string[] tempArray = new string[sizeArray];

            for (int i = 0; i < idElement; i++)
            {
                    tempArray[i] = array[i];
            }

            for (int i = idElement ; i <= sizeArray; i++)
            {
                    tempArray[i - 1] = array[i];
            }

            array = tempArray;
        }
    }
}

