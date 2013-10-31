using System;

public class ExamResult
{
    private const int MINIMAL_ALLOWED_GRADE = 0;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < MINIMAL_ALLOWED_GRADE)
        {
            throw new ArgumentOutOfRangeException(string.Format("The grade should be bigger or equal to {0}", MINIMAL_ALLOWED_GRADE));
        }

        if (minGrade < MINIMAL_ALLOWED_GRADE)
        {
            throw new ArgumentOutOfRangeException(string.Format("The minimal grade should be bigger or equal to {0}", MINIMAL_ALLOWED_GRADE));
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The maximal grade should be bigger the minimal grade");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentOutOfRangeException("The comments string should not be null or empty string");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
