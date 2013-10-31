using System;
using System.Collections.Generic;
using System.Text;

public class OffsiteCourse : Course
{
    private string town = null;

    /// <summary>
    /// Initializes the OffsiteCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    public OffsiteCourse(string name)
        : base(name)
    {
    }

    /// <summary>
    /// Initializes the OffsiteCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    public OffsiteCourse(string name, string teacherName)
        : base(name, teacherName)
    {
    }

    /// <summary>
    /// Initializes the OffsiteCourse object
    /// </summary>
    /// <param name="name">The name of the course</param>
    /// <param name="teacherName">The teachers name</param>
    /// <param name="students">The list of students</param>
    public OffsiteCourse(string name, string teacherName, IList<string> students)
        : base(name, teacherName, students)
    {
    }

    public string Town
    {
        get
        {
            return this.town;
        }

        set
        {
            this.town = value;
        }
    }

    /// <summary>
    /// Builds the string representation of any other additional properties that the class have
    /// </summary>
    /// <returns>Returns the string representation of any other additional properties that the class have</returns>
    protected override string GetAdditionalPropAsString()
    {
        StringBuilder result = new StringBuilder();

        if (this.Town != null)
        {
            result.Append("; Town = ");
            result.Append(this.Town);
        }

        return result.ToString();
    }
}