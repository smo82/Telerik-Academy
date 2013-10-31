using System;

public class SimpleMathExam : Exam
{
    private const int MINIMAL_GRADE = 2;
    private const int MAXIMAL_GRADE = 6;
    private const int AVERAGE_GRADE = (MAXIMAL_GRADE + MINIMAL_GRADE)/2;
    private const int MINIMAL_NUMBER_OF_PROBLEMS_SOLVED = 0;
    private const int MAXIMAL_NUMBER_OF_PROBLEMS_SOLVED = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < MINIMAL_NUMBER_OF_PROBLEMS_SOLVED)
        {
            throw new ArgumentOutOfRangeException(string.Format("The number of problems solved should be bigger or equal to {0}", MINIMAL_NUMBER_OF_PROBLEMS_SOLVED));
        }

        if (problemsSolved > MAXIMAL_NUMBER_OF_PROBLEMS_SOLVED)
        {
            throw new ArgumentOutOfRangeException(string.Format("The number of problems solved should be smaller or equal to {0}", MAXIMAL_NUMBER_OF_PROBLEMS_SOLVED));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == MINIMAL_GRADE)
        {
            return new ExamResult(2, MINIMAL_GRADE, MAXIMAL_GRADE, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == AVERAGE_GRADE)               
        {                                           
            return new ExamResult(4, MINIMAL_GRADE, MAXIMAL_GRADE, "Average result: partially done.");
        }
        else if (this.ProblemsSolved == MAXIMAL_GRADE)               
        {
            return new ExamResult(6, MINIMAL_GRADE, MAXIMAL_GRADE, "Excellent result: all done.");
        }

        throw new ArgumentOutOfRangeException("Invalid number of problems solved!");
    }
}
