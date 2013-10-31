/*
Task02
Write a JavaScript function to check if in a given expression the brackets are 
put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).

*/

function checkBrackets(str){
	var bracketsStack = [];

	for (var i = 0; i < str.length; i++) {
		if (str[i] == '(')
			bracketsStack.push(str[i]);
		else if (str[i] == ')')
		{
			if (bracketsStack.length == 0)
				return false;
			else
				bracketsStack.pop();
		}
	};

	if (bracketsStack.length == 0)
		return true;
	else
		return false;
}

var expression = "((a+b)/5-d)";
jsConsole.writeLine("First expression: " + expression);
jsConsole.writeLine("Are the brackets correct? " + checkBrackets(expression));

expression = ")(a+b))";
expression = ")(a+b))";
jsConsole.writeLine("Second expression: " + expression);
jsConsole.writeLine("Are the brackets correct? " + checkBrackets(expression));