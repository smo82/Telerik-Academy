using System;
using System.Text;

class MultiplicationOfPolynomials
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

    static void PrintPolynomial(int[] polynomial)
    {
        StringBuilder result = new StringBuilder();
        int index = polynomial.Length - 1;

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

    static int[] AddPolynomials(int sign, int[] firstPolynomial, int[] secondPolynomial)
    {
        int lengthResult = Math.Max(firstPolynomial.Length, secondPolynomial.Length);
        int[] result = new int[lengthResult];
        firstPolynomial.CopyTo(result, 0);

        for (int i = 0; i < secondPolynomial.Length; i++)
        {
            result[i] = result[i] + sign * secondPolynomial[i];
        }
        return result;
    }

    static int[] MultiplyPolynomials(int[] firstPolynomial, int[] secondPolynomial)
    {
        int lengthResult = firstPolynomial.Length + secondPolynomial.Length;
        int[] result = new int[lengthResult];

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                result[i + j] += firstPolynomial[i] * secondPolynomial[j];
            }
        }

        return result;
    }

    static void Main()
    {
        int firstPolyDegree = ReadInt("Enter the degree of the first polynomial: ") + 1;

        int[] firstPolynomial = new int[firstPolyDegree];
        firstPolynomial = ReadArray(firstPolyDegree);

        int secondPolyDegree = ReadInt("Enter the degree of the second polynomial: ") + 1;

        int[] secondPolynomial = new int[secondPolyDegree];
        secondPolynomial = ReadArray(secondPolyDegree);

        int operation = ReadInt("Enter operation (0 - sum, 1 - subtract, 2 - myltiply):", 0, 2);

        int[] resultPolynomial = new int[0];
        switch (operation)
        {
            case 0:
                resultPolynomial = AddPolynomials(1, firstPolynomial, secondPolynomial);
                break;
            case 1:
                resultPolynomial = AddPolynomials(-1, firstPolynomial, secondPolynomial);
                break;
            case 2:
                resultPolynomial = MultiplyPolynomials(firstPolynomial, secondPolynomial);
                break;
        }

        Console.WriteLine(new String('*', 20));
        Console.WriteLine("Your result polynomial is:");
        PrintPolynomial(resultPolynomial);
    }
}
