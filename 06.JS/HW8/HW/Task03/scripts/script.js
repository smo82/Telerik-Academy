/*
Task03
Write a JavaScript function that finds how many times a substring is contained 
in a given text (perform case insensitive search).
Example: The target substring is "in". The text is as follows:

"We are living in an yellow submarine. We don't have anything else. 
Inside the submarine is very tight. So we are drinking all the day. 
We will move out of it in 5 days."

The result is: 9.
*/

function countSubstringOccurrence(str, substr){
	str = str.toLowerCase();
	substr = substr.toLowerCase();

	var index = str.indexOf(substr);
	var count = 0;

	while (index > 0)
	{
		count++;
		index = str.indexOf(substr, index+1);
	}
	
	return count;
}

var str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
jsConsole.writeLine("The text is: " + str);
var substr = "in";
jsConsole.writeLine("The searched substring is: " + substr);

jsConsole.writeLine("The searched substring is found " + countSubstringOccurrence(str,substr) + " times.");