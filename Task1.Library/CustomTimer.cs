using System;
using System.Threading;

namespace Task1.Library
{
    public class CustomTimer
    {
        public event EventHandler<TimeoutEventArgs> Timeout = delegate { };

        public void StartTimer(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            OnTimeout(this, new TimeoutEventArgs(seconds));
        }

        protected virtual void OnTimeout(object sender, TimeoutEventArgs e)
        {
            Timeout(sender, e);
        }
    }
}
