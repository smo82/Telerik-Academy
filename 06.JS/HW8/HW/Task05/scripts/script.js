/*
Task05
Write a function that replaces non breaking white-spaces in a text with &nbsp;
*/

function escapeNbsp(str){
	return str.replace(/ /g, '&nbsp;');
}

var str = "We are living in a yellow submarine. We don't have anything else.";
jsConsole.writeLine("The text with the escaped nbsp is: " + escapeNbsp(str));
jsConsole.writeLine("-------------------------------------------------------");
jsConsole.writeLine("The text seems exactly the same. Please see the result in the console!");
console.log(escapeNbsp(str));