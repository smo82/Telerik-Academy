var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var width = parseInt(document.getElementById("width").value);
	var height = parseInt(document.getElementById("height").value);

	if
		(isNaN(width) || isNaN(height))
	{
		alert("Either the widht or the height is not a number!");
	}	
	else
		alert("The rectangle area is: " + width * height);
},
false);


