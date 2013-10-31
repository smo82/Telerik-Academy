using System;
using System.Collections.Generic;
using System.Text;

public class Course
{
    private string teacherName = null;
    private IList<string> students = new List<string>();

    /// <summary>
    /// Initializes the Course object
    /// </summary>
    /// <param name="name">The name of the course</param>
    public Course(string name)
    {
        this.Name = name;
    }

    /// <summary>
    /// Initializes the Course object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    public Course(string name, string teacherName)
        : this(name)
    {
        this.TeacherName = teacherName;
    }

    /// <summary>
    /// Initializes the Course object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    /// <param name="students">The list of students</param>
    public Course(string name, string teacherName, IList<string> students)
        : this(name, teacherName)
    {
        this.Students = students;
    }

    public string Name { get; set; }

    public string TeacherName
    {
        get
        {
            return this.teacherName;
        }

        set
        {
            this.teacherName = value;
        }
    }

    public IList<string> Students
    {
        get
        {
            return this.students;
        }

        set
        {
            this.students = value;
        }
    }

    /// <summary>
    /// Builds the string representation of the course object
    /// </summary>
    /// <returns>Returns the string representation of the course object</returns>
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(string.Format("{0} {{ Name = ", this.GetType().Name));
        result.Append(this.Name);

        if (this.TeacherName != null)
        {
            result.Append("; Teacher = ");
            result.Append(this.TeacherName);
        }

        result.Append("; Students = ");
        result.Append(this.GetStudentsAsString());
        result.Append(this.GetAdditionalPropAsString());
        result.Append(" }");
        return result.ToString();
    }

    /// <summary>
    /// Builds the string representation of the list of students
    /// </summary>
    /// <returns>Returns the string representation of the list of students</returns>
    protected string GetStudentsAsString()
    {
        if (this.Students == null || this.Students.Count == 0)
        {
            return "{ }";
        }
        else
        {
            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }

    /// <summary>
    /// Builds the string representation of any other additional properties that the class have
    /// </summary>
    /// <returns>Returns the string representation of any other additional properties that the class have</returns>
    protected virtual string GetAdditionalPropAsString()
    {
        return string.Empty;
    }
}