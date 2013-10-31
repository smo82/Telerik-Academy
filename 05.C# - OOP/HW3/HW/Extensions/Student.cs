//Task03
//Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. 
//Use LINQ query operators.

using System;

namespace ExtensionsAndOther
{
    //------
    //Task03
    //------
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student (string pFirstName, string pLastName, int pAge)
        {
            this.FirstName = pFirstName;
            this.LastName = pLastName;
            this.Age = pAge;
        }

        public override string ToString()
        {
                return String.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
