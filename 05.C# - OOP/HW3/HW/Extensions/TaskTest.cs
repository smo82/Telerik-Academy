using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExtensionsAndOther
{
    class TaskTest
    {
        static void Main(string[] args)
        {
            //Test Task01
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task01");
            Console.WriteLine();
            Console.WriteLine("From the string \"ASdasdf\" we get the substring from the 3-th symbol to the end:");
            StringBuilder test = new StringBuilder("ASdasdf");
            Console.WriteLine(test.Substring(3, test.Length - 3));

            //Test Task02
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task02");
            Console.WriteLine();
            Console.WriteLine("For the list { 1, 2, 3, 4 } we calculate:");
            List<double> newList = new List<double>() { 1, 2, 3, 4 };
            Console.WriteLine("-The Sum: {0}",newList.Sum<double>());
            Console.WriteLine("-The Product: {0}", newList.Product<double>());
            Console.WriteLine("-The Min: {0}", newList.Min<double>());
            Console.WriteLine("-The Max: {0}", newList.Max<double>());
            Console.WriteLine("-The Average: {0}", newList.Average<double>());

            //Test Task03
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task03");
            Console.WriteLine();
            Console.WriteLine("For the students:");
            Console.WriteLine("Ivan Petrov - age: 20");
            Console.WriteLine("Petar Atanasov - age: 17");
            Console.WriteLine("Petar Ivanov - age: 17");
            Console.WriteLine("Chavdar Spasov - age: 22");
            Console.WriteLine("Spas Chavdarov - age: 22");
            Console.WriteLine();
            Console.WriteLine("We list the students for which the FirstName");
            Console.WriteLine("is before the LastName alphabetically:");
            Student[] studentArr = new Student[] { 
                new Student("Ivan", "Petrov", 20),
                new Student("Petar", "Atanasov", 17),
                new Student("Petar", "Ivanov", 17),
                new Student("Chavdar", "Spasov", 22),
                new Student("Spas", "Chavdarov", 22)
            };

            Student[] studentArrFiltered = StudentsMethods.GetStudentsFirstNameBeforeLast(studentArr);

            foreach (Student currentStudent in studentArrFiltered)
            {
                Console.WriteLine(currentStudent);
            }

            //Test Task04
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task04");
            Console.WriteLine();
            Console.WriteLine("For the same list of students we list those with age between 18 and 24:");
            IEnumerable<object> studentAgeArray = StudentsMethods.GetStudentsBetween18And24<object>(studentArr);

            foreach (dynamic studentSubArr in studentAgeArray)
            {
                Console.WriteLine("{0} {1}", studentSubArr.FirstName, studentSubArr.LastName);
            }

            //Test Task05
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task05 - Lambda");
            Console.WriteLine();
            Console.WriteLine("The same list of students we sort in descenting order by First and Last name:");
            Student[] studentSortByLambda = StudentsMethods.SortStudentsLambda(studentArr);

            foreach (Student currentStudent in studentSortByLambda)
            {
                Console.WriteLine(currentStudent);
            }

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task05 - LINQ");
            Console.WriteLine();
            Console.WriteLine("The same list of students we sort in descenting order by First and Last name:");
            Student[] studentSortByLINQ = StudentsMethods.SortStudentsLINQ(studentArr);

            foreach (Student currentStudent in studentSortByLINQ)
            {
                Console.WriteLine(currentStudent);
            }

            //Test Task06
            int[] intArr = new int[] { 1, 2, 3, 21, 22, 23, 42, 43 };

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task06 - Lambda");
            Console.WriteLine();
            Console.WriteLine("From the array { 1, 2, 3, 21, 22, 23, 42, 43 }");
            Console.WriteLine("we print only those integers that are devisible by 3 nad 7:");

            int[] intArrLambda = IntArrMethods.GetDevisibleBy3And7Lambda(intArr);
            foreach (int currentInt in intArrLambda)
            {
                Console.WriteLine(currentInt);
            }

            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task06 - LINQ");
            Console.WriteLine();
            Console.WriteLine("From the array { 1, 2, 3, 21, 22, 23, 42, 43 }");
            Console.WriteLine("we print only those integers that are devisible by 3 nad 7:");

            int[] intArrLINQ = IntArrMethods.GetDevisibleBy3And7LINQ(intArr);
            foreach (int currentInt in intArrLINQ)
            {
                Console.WriteLine(currentInt);
            }

            //Test Task07
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task07");
            Console.WriteLine();
            Console.WriteLine("We start a timer with 500 miliseconds delay and we stop it after 1800.");
            Console.WriteLine("On every tick the timer prints out \" - Task07 - \":");

            Timer newTimer = new Timer(500, (x) => { Console.WriteLine(x); }, "-Task07-");
            Thread timerThread = new Thread(new ThreadStart(newTimer.Start));
            timerThread.Start();
            Thread.Sleep(1800);
            newTimer.Stop();


            //Test Task08
            Console.WriteLine(new String('*', 20));
            Console.WriteLine("Task08");
            Console.WriteLine();
            Console.WriteLine("We start a timer with 500 miliseconds delay and we stop it after 1800.");
            Console.WriteLine("On every tick the timer prints out \" - Task08 - \":");

            EventPublisher newTimerEvent = new EventPublisher();

            EventTimer newEventTimer = new EventTimer(newTimerEvent, (x) => { Console.WriteLine(x); }, new TimerEventArgs("-Task08-"));
            Thread eventTimerThread = new Thread(new ThreadStart(() => newEventTimer.StartTick(500, newTimerEvent)));
            eventTimerThread.Start();
            Thread.Sleep(1800);
            newEventTimer.StopTick();
        }
    }
}
