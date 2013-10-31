//Task02
//Refactor the following if statements: 

//*Note: I replace the negative HasNotBeenPeeled with the positive HasBeenPeeled
//       I replace the negative shouldNotVisitCell with the positive shouldVisitCell

using System;

class CookEngine
{
    private const int MIN_X = int.MinValue;
    private const int MAX_X = int.MaxValue;
    private const int MIN_Y = int.MinValue;
    private const int MAX_Y = int.MaxValue;

    static void Main(string[] args)
    {
        Potato potato = null;
        //... 
        if (potato != null)
        {
            if (potato.HasBeenPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }
        }

        //...

        int x = 0;
        int y = 0;
        bool shouldVisitCell = true;
        bool xIsInInterval = CheckInInterval(x, MIN_X, MAX_X);
        bool yIsInInterval = CheckInInterval(y, MIN_Y, MAX_Y);
        if (xIsInInterval && yIsInInterval && shouldVisitCell)
        {
           VisitCell();
        }
    }    

    static void Cook(Potato potato)
    {

    }

    static bool CheckInInterval(int value, int startInterval, int endInterval)
    {
        return ((startInterval <= value) && (value <= endInterval));
    }

    static void VisitCell(){
    
    }
}
