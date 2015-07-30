using System;
using Task1.Library;

namespace Task1.Console
{
    class SecondListener
    {
        private CustomTimer timer;
        public SecondListener(CustomTimer timer)
        {       
        }

        public void OnTimerTimeout(object sender, TimeoutEventArgs e)
        {
            System.Console.WriteLine("Second listener: timer {0} reached {1} second timeout.", sender, e.Seconds);
        }
    }
}
