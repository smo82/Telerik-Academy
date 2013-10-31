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
		var thirdDigit = parseInt(number / 100);
		thirdDigit = thirdDigit%10;
		alert("The third digit of the number is: " + thirdDigit);
	}		
},
false);


