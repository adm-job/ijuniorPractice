using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lineOfPeople;
            int receptionTime = 10;
            int minutesPerHour = 60;
            int waitingForHours = 0;
            int waitingForMinutes = 0;
            int queueTimeMinutes;

            Console.Write("Введите сколько людей в очереди: ");
            lineOfPeople = Convert.ToInt32(Console.ReadLine());
            queueTimeMinutes = lineOfPeople * receptionTime;

            waitingForHours = queueTimeMinutes / minutesPerHour;
            waitingForMinutes = queueTimeMinutes % minutesPerHour;

            Console.WriteLine($"В очереди {lineOfPeople} человек, вам придеться ждать {waitingForHours} часов и {waitingForMinutes} минут.");
        }
    }
}
