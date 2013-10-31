using System;
using System.Text;

class AddPolynomials
{
    static int ReadInt(string message = "Enter N:", int minValue = 0, int maxValue = int.MaxValue)
    {
        Console.Write(message);

        int resultInt;
        while ((!int.TryParse(Console.ReadLine(), out resultInt)) || (resultInt < minValue) || (resultInt > maxValue))
        {
            Console.Write("Wrong number. Please try again:");
        }

        return resultInt;
    }

    static int[] ReadArray(int numberElements)
    {
        int[] elementsList = new int[numberElements];

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write("[{0}]:", i);
            while (!int.TryParse(Console.ReadLine(), out elementsList[i]))
            {
                Console.Write("Wrong number. Please try again:");
            }
        }

        return elementsList;
    }

    static int [] SumPolynomials (int [] smallerPolynomial, int [] biggerPolynomial)
    {
        for (int i = 0; i < smallerPolynomial.Length; i++)
        {
            biggerPolynomial[i] += smallerPolynomial[i];
        }

        return biggerPolynomial;
    }

    static void PrintPolynomial(int[] polynomial)
    {
        StringBuilder result = new StringBuilder();
        int index = polynomial.Length-1;

        while (index >= 0)
        {
            string powerOfX = "";
            if (index != 0)
            {
                powerOfX = "x^" + index;
            }

            if ((polynomial[index] > 0) && (result.Length > 0))
            {
                result.Append("+" + polynomial[index] + powerOfX);
            }
            else if (polynomial[index] != 0)
            {
                result.Append(polynomial[index] + powerOfX);
            }
            index--;
        }

        Console.WriteLine(result);
    }

    static void Main(string[] args)
    {
        int firstPolyDegree = ReadInt("Enter the degree of the first polynomial: ") + 1;

        int[] firstPolynomial = new int[firstPolyDegree];
        firstPolynomial = ReadArray(firstPolyDegree);

        int secondPolyDegree = ReadInt("Enter the degree of the second polynomial: ") + 1;

        int[] secondPolynomial = new int[secondPolyDegree];
        secondPolynomial = ReadArray(secondPolyDegree);

        int[] resultPolynomial = new int[0];

        if (secondPolyDegree > firstPolyDegree)
        {
            resultPolynomial = SumPolynomials (firstPolynomial, secondPolynomial);
        }
        else
        {
            resultPolynomial = SumPolynomials(secondPolynomial, firstPolynomial);
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result polynomial is:");
        PrintPolynomial(resultPolynomial);
    }
}
