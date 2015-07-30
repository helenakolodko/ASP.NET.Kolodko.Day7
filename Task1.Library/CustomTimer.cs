using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class CustomTimer
    {
        private Task currentTiming;

        public event EventHandler<TimeoutEventArgs> Timeout = delegate { };

        public bool StartTimer(int seconds)
        {
            if (currentTiming != null)
                return false;
            currentTiming = new Task(() =>
            {
                Thread.Sleep(seconds * 1000);
                OnTimeout(this, new TimeoutEventArgs(seconds));
                currentTiming = null;
            });
            currentTiming.Start();
            return true;
        }

        protected virtual void OnTimeout(object sender, TimeoutEventArgs e)
        {
            Timeout(sender, e);
        }
    }
}
