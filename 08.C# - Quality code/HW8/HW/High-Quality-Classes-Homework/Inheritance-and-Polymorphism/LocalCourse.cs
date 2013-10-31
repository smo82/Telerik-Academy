using System;
using System.Collections.Generic;
using System.Text;

public class LocalCourse : Course
{
    private string lab = null;

    /// <summary>
    /// Initializes the LocalCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    public LocalCourse(string name) 
        : base(name)
    {
    }

    /// <summary>
    /// Initializes the LocalCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    public LocalCourse(string name, string teacherName) 
        : base(name, teacherName)
    {
    }

    /// <summary>
    /// Initializes the LocalCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    /// <param name="students">The list of students</param>
    public LocalCourse(string name, string teacherName, IList<string> students) 
        : base(name, teacherName, students)
    {
    }

    public string Lab
    {
        get
        {
            return this.lab;
        }

        set
        {
            this.lab = value;
        }
    }

    /// <summary>
    /// Builds the string representation of any other additional properties that the class have
    /// </summary>
    /// <returns>Returns the string representation of any other additional properties that the class have</returns>
    protected override string GetAdditionalPropAsString()
    {
        StringBuilder result = new StringBuilder();

        if (this.Lab != null)
        {
            result.Append("; Lab = ");
            result.Append(this.Lab);
        }

        return result.ToString();
    }
}