var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var number = parseInt(document.getElementById("number").value);

	if
		(isNaN(number))
	{
		alert("Not a number!");
	}	
	else
	{
		var mask = 1<<3;
		var thirdBit = number&mask;
		
		if (thirdBit > 0)
		{
			alert("The third bit of the number is 1");
		}
		else
		{
			alert("The third bit of the number is 0");
		}
	}		
},
false);


