using System;
using System.Collections.Generic;

class CalcExpressions
{
    static string RemoveSpaces (string initialString)
    {
        string[] substringArr = initialString.Split(' ');

        string result = String.Empty;
        foreach (string item in substringArr)
        {
            result += item;
        }
        return result;
    }

    static string RemoveLeadingSubstring (string initialString, int index)
    {
        if (initialString.Length > index)
        {
            return initialString.Substring(index);
        }
        else
        {
            return String.Empty;
        }
    }

    static bool PushPreviousOperator(string currentOperator, string matchedOperator)
    {
        List<List<string>> priority = new List<List<string>>() { 
            new List<string>{")", "("},
            new List<string>{"+", "-"}, 
            new List<string>{"*", "/"},
            new List<string>{"ln", "pow", "sqrt"}            
        };

        int foundPriority = 0;
        int currentOpPriority = 0;
        int matchedOpPriority = 0;
        int index = 0;

        while ((foundPriority < 2) && (index < priority.Count))
        {
            int currentOpPriorityTmp = priority[index].IndexOf(currentOperator);
            if (currentOpPriorityTmp>=0)
            {
                currentOpPriority = index;
                foundPriority++;
            }

            int matchedOpPriorityTmp = priority[index].IndexOf(matchedOperator);
            if (matchedOpPriorityTmp>=0)
            {
                matchedOpPriority = index;
                foundPriority++;
            }
            index++;
        }

        if (currentOpPriority <= matchedOpPriority)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static Stack<string> GetRPN(string expressionString)
    {
        Stack<string> result = new Stack<string>();

        Stack <string> operatorStack = new Stack<string>();

        while (expressionString.Length > 0)
        {
            string currentOperator = "";

            switch (expressionString[0])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '(':
                case ')':
                    currentOperator = expressionString.Substring(0, 1);
                    expressionString = RemoveLeadingSubstring(expressionString, 1);
                    break;
                case 'l':
                    currentOperator = expressionString.Substring(0, 2);
                    expressionString = RemoveLeadingSubstring(expressionString, 2);
                    break;
                case 'p':
                    currentOperator = expressionString.Substring(0, 3);
                    expressionString = RemoveLeadingSubstring(expressionString, 3);
                    break;
                case 's':
                    currentOperator = expressionString.Substring(0, 4);
                    expressionString = RemoveLeadingSubstring(expressionString, 4);
                    break;
                case ',':
                    expressionString = RemoveLeadingSubstring(expressionString, 1);
                    string currentNumber = "";
                    int tempNumber = 0;

                    while ((expressionString.Length > 0) &&
                           ((expressionString.Substring(0, 1) == "-") || 
                            (expressionString.Substring(0, 1) == ".") || 
                            (int.TryParse(expressionString.Substring(0, 1), out tempNumber))))
                    {
                        currentNumber += expressionString.Substring(0, 1);
                        expressionString = RemoveLeadingSubstring(expressionString, 1);
                    }

                    result.Push(currentNumber); 
                    break;
                default:
                    currentNumber = "";
                    tempNumber = 0;

                    while ((expressionString.Length > 0) && 
                           ((expressionString.Substring(0, 1) == ".") || (int.TryParse(expressionString.Substring(0, 1), out tempNumber))))
                    {
                        currentNumber += expressionString.Substring(0, 1);
                        expressionString = RemoveLeadingSubstring(expressionString, 1);
                    }

                    result.Push(currentNumber);                    
                    break;
            }

            if (currentOperator != "")
            {
                if (operatorStack.Count > 0)
                {
                    if (currentOperator == "(")
                    {
                        operatorStack.Push(currentOperator);
                    }
                    else if (currentOperator == ")")
                    {
                        string priorOperator = operatorStack.Pop();
                        while (priorOperator != "(")
                        {
                            result.Push(priorOperator);
                            priorOperator = operatorStack.Pop();
                        }
                    }
                    else
                    {
                        while ((operatorStack.Count>0) && (PushPreviousOperator(currentOperator, operatorStack.Peek())))
                        {
                            string priorOperator = operatorStack.Pop();
                            result.Push(priorOperator);
                        }
                        operatorStack.Push(currentOperator);
                    }                    
                }
                else
                {
                    operatorStack.Push(currentOperator);
                }
            }
        }

        while (operatorStack.Count > 0)
        {
            string waitingOperator = operatorStack.Pop();
            result.Push(waitingOperator);
        }

        return result;
    }

    static double CalcRPN(Stack<string> rpnExpression)
    {
        string currentItem = rpnExpression.Pop();
        double leftSide, rightSide;
        if (!Double.TryParse(currentItem, out leftSide))
        {
            if (currentItem == "sqrt")
            {
                leftSide = CalcRPN(rpnExpression);
                leftSide = Math.Sqrt(leftSide);
            }
            else if (currentItem == "ln")
            {
                leftSide = CalcRPN(rpnExpression);
                leftSide = Math.Log(leftSide);
            }
            else
            {
                rightSide = CalcRPN(rpnExpression); leftSide = CalcRPN(rpnExpression);

                switch (currentItem)
                {
                    case "pow":
                        leftSide = Math.Pow(leftSide, rightSide);
                        break;
                    case "/":
                        leftSide = leftSide / rightSide;
                        break;
                    case "*":
                        leftSide = leftSide * rightSide;
                        break;
                    case "-":
                        leftSide = leftSide - rightSide;
                        break;
                    case "+":
                        leftSide = leftSide + rightSide;
                        break;
                }
            }
        }
        return leftSide;
    }

    static void Main()
    {
        Console.Write("Enter your expression:");
        string expressionString = Console.ReadLine();
        expressionString = RemoveSpaces (expressionString);

        Stack<string> rpnExpression = GetRPN(expressionString);

        double result = CalcRPN(rpnExpression);

        Console.WriteLine("The result of your expression is: {0}", result);
    }
}
