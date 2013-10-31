/*
Task03
Write a script that finds the maximal sequence of equal elements in an array.
Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
*/


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
		alert("Number is not an integer number!");
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
		var currentSequence = [];
		currentSequence.push(allNumbers[0]);
		var maxSequence = [];
		for (var i = 1; i < allNumbers.length; i++) {
			if (allNumbers[i] == allNumbers[i-1])
				currentSequence.push(allNumbers[i]);
			else
			{
				if (currentSequence.length > maxSequence.length)
					maxSequence = currentSequence;
				currentSequence = [];
				currentSequence.push(allNumbers[i]);
			}
		}

		if (currentSequence.length > maxSequence.length)
			maxSequence = currentSequence;
		jsConsole.writeLine();
		jsConsole.writeLine("The maximal sequence of equal elements in the array is: ");

		printArr(maxSequence);
	}
}

function printArr (arr)
{
	for (var i = 0; i < arr.length; i++) {
		jsConsole.write(arr[i] + "; ");
	};
}