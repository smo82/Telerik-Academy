using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null || firstName == string.Empty)
        {
            throw new ArgumentOutOfRangeException("The first name should not be null or empty string");
        }

        if (lastName == null || lastName == string.Empty)
        {
            throw new ArgumentOutOfRangeException("The last name should not be null or empty string");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("The list of exams is not set");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The list of exams is empty");
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new InvalidOperationException("The list of exams is not set");
        }

        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("The list of exams is empty");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
