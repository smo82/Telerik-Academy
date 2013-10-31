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
		var biggestNumber;
		if (firstNumber > secondNumber) {
			if (firstNumber > thirdNumber) 
				biggestNumber = firstNumber;
			else
				biggestNumber = thirdNumber;
		}
		else
		{
			if (secondNumber > thirdNumber)
				biggestNumber = secondNumber;
			else
				biggestNumber = thirdNumber;
		}

		alert("The biggest number is: " + biggestNumber);	
	}
}
