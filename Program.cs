namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MainMenu();
            static void Main(string[] args)
            {

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
        }
    }
}



