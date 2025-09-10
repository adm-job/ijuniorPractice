using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Dispatcher
    {

    }

    class Train
    {

    }

    class Passenger
    {
        public Passenger(int ticket)
        {
            Ticket = ticket;
        }

        public int Ticket { get; private set; }
    }

    class City
    {
        private List<string> _title = new();
        private Random _random = new();

        public void CityAdd()
        {
            _title.Add("Москва");
            _title.Add("Екатеринбург");
            _title.Add("Магадан");
            _title.Add("Тюмень");
            _title.Add("Челябинск");
            _title.Add("Воркута");
            _title.Add("Саратов");
            _title.Add("Тверь");
            _title.Add("Пермь");
            _title.Add("Омск");
        }

        public string CityRandom()
        {
            return _title[ _random.Next(0, _title.Count)];
        }

    }
}
