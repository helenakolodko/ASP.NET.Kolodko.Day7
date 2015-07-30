using System;
using Task1.Library;

namespace Task1.Console
{
    class FirstListener
    {
        private CustomTimer timer;
        public FirstListener(CustomTimer timer)
        {
        }

        public void OnTimerTimeout(object sender, TimeoutEventArgs e)
        {
            System.Console.WriteLine("First listener: timer {0} reached {1} second timeout.", sender, e.Seconds);
        }
    }
}
