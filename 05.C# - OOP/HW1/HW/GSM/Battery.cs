//Task1
//Define a class that holds information about a mobile phone device: 
//model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and 
//display characteristics (size and number of colors). 
//Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

//Task2
//Define several constructors for the defined classes that take different sets of arguments (the full information 
//for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). 
//All unknown data fill with null.

//Task5
//Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
//Ensure all fields hold correct data at any given time.

using System;

namespace GSMSpace
{
    //-------
    //Task1
    //-------
    public class Battery
    {
        //Instance fields
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType? batteryType;

        public BatteryType? BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        //-------
        //Task5 
        //-------
        public int? HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    hoursTalk = value;
                }
            }
        }

        public int? HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    hoursIdle = value;
                }
            }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        //-------
        //Task2
        //-------
        public Battery(string model, int? hoursIdle = null, int? hoursTalk = null, BatteryType? batteryType = null)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }
    }
}
