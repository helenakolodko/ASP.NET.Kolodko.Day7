using System;

namespace Task1.Library
{
    public class TimeoutEventArgs: EventArgs
    {
        public int Seconds { get; set; }
        public TimeoutEventArgs(int seconds) : base()
        {
            Seconds = seconds;
        }
    }
}
