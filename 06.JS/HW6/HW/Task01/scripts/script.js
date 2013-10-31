/*
Task01
Write a function that returns the last digit of given integer as an English word. 
Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"

*/

var numberTextField = document.getElementById("number");

var buttonProcess = document.getElementById("buttonProcess");
jsConsole.writeLine('Please enter your number and press the "Process" button.');

buttonProcess.addEventListener('click',getLastDigit,false);

function getLastDigit()
{
	var number = parseInt(numberTextField.value);
	if (isNaN(number))
		alert("Not a valid number!");
	else
	{
		switch (number%10){
			case 0 : jsConsole.writeLine("Zero"); break;
			case 1 : jsConsole.writeLine("One"); break;
			case 2 : jsConsole.writeLine("Two"); break;
			case 3 : jsConsole.writeLine("Three"); break;
			case 4 : jsConsole.writeLine("Four"); break;
			case 5 : jsConsole.writeLine("Five"); break;
			case 6 : jsConsole.writeLine("Six"); break;
			case 7 : jsConsole.writeLine("Seven"); break;
			case 8 : jsConsole.writeLine("Eight"); break;
			case 9 : jsConsole.writeLine("Nine"); break;
		}
	}
}