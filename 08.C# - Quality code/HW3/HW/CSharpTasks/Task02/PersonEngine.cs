using System;

namespace Task02
{
    class PersonEngine
    {
        public void CreatePerson(int personId)
        {
            Person person = new Person();
            person.Age = personId;
            if (personId % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Sex.Man;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Sex.Woman;
            }
        }
    }
}