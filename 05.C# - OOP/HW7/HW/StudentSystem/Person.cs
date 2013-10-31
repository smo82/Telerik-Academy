//Task04
//Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. 
//Override ToString() to display the information of a person and if age is not specified – to say so. 
//Write a program to test this functionality.

using System;

namespace StudentSystem
{
    //------
    //Task04
    //------
    class Person
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public Person (string pName, int? pAge = null)
        {
            this.Name = pName;
            this.Age = pAge;
        }

        public override string ToString()
        {
            if (this.Age == null)
                return String.Format("{0} ({1})", this.Name, "age is not specified");
            else
                return String.Format("{0} ({1})", this.Name, this.Age);
        }
    }
}
