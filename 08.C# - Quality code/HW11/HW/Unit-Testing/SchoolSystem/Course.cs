using System;
using System.Collections.Generic;

public class Course
{
    private List<Student> students = new List<Student>();
    private string name;

    public Course(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("The course name is not allowed to be null!");
            }

            this.name = value;
        }
    }

    public List<Student> Students
    {
        get
        {
            return this.students;
        }

        private set
        {
        }
    }

    public void StudentJoin(Student newStudent)
    {
        if (this.students.Count == 29)
        {
            throw new InvalidOperationException("The number students in this class cannot exceed 29!");
        }

        if (newStudent == null)
        {
            throw new ArgumentNullException("The student object is not allowed to be null!");
        }

        this.students.Add(newStudent);
    }

    public void StudentLeave(Student newStudent)
    {
        if (this.students.Count == 0)
        {
            throw new InvalidOperationException("There are no students in this class!");
        }

        if (newStudent == null)
        {
            throw new ArgumentNullException("The student object is not allowed to be null!");
        }

        this.students.Remove(newStudent);
    }
}