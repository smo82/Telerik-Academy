using System;

public class CSharpExam : Exam
{
    private const int MINIMAL_GRADE = 0;
    private const int MAXIMAL_GRADE = 100;

    public CSharpExam(int score)
    {
        if (score < MINIMAL_GRADE)
        {
            throw new ArgumentOutOfRangeException(string.Format("The exam score should not be smaller then {0}", MINIMAL_GRADE));
        }

        if (score > MAXIMAL_GRADE)
        {
            throw new ArgumentOutOfRangeException(string.Format("The exam score should not be bigger then {0}", MAXIMAL_GRADE));
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        // I moved the checks from here in to the constructor
        return new ExamResult(this.Score, MINIMAL_GRADE, MAXIMAL_GRADE, "Exam results calculated by score.");
    }
}
