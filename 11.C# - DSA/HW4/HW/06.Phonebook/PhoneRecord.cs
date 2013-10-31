using System;
using System.Collections.Generic;
using System.Text;

public class PhoneRecord
{
    public PhoneRecord(string name, string town, string phone)
    {
        this.Names = FunctionCollection.ParsePersonName(name);
        this.Town = town;
        this.Phone = phone;
    }

    public HashSet<string> Names { get; private set; }
    public string Town { get; private set; }
    public string Phone { get; private set; }
    public string NamesAsString 
    {
        get 
        {
            StringBuilder namesAsString = new StringBuilder();
            foreach (string name in this.Names)
            {
                namesAsString.Append(name + " ");
            }
            return namesAsString.ToString();
        }
    }
}
