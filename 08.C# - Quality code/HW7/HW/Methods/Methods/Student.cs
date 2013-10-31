using System;

public class Student
{
    /*
     * There is no need to store the town of birtn and the date of birth in a long string (OtherInfo) and to parse them every time.
     * It is better to have separate properties for both values
    */
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string TownOfBirth { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string OtherInfo
    {
        get
        {
            return this.GetOtherInfo();
        }
    }

    public bool IsOlderThan(Student other)
    {
        if (!(other is Student))
        {
            throw new ArgumentOutOfRangeException("The other student parameter should be a Student object!");
        }

        var isOlderThenOther = false;
        if (DateTime.Compare(this.DateOfBirth, other.DateOfBirth) > 0)
        {
            isOlderThenOther = true;
        }

        return isOlderThenOther;
    }

    // The GetOtherInfo method returns the same value as the original OtherInfo property if we need it for something.
    public string GetOtherInfo()
    {
        return string.Format("From {0}, born at {1:d}", this.TownOfBirth, this.DateOfBirth);
    }
}