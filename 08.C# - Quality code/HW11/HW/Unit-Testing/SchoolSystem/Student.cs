using System;

public class Student
{
    private static int studentId = 9999;

    private string firstName;
    private string lastName;
    private int id;

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Id = GenerateNextStudentId();
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("The student first name is not allowed to be null!");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("The student last name is not allowed to be null!");
            }

            this.lastName = value;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }

        private set
        {
            if ((value < 10000) || (value > 99999))
            {
                throw new InvalidOperationException(
                "The student ID counter cannot be outside the range [10000, 99999].");
            }

            this.id = value;
        }
    }

    private static int GenerateNextStudentId()
    {
        studentId++;
        int newStudentId = studentId;
        return newStudentId;
    }
}
