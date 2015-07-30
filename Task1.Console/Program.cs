using System;
using Task1.Library;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomTimer timer = new CustomTimer();
            FirstListener first = new FirstListener(timer);
            SecondListener second = new SecondListener(timer);

            timer.StartTimer(5);

            timer.Timeout += first.OnTimerTimeout;
            timer.Timeout += second.OnTimerTimeout;

            System.Threading.Thread.Sleep(5500);

            timer.Timeout -= first.OnTimerTimeout;
            timer.StartTimer(5);


            System.Threading.Thread.Sleep(5500);

            timer.Timeout -= second.OnTimerTimeout;
            timer.StartTimer(3);

            System.Threading.Thread.Sleep(5500);

            System.Console.WriteLine("Timer reached timeout.");
            System.Console.ReadKey();
        }
    }
}
