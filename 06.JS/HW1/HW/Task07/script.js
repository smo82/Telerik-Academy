var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var number = parseInt(document.getElementById("number").value);

	if
		(isNaN(number) || (number<0) || (number>100))
	{
		alert("Not correct number!");
	}	
	else
	{
		var index = 2;
		var prime = true;
		while(index <= Math.sqrt(number) && prime)
		{
			prime = number % index != 0;
			index++;
		}

		if (prime)
		{
			alert("The number is prime!");
		}
		else
		{
			alert("The number is not prime!");
		}
	}		
},
false);


