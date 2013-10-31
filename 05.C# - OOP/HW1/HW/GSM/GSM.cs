//Task1
//Define a class that holds information about a mobile phone device: 
//model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and 
//display characteristics (size and number of colors). 
//Define 3 separate classes (class GSM holding instances of the classes Battery and Display).

//Task2
//Define several constructors for the defined classes that take different sets of arguments (the full information 
//for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). 
//All unknown data fill with null.

//Task4
//Add a method in the GSM class for displaying all information about it. Try to override ToString().

//Task5
//Use properties to encapsulate the data fields inside the GSM, Battery and Display classes. 
//Ensure all fields hold correct data at any given time.

//Task6
//Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

//Task9
//Add a property CallHistory in the GSM class to hold a list of the performed calls. 
//Try to use the system class List<Call>.

//Task10
//Add methods in the GSM class for adding and deleting calls from the calls history. 
//Add a method to clear the call history.

//Task11
//Add a method that calculates the total price of the calls in the call history. 
//Assume the price per minute is fixed and is provided as a parameter.

using System;
using System.Collections.Generic;
using System.Text;

namespace GSMSpace
{
    //-------
    //Task1
    //-------
    public class GSM
    {
        //-------
        //Task6
        //-------
        //Static fields
        private static string iPhone4S = "Apple iPhone 4S smartphone. Announced 2011, October. Features 3G, 3.5\" LED-backlit IPS LCD display, 8 MP camera, Wi-Fi, GPS, Bluetooth.";

        public static string IPhone4S
        {
            get { return GSM.iPhone4S; }
            set { GSM.iPhone4S = value; }
        }

        //Instance fields
        private string model;
        private string manifacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

        public Display Display
        {
            get { return display; }
            set { display = value; }
        }

        public Battery Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        //-------
        //Task5
        //-------
        public decimal? Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    price = value;
                }
            }
        }

        public string Manifacturer
        {
            get { return manifacturer; }
            set { manifacturer = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        //-------
        //Task9
        //-------
        public List<Call> CallHistory { get; set; }

        //-------
        //Task2
        //-------
        //This constructor is not explicitly needed - the same work will be done by the second constructor
        //The advantage of this separate constructor is that is doesn't set all fields unneeded fields to null
        public GSM(string model, string manifacturer)
        {
            this.model = model;
            this.manifacturer = manifacturer;
            this.CallHistory = new List<Call>();
        }

        //Constructor with all posible fields of the GSM
        public GSM(string model, string manifacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
            :this (model, manifacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }
        
        //Constructor with gsmModel, gsmManifacturer and batteryModel as mandatory fields
        //and all other possible fields for the GSM and all possible fields for the batter
        public GSM(string model, string manifacturer, string batteryModel, decimal? price = null, string owner = null, Display display = null, int? batteryHoursIdle = null, int? batteryHoursTalk = null)
            : this(model, manifacturer)
        {
            this.price = price;
            this.owner = owner;
            this.display = display;
            this.battery = new Battery(batteryModel, batteryHoursIdle, batteryHoursTalk);
        }

        //-------
        //Task4
        //-------
        public override string ToString()
        {
            if (this.price == null)
            {
                return String.Format("{0} - {1} - {2} - {3}", this.manifacturer, this.model, this.owner ?? "?", "?");
            }
            else
            {
                return String.Format("{0} - {1} - {2} - {3:0.00}", this.manifacturer, this.model, this.owner ?? "?", this.price);
            }
            
        }

        //-------
        //Task10
        //-------
        public void AddCall (Call newCall)
        {
            this.CallHistory.Add(newCall);
        }

        public void RemoveCall(int callIndex)
        {
            if (this.CallHistory.Count > callIndex)
            {
                this.CallHistory.RemoveAt(callIndex);
            }
        }

        public void RemoveAllCalls()
        {
            this.CallHistory.Clear();
        }

        //-------
        //Task11
        //-------
        //We make the method CalcCallPrice static so it can be used without a GSM instance
        //We calculate the partial minutes as full. Example: 40sec = 1 minute, 1:40 = 2 minutes, etc.
        public static decimal CalcCallPrice (Call currentCall, decimal price)
        {
            return (currentCall.Duration / 60 + 1) * price;
        }

        public decimal CalcAllCallPrice (decimal price)
        {
            decimal totalPrice = 0;
            foreach (Call currentCall in this.CallHistory)
            {
                totalPrice += CalcCallPrice(currentCall, price);
            }
            return totalPrice;
        }

        public string ListAllCalls()
        {
            StringBuilder listCalls = new StringBuilder();
            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                listCalls.AppendLine(String.Format("{0} : {1}", i+1, this.CallHistory[i]));
            }
            return listCalls.ToString();
        }

        public static void Main(){}
    }
}
