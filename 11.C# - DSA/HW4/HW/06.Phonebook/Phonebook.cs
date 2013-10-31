using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Phonebook
{
    private MultiDictionary<HashSet<string>, PhoneRecord> recordsByName;
    private MultiDictionary<string, PhoneRecord> recordsByTown;

    public Phonebook()
    {
        this.recordsByName = new MultiDictionary<HashSet<string>, PhoneRecord>(true);
        this.recordsByTown = new MultiDictionary<string, PhoneRecord>(true);
    }

    public void Add(PhoneRecord record)
    {
        this.recordsByName.Add(record.Names, record);
        this.recordsByTown.Add(record.Town, record);
    }

    public List<PhoneRecord> Find(string name)
    {
        HashSet<string> names = FunctionCollection.ParsePersonName(name);
        List<string> namesAsList = names.ToList();
        List<PhoneRecord> result = new List<PhoneRecord>();

        foreach (KeyValuePair<HashSet<string>, ICollection<PhoneRecord>> item in this.recordsByName)
        {
            List<string> currentRecordNames = item.Key.Intersect(names).ToList();
            bool areEqual = Enumerable.SequenceEqual(currentRecordNames.OrderBy(t => t), namesAsList.OrderBy(t => t));
            if (areEqual)
            {
                result.AddRange(item.Value);
            }
        }
        return result;
    }

    public List<PhoneRecord> Find(string name, string town)
    {
        List<PhoneRecord> resultByName = this.Find(name);
        List<PhoneRecord> result = new List<PhoneRecord>();

        foreach (PhoneRecord item in resultByName)
        {
            if (item.Town == town)
            {
                result.Add(item);
            }
        }
        return result;
    }
}