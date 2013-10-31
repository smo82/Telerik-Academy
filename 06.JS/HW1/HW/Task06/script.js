var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var x = parseInt(document.getElementById("x").value);
	var y = parseInt(document.getElementById("y").value);

	if
		(isNaN(x) || isNaN(y))
	{
		alert("Either X or Y is not a number!");
	}	
	else
	{
		var distance = Math.sqrt(x*x + y*y);
		
		if (distance <= 5)
		{
			alert("The point is in the circle (0,5)");
		}
		else
		{
			alert("The point is not in the circle (0,5)");
		}
	}		
},
false);


