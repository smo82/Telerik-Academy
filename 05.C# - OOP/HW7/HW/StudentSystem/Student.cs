//Task01
//Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail,
//course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. 
//Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

//Task02
//Add implementations of the ICloneable interface. 
//The Clone() method should deeply copy all object's fields into a new object of type Student.

//Task03
//Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
//and by social security number (as second criteria, in increasing order).

using System;

namespace StudentSystem
{
    //------
    //Task01
    //------
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; set; }
        public string LastName { get; private set; }
        public int SSN { get; private set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Cource { get; set; }
        public Specialties Specialty { get; set; }
        public Faculties Faculty { get; set; }
        public Universities University { get; set; }

        public Student(string pFirstName, string pLastName, int pSSN)
        {
            this.FirstName = pFirstName;
            this.LastName = pLastName;
            this.SSN = pSSN;
        }

        public override bool Equals(object obj)
        {
            Student that = obj as Student;
            if (that == null)
                return false;
            if (this.FirstName != that.FirstName)
                return false;
            if (this.LastName != that.LastName)
                return false;
            if (this.SSN != that.SSN)
                return false;
            return true;
        }

        public static bool operator == (Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1.Equals(student2));
        }

        public override string ToString()
        {
            return String.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.SSN);
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        //------
        //Task02
        //------
        public object Clone()
        {
            Student result = new Student(this.FirstName, this.LastName, this.SSN);
            result.MiddleName = this.MiddleName;
            result.Address = this.Address;
            result.MobilePhone = this.MobilePhone;
            result.MobilePhone = this.MobilePhone;
            result.Cource = this.Cource;
            result.Specialty = this.Specialty;
            result.Faculty = this.Faculty;
            result.University = this.University;

            return result;
        }

        //------
        //Task03
        //------
        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
                return this.FirstName.CompareTo(other.FirstName);

            return this.SSN - other.SSN;
        }
    }
}
