//Task03
//Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. 
//Use LINQ query operators.

//Task04
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

//Task05
//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name 
//in descending order. Rewrite the same with LINQ.

using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtensionsAndOther
{
    public static class StudentsMethods
    {
        //------
        //Task03
        //------
        public static Student [] GetStudentsFirstNameBeforeLast(Student [] studentArr)
        {
            //Solution with Lambda expressions
            //return studentArr.Where(s => s.FirstName.CompareTo(s.LastName) < 0).ToArray();

            var studentFiltered =
                from student in studentArr
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            return studentFiltered.ToArray();
        }

        //------
        //Task04
        //------
        //There where many ways to return the data but I have decided to do it with IEnumerable 
        //because for me this is the closest to the task requirement
        public static IEnumerable<T> GetStudentsBetween18And24<T>(Student[] studentArr)
        {
            var studentNames =
                from student in studentArr
                where student.Age > 17 && student.Age < 24
                select new { FirstName = student.FirstName, LastName = student.LastName};
            return studentNames as IEnumerable<T>;
        }

        //------
        //Task05
        //------
        public static Student [] SortStudentsLambda (Student [] studentArr)
        {
            return studentArr.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName).ToArray();
        }

        public static Student[] SortStudentsLINQ(Student[] studentArr)
        {
            var studentSorted =
                from student in studentArr
                orderby student.FirstName descending, student.LastName descending
                select student;
            return studentSorted.ToArray();
        }
    }
}
