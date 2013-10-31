/*
Task04
Write a function to count the number of divs on the web page
*/

function CountTheDivs(){
	var divs = [];
	divs = document.getElementsByTagName("div");
	return divs.length;
}

jsConsole.writeLine("The number of divs on the page is: " + CountTheDivs());