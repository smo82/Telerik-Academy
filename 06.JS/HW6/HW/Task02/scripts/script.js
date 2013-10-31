/*
Task02
Write a function that reverses the digits of given decimal number. Example: 256 -> 652

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
		var onlyNumberString = number.toString();
		var reversedNumber = [];
		for (var i = onlyNumberString.length - 1; i >= 0; i--) {
			reversedNumber[onlyNumberString.length - i - 1] = onlyNumberString[i];
		};

		jsConsole.writeLine(reversedNumber.join(""));
	}
}