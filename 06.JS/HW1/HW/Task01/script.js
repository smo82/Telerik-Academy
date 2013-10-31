var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var textValue = document.getElementById("textValue").value;

	if
		(textValue & 1 == 1)
	{
		alert("Odd!");
	}		
	else
		alert("Even!");
},
false);


