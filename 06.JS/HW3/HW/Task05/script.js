var digitInput = document.getElementById("digit");

var button = document.getElementById("process");

button.addEventListener('click', process, false);
	
function process (){

	var digit = parseInt(digitInput.value);
	if (isNaN(digit) || (digit > 9) || (digit < 0))
	{
		alert("The entered value is not a single digit!");
	}
	else{
		var digitString;

		switch (digit)
		{
			case 0:
				digitString = "Zero";
				break;
			case 1:
				digitString = "One";
				break;
			case 2:
				digitString = "Two";
				break;
			case 3:
				digitString = "Three";
				break;
			case 4:
				digitString = "Four";
				break;
			case 5:
				digitString = "Five";
				break;
			case 6:
				digitString = "Six";
				break;
			case 7:
				digitString = "Seven";
				break;
			case 8:
				digitString = "Eight";
				break;
			case 9:
				digitString = "Nine";
				break;
		}

		alert("Your digit is: " + digitString);
	}
}
