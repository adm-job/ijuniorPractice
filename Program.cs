namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionaryMeanings = new Dictionary<string, string>();
            string inputSearchString;

            FillDictionary(ref dictionaryMeanings);

            Console.Write("Введите слово для поиска: ");
            inputSearchString = Console.ReadLine().ToLower();

            SearchDictionary(dictionaryMeanings, inputSearchString);
        }

        static void FillDictionary(ref Dictionary<string, string> dictionary)
        {
            dictionary.Add("синоним", "слова одной части речи или словосочетания с полным или частичным совпадением значения");
            dictionary.Add("антоним", "слова одной части речи, различные по звучанию и написанию, имеющие прямо противоположные лексические значения, например: «правда» — «ложь»");
            dictionary.Add("омоним", "одинаковые по написанию и звучанию, но разные по значению слова и другие единицы языка");
            dictionary.Add("пароним", "слова, сходные по звучанию и морфемному составу, но различающиеся лексическим значением");
            dictionary.Add("омофон", "одинаково произносящиеся, но по-разному пишущиеся слова: плот и плод");
        }

        static void SearchDictionary(Dictionary<string, string> dictionary, string searchString)
        {
            if (dictionary.ContainsKey(searchString))
            {
                Console.WriteLine(dictionary[searchString]);
            }
            else
            {
                Console.WriteLine("Данного слова нет в словаре");
            }
        }
    }
}



