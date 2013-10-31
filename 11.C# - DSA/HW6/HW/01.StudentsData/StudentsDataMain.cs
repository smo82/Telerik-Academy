using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class StudentsDataMain
{
    public static void Main(string[] args)
    {
        SortedDictionary<string, SortedSet<StudentData>> studentDataCollection = ReadStudentData();

        PrintStortedStudentData(studentDataCollection);
    }

    private static void PrintStortedStudentData(SortedDictionary<string, SortedSet<StudentData>> studentDataCollection)
    {
        foreach (KeyValuePair<string, SortedSet<StudentData>> courseData in studentDataCollection)
        {
            SortedSet<StudentData> students = courseData.Value;

            StringBuilder courseDisplay = new StringBuilder();
            courseDisplay.Append(courseData.Key + ": ");

            foreach (StudentData studentData in courseData.Value)
            {
                courseDisplay.Append(studentData + ", ");
            }

            courseDisplay.Remove(courseDisplay.Length - 2, 2);
            Console.WriteLine(courseDisplay);
        }
    }

    private static SortedDictionary<string, SortedSet<StudentData>> ReadStudentData()
    {
        SortedDictionary<string, SortedSet<StudentData>> studentDataCollection = new SortedDictionary<string, SortedSet<StudentData>>();

        using (StreamReader inputReader = new StreamReader("students.txt"))
        {
            string line = inputReader.ReadLine();
            while (line != null)
            {
                string[] lineWords = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                string firstName = lineWords[0];
                string lastName = lineWords[1];
                string course = lineWords[2];

                StudentData newStudent = new StudentData(firstName, lastName, course);

                SortedSet<StudentData> courseStudents;
                if (studentDataCollection.ContainsKey(course))
                {
                    courseStudents = studentDataCollection[course];
                }
                else
                {
                    courseStudents = new SortedSet<StudentData>();
                }

                courseStudents.Add(newStudent);

                studentDataCollection[course] = courseStudents;

                line = inputReader.ReadLine();
            }
        }

        return studentDataCollection;
    }
}