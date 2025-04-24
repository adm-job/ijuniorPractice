using System.Xml.Linq;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            string firstName;
            string lastName;
            string email;
            float height;
            string phoneNumber;
            string workplace;

            Console.Write("Введите ваше имя: ");
            firstName = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Сколько вам лет: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ваш рост: ");
            height = Convert.ToSingle(Console.ReadLine());
            Console.Write("Где вы работаете: ");
            workplace = Console.ReadLine();
            Console.Write("Укажите ваш номер телефона: ");
            phoneNumber = Console.ReadLine();
            Console.Write("Введите ваш email : ");
            email = Console.ReadLine();

            Console.WriteLine($"Вас зовут {firstName} {lastName}, вам {age}, ваш рост {height}, работаете на {workplace}, ваш номер телефона {phoneNumber}, email: {email}.");

        }
    }
}
