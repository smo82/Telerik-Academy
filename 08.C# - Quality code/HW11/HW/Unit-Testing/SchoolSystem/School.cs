using System;

public class School
{
    private string name;

    public School(string name)
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
                throw new ArgumentNullException("The school name is not allowed to be null!");
            }

            this.name = value;
        }
    }
}
