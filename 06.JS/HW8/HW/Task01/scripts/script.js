/*
Task01
Write a JavaScript function reverses string and returns it.
Example: "sample" -> "elpmas".
*/

function reverseString(str){
	var reversedStr = [];
	for (var i = 0; i < str.length; i++) {
		reversedStr[i] = str[str.length - i - 1];
	};

	return reversedStr.join("");
}

var str = "sample";
jsConsole.writeLine("Initial string: " + str);
jsConsole.writeLine("Reversed string: " + reverseString(str));