using System;

public class StudentData : IComparable<StudentData>
{
    public StudentData(string firstName, string lastName, string course)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Course = course;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Course { get; private set; }

    public int CompareTo(StudentData other)
    {
        int compareByLastName = this.LastName.CompareTo(other.LastName);

        if (compareByLastName != 0)
        {
            return compareByLastName;
        }

        return this.FirstName.CompareTo(other.FirstName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}