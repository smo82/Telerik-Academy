//Tesk08
//Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices


using System;
using System.Linq;
using System.Threading;

namespace ExtensionsAndOther
{
    //------
    //Task08
    //------
    public class TimerEventArgs :EventArgs
    {
        public string outputString { get; set; }

        public TimerEventArgs(string pOutputString)
        {
            this.outputString = pOutputString;
        }
    }

    public delegate void TimerEventHandler(object sender, TimerEventArgs e);

    public class EventPublisher
    {
        public event TimerEventHandler TimerEvent;

        public void Start (TimerEventArgs e)
        {
            RaiseTimerEvent(e);
        }

        protected virtual void RaiseTimerEvent(TimerEventArgs e)
        {
            TimerEventHandler handler = TimerEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public delegate void TimerFunc(string outputString);

    public class EventTimer
    {
        bool enable = false;
        private TimerFunc customFunc;

        public bool Enable { get; set; }
        TimerEventArgs EventArgs { get; set; }

        public EventTimer(EventPublisher publisher, TimerFunc pTimerFunc, TimerEventArgs pEventArgs)
        {
            this.EventArgs = pEventArgs;
            this.customFunc = pTimerFunc;
            publisher.TimerEvent += OutsideFunctionWrapper;
        }

        public void OutsideFunctionWrapper(object sender, TimerEventArgs e)
        {
            this.customFunc(e.outputString);
        }

        public void StartTick(int delay, EventPublisher publisher)
        {
            //I execute the Thread.Sleep after the function execution on puprose. 
            //This way I am sure that when I set this.Enable to false I will stop executing the event
            this.Enable = true;
            Thread.Sleep(delay);    
            while (this.Enable)
            {
                publisher.Start(this.EventArgs);
                Thread.Sleep(delay);    
            }
        }

        public void StopTick ()
        {
            this.Enable = false;
        }
    }
}
