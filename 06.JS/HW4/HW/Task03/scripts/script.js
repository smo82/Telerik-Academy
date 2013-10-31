
var numberTextField = document.getElementById("number");
var allNumbers = [];

var buttonAdd = document.getElementById("buttonAdd");
var buttonProcess = document.getElementById("buttonProcess");
jsConsole.writeLine('Please enter your numbers in the text field one by one');
jsConsole.writeLine('and add them using the "Add" button.');
jsConsole.writeLine('Then find their Max and Min amount using the "Process" button.');

buttonAdd.addEventListener('click',addNumber,false);
buttonProcess.addEventListener('click',findMaxAndMin,false);

function addNumber()
{
	var numberInt = parseInt(numberTextField.value);
	if (isNaN(numberInt))
		alert("N is not an integer number!");
	else
	{
		allNumbers.push(numberInt);
		jsConsole.write(numberInt + " ");
	}
}

function findMaxAndMin()
{
	if (allNumbers.length == 0)
		alert("No numbers to process!");
	else
	{
		var minNumber = allNumbers[0];
		var maxNumber = allNumbers[0];
		for (var i = 1; i < allNumbers.length; i++) {
			if (allNumbers[i] > maxNumber)
				maxNumber = allNumbers[i];
			else if (allNumbers[i] < minNumber)
				minNumber = allNumbers[i];
		}
		jsConsole.writeLine();
		jsConsole.writeLine("The minimal number is: " + minNumber);
		jsConsole.writeLine("The maximal number is: " + maxNumber);
	}
}
