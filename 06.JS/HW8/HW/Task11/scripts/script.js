/*
Task11
Write a function that formats a string using placeholders:

var str = stringFormat("Hello {0}!","Peter");
//str = "Hello Peter!";

The function should work with up to 30 placeholders and all types

var format = "{0}, {1}, {0} text {2}";
var str = stringFormat(format,1,"Pesho","Gosho");
//str = "1, Pesho, 1 text Gosho"

*/

function stringFormat(text){
	var index = text.indexOf("{");
	var indexEnd = 0;
	var previousIndex = 0;
	var placeholder = "";
	var result = [];

	while (index >=0){
		result.push(text.substring(previousIndex, index));
		indexEnd = text.indexOf("}", index);
		placeholder = text.substring(index+1, indexEnd);
		result.push(arguments[parseInt(placeholder)+1]);
		previousIndex = indexEnd + 1;
		index = text.indexOf("{", previousIndex);
	}
	result.push(text.substring(previousIndex, text.length));

	return result.join("");
}

jsConsole.writeLine("We call the function like this: stringFormat(\"Hello {0}!\",\"Peter\")");
jsConsole.writeLine("The result string is: " + stringFormat("Hello {0}!","Peter"));

jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("We call the function like this: stringFormat(\"{0}, {1}, {0} text {2}\",1,\"Pesho\",\"Gosho\")");
jsConsole.writeLine("The result string is: " + stringFormat("{0}, {1}, {0} text {2}",1,"Pesho","Gosho"));

