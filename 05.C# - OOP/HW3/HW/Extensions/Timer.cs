//Tesk07
//Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Linq;
using System.Threading;

namespace ExtensionsAndOther
{
    //------
    //Task07
    //------
    public class Timer
    {
        private bool enable = false;
        Action<string> timerFunction;
        public int Delay { get; set; }
        public bool Enable { get; set; }
        public string FuncValue { get; set; }

        public Timer(int pDelay, Action<string> pTimerFunction, string pFuncValue)
        {
            this.timerFunction += pTimerFunction;
            this.Delay = pDelay;
            this.FuncValue = pFuncValue;
        }

        public void Start()
        {
            //I execute the Thread.Sleep after the function execution on puprose. 
            //This way I am sure that when I set this.Enable to false I will stop executing the custom function
            this.Enable = true;
            Thread.Sleep(this.Delay);
            while (this.Enable)
            {
                this.timerFunction(this.FuncValue);
                Thread.Sleep(this.Delay);
            }
        }

        public void Stop ()
        {
            this.Enable = false;
        }
    }
}
