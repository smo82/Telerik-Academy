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
		var sign = 1;

		if ((firstNumber != 0) && (secondNumber != 0) && (thirdNumber != 0))
		{
			if (firstNumber<0)
				sign = -sign;
			if (secondNumber<0)
				sign = -sign;
			if (thirdNumber<0)
				sign = -sign;	
		}

		if (sign > 0)
			alert("The product is a positive number!");	
		else
			alert("The product is a negative number!");	
	}
}
