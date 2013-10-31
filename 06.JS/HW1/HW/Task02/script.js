var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var textValue = parseInt(document.getElementById("textValue").value);

	if
		(isNaN(textValue))
	{
		alert("Not a number!");
	}
	else if	(
		(textValue % 5 == 0) &&
		(textValue % 7 == 0)
		)
	{
		alert("Devides without reminder by 5 and 7!");
	}		
	else
		alert("Devides with a reminder!");
},
false);


