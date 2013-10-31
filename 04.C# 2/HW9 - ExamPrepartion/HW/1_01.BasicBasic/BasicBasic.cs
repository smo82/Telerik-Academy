using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

class BasicBasic
{
    static bool GetLineNumber(string inputLine, out string lineNumber, out string inputLineOut)
    {
        Match match = Regex.Match(inputLine, @"\A[0-9]+\b");

        if (match.Success)
        {
            lineNumber = match.ToString();
            inputLineOut = inputLine.Substring(lineNumber.Length, inputLine.Length - lineNumber.Length).Trim();
            return true;
        }
        else 
        {
            lineNumber = inputLine;
            inputLineOut = inputLine;
            return false;
        }
    }

    static int ParseOperand(string operand, Dictionary<string, int> variables)
    {
        int result = 0;

        if ((!int.TryParse(operand, out result)) && (operand != ""))
        {
            result = variables[operand];
        }
        return result;
    }

    static void ProcessCode(string currentCodeLine, ref Dictionary<string, int> variables, ref StringBuilder output, out string NextLineKey)
    {
        NextLineKey = "NEXT";
        switch (currentCodeLine[0])
        {
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
                        variables[splitOperand.Groups["result"].ToString()] = leftOperand - rightOperand;
                    }
                    else
                    {
                        variables[splitOperand.Groups["result"].ToString()] = leftOperand + rightOperand;
                    }
                }
                break;
            case 'I':
                Match splitIf = Regex.Match(currentCodeLine, @"IF( ){0,1}(?<leftside>\w)( ){0,1}(?<operation>[<>=]{0,1})( ){0,1}(?<rightside>-{0,1}\w*)( ){0,1}THEN( ){0,1}(?<thenop>.*)");

                if (splitIf.Success)
                {
                    int leftOperand = ParseOperand(splitIf.Groups["leftside"].ToString(), variables);
                    int rightOperand = ParseOperand(splitIf.Groups["rightside"].ToString(), variables);

                    bool ifSuccess = false;
                    if (splitIf.Groups["operation"].ToString() == "<")
                    {
                        ifSuccess = leftOperand < rightOperand;
                    }
                    else if (splitIf.Groups["operation"].ToString() == ">")
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
            case 'C':
                output.Clear();
                break;
            case 'P':
                Match splitPrint = Regex.Match(currentCodeLine, @"PRINT( ){0,1}(?<printval>.*)");
                if (splitPrint.Success)
                {
                    int printVal = ParseOperand(splitPrint.Groups["printval"].ToString(), variables);
                    output.AppendLine(printVal.ToString());
                }
                break;
            case 'G':
                Match splitGoto = Regex.Match(currentCodeLine, @"GOTO( ){0,1}(?<gotoval>.*)");
                if (splitGoto.Success)
                {
                    NextLineKey = splitGoto.Groups["gotoval"].ToString();
                }
                break;
            case 'S':
                NextLineKey = "RUN";
                break;
        }
    }

    static void Main()
    {
        Dictionary<string, string> inputCode = new Dictionary<string, string>();

        string inputLine;
        string lineNumber;
                
        do
        {
            inputLine = Console.ReadLine();
            inputLine = Regex.Replace(inputLine, @"\s+", " ");

            GetLineNumber(inputLine, out lineNumber, out inputLine);
            inputCode.Add(lineNumber, inputLine);
        }
        while (inputLine != "RUN");

        Dictionary<string, string>.Enumerator codeDictionaryEnumerator = inputCode.GetEnumerator();

        codeDictionaryEnumerator.MoveNext();
        string nextLine = codeDictionaryEnumerator.Current.Key;

        StringBuilder output = new StringBuilder();
        Dictionary<string, int> variables = new Dictionary<string, int>() {{"V", 0},{"W", 0},{"X", 0},{"Y", 0},{"Z", 0}};
        while (nextLine != "RUN")
        {
            string nextLineKey;
            ProcessCode(inputCode[nextLine], ref variables, ref output, out nextLineKey);

            if (nextLineKey == "NEXT")
            {
                codeDictionaryEnumerator.MoveNext();
            }
            else
            {
                while (codeDictionaryEnumerator.Current.Key != nextLineKey)
                {
                    if (!codeDictionaryEnumerator.MoveNext())
                    {
                        codeDictionaryEnumerator = inputCode.GetEnumerator();
                    }
                }
            }
            nextLine = codeDictionaryEnumerator.Current.Key;
        }

        Console.WriteLine(output);
    }
}
