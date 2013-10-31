//Task8
//Create a class Call to hold a call performed through a GSM. 
//It should contain date, time, dialed phone number and duration (in seconds).

using System;

namespace GSMSpace
{
    //-------
    //Task8
    //-------
    public class Call
    {
        private DateTime dateTime;

        public string DialedNumber { get; set; }
        public int Duration { get; set; }

        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
            set
            {
                this.dateTime = value;
            }
        }

        public string Date
        {
            get
            {
                return this.dateTime.ToString("dd/MM/yyyy");
            }
            set
            {
                this.dateTime = Convert.ToDateTime(value);
            }
        }

        public string Time
        {
            get
            {
                return this.dateTime.ToString("H:mm:ss");
            }
            set { ;}
        }

        public Call(int pDuration, DateTime pDateTime, string pDialedNumber)
        {
            this.Duration = pDuration;
            this.DateTime = pDateTime;
            this.DialedNumber = pDialedNumber;
        }

        public override string ToString()
        {
            return String.Format("To {0} at {1} for {2} seconds", this.DialedNumber, this.DateTime, this.Duration);
        }
    }
}
