using System;

public class PriorityQueueMain
{
    public static void Main(string[] args)
    {
        PriorityQueue<Person> people = new PriorityQueue<Person>();
        people.Enqueue(new Person("George", 21));
        people.Enqueue(new Person("Little Lucho", 2));
        people.Enqueue(new Person("Doncho", 23));
        people.Enqueue(new Person("Niki", 22));
        people.Enqueue(new Person("Nakov", 28));
        people.Enqueue(new Person("Ina", 24));
        people.Enqueue(new Person("Asya", 22));
        people.Enqueue(new Person("Todor", 4));
        while (people.Count > 0)
        {
            Console.WriteLine(people.Dequeue());
        }
    }
}