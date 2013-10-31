using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Text;

class BasicSolution
{
    static void GetLineNumber(string inputLine, out int lineNumber, out string inputLineOut)
    {
        Match match = Regex.Match(inputLine, @"\A[0-9]+\b");

        if (match.Success)
        {
            lineNumber = int.Parse(match.ToString());
            inputLineOut = inputLine.Substring(match.ToString().Length, inputLine.Length - match.ToString().Length).Trim();
        }
        else
        {
            lineNumber = 10001;
            inputLineOut = inputLine;
        }
    }

    static int GetIndexNextFullLine (int startIndex, string[]inputCode)
    {
        int nextIndex = startIndex;
        while (inputCode[nextIndex] == null)
        {
            nextIndex++;
        }
        return nextIndex;
    }

    static int ParseVar (string varString)
    {
        switch (varString)
        {
            case "V":
                return 0;
                break;
            case "W":
                return 1;
                break;
            case "X":
                return 2;
                break;
            case "Y":
                return 3;
                break;
            default:
                return 4;
                break;
        }
    }

    static int ParseOperand(string operand, int[] variables)
    {
        int result = 0;

        if ((!int.TryParse(operand, out result)) && (operand != ""))
        {
            result = variables[ParseVar(operand)];
        }
        return result;
    }

    static void ProcessCode(string currentCodeLine, ref int[] variables, ref StringBuilder output, out int NextLineKey)
    {
        NextLineKey = 10002;
        switch (currentCodeLine[0])
        {
            case 'I':
                Match splitIf = Regex.Match(currentCodeLine, @"IF( ){0,1}(?<leftside>\w)( ){0,1}(?<operation>[<>=]{0,1})( ){0,1}(?<rightside>-{0,1}\w*)( ){0,1}THEN( ){0,1}(?<thenop>.*)");

                if (splitIf.Success)
                {
                    int leftOperand = ParseOperand(splitIf.Groups["leftside"].ToString(), variables);
                    int rightOperand = ParseOperand(splitIf.Groups["rightside"].ToString(), variables);

                    bool ifSuccess = false;
                    string operation = splitIf.Groups["operation"].ToString();
                    if (operation == "<")
                    {
                        ifSuccess = leftOperand < rightOperand;
                    }
                    else if (operation == ">")
                    {
                        ifSuccess = leftOperand > rightOperand;
                    }
                    else
                    {
                        ifSuccess = leftOperand == rightOperand;
                    }

                    if (ifSuccess)
                    {
                        ProcessCode(splitIf.Groups["thenop"].ToString(), ref variables, ref output, out NextLineKey);
                    }
                }
                break;
            case 'P':
                Match splitPrint = Regex.Match(currentCodeLine, @"PRINT( ){0,1}(?<printval>.*)");
                if (splitPrint.Success)
                {
                    int printVal = ParseOperand(splitPrint.Groups["printval"].ToString(), variables);
                    output.AppendLine(printVal.ToString());
                }
                break;
            case 'V':
            case 'W':
            case 'X':
            case 'Y':
            case 'Z':
                Match splitOperand = Regex.Match(currentCodeLine, @"(?<result>\w)( ){0,1}=( ){0,1}(?<leftop>\w*)( ){0,1}(?<operation>[+-]{0,1})( ){0,1}(?<rightop>\w*)");

                if (splitOperand.Success)
                {
                    int leftOperand = ParseOperand(splitOperand.Groups["leftop"].ToString(), variables);
                    int rightOperand = ParseOperand(splitOperand.Groups["rightop"].ToString(), variables);

                    if (splitOperand.Groups["operation"].ToString() == "-")
                    {
                        variables[ParseVar(splitOperand.Groups["result"].ToString())] = leftOperand - rightOperand;
                    }
                    else
                    {
                        variables[ParseVar(splitOperand.Groups["result"].ToString())] = leftOperand + rightOperand;
                    }
                }
                break;
            case 'C':
                output.Clear();
                break;
            case 'G':
                Match splitGoto = Regex.Match(currentCodeLine, @"GOTO( ){0,1}(?<gotoval>.*)");
                if (splitGoto.Success)
                {
                    NextLineKey = int.Parse(splitGoto.Groups["gotoval"].ToString());
                }
                break;
            case 'S':
                NextLineKey = 10001;
                break;
        }
    }

    static void Main1()
    {
        string inputLine;
        int lineNumber;

        string[] inputCode = new string[10002];

        do
        {
            inputLine = Console.ReadLine();
            inputLine = Regex.Replace(inputLine, @"\s+", " ");

            GetLineNumber(inputLine, out lineNumber, out inputLine);
            inputCode[lineNumber] = inputLine;
        }
        while (inputLine != "RUN");

        DateTime now = DateTime.Now;
        
        int nextLine = GetIndexNextFullLine (0, inputCode);
        StringBuilder output = new StringBuilder();
        int [] variables = { 0, 0, 0, 0, 0 };
        string currentCodeLine;
        while (nextLine != 10001)
        {
            currentCodeLine = inputCode[nextLine];
            int lastLine = nextLine;

            ProcessCode(currentCodeLine, ref variables, ref output, out nextLine);

            if (nextLine == 10002)
            {
                nextLine = GetIndexNextFullLine(lastLine + 1, inputCode);
            }
        }

        Console.WriteLine(output);

        Console.WriteLine(DateTime.Now - now);
    }
}
