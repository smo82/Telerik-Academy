var firstNumberInput = document.getElementById("firstNumber");
var secondNumberInput = document.getElementById("secondNumber");
var thirdNumberInput = document.getElementById("thirdNumber");

var button = document.getElementById("process");

button.addEventListener('click', process, false);
	
function process (){

	var firstNumber = parseFloat(firstNumberInput.value);
	var secondNumber = parseFloat(secondNumberInput.value);
	var thirdNumber = parseFloat(thirdNumberInput.value);
	if (isNaN(firstNumber))
	{
		alert("The first number is not a number!");
	}
	else if (isNaN(secondNumber))
	{
		alert("The second number is not a number!");	
	}
	else if (isNaN(thirdNumber))
	{
		alert("The third number is not a number!");	
	}
	else{
		var sortedNumbers = [];
		if (firstNumber > secondNumber) {
			if (firstNumber > thirdNumber) 
			{
				sortedNumbers[0] = firstNumber;
				if (thirdNumber>secondNumber)
				{
					sortedNumbers[1] = thirdNumber;
					sortedNumbers[2] = secondNumber;
				}
				else
				{
					sortedNumbers[1] = secondNumber;
					sortedNumbers[2] = thirdNumber;
				}
			}
			else
			{
				sortedNumbers[0] = thirdNumber;
				sortedNumbers[1] = firstNumber;
				sortedNumbers[2] = secondNumber;
			}
		}
		else
		{
			if (secondNumber > thirdNumber) 
			{
				sortedNumbers[0] = secondNumber;
				if (thirdNumber>firstNumber)
				{
					sortedNumbers[1] = thirdNumber;
					sortedNumbers[2] = firstNumber;
				}
				else
				{
					sortedNumbers[1] = firstNumber;
					sortedNumbers[2] = thirdNumber;
				}
			}
			else
			{
				sortedNumbers[0] = thirdNumber;
				sortedNumbers[1] = secondNumber;
				sortedNumbers[2] = firstNumber;
			}
		}

		alert("The ordered numbers are: " + sortedNumbers[0] + ", " + sortedNumbers[1] + ', ' + sortedNumbers[2]);
	}
}
