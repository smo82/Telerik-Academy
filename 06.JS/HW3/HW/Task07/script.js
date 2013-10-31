var numberInput = [];
for (var i = 0; i < 5; i++) {
	numberInput[i] = document.getElementById("number" + (i+1));
};

var button = document.getElementById("process");

button.addEventListener('click', process, false);
	
function process (){
	var number = [];
	var problem = false;
	for (var i = 0; i < 5; i++) {
		number[i] = parseFloat(numberInput[i].value);
		if (isNaN(number[i]) && !problem)
		{
			alert("Number " + (i+1) + " is not a number!");
			problem = true;
		}
	};

	if (!problem)
	{
		var maxNumber = number[0];

		for (var i = 1; i < number.length; i++) {
			if (number[i] > maxNumber)
				maxNumber = number[i];
		};

        alert("The max number is: " + maxNumber);
	}
}
