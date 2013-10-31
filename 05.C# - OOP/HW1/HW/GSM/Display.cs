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
    public class Display
    {
        //Instance fields
        private decimal? size;
        private int? nbrOfColors;

        //-------
        //Task5 
        //-------
        public int? NbrOfColors
        {
            get { return nbrOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    nbrOfColors = value;
                }
            }
        }

        public decimal? Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    size = value;
                }
            }
        }

        //-------
        //Task2
        //-------
        public Display(decimal? size = null, int? nbrOfColors = null)
        {
            this.size = size;
            this.nbrOfColors = nbrOfColors;
        }
    }
}
