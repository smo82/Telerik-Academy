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
		var distance = Math.sqrt((x-1)*(x-1) + (y-1)*(y-1));
		
		if (distance > 3)
		{
			alert("The point is outside the circle ((1,1),3)!");
		}
		else if ((x >= -1) && (x <= 5) && (y >= -1) && (y <= 1))
		{
			alert("The point is inside the rectangle R(top=1, left=-1, width=6, height=2)!");
		}
		else
		{
			alert("The point is inside the circle and ourside the rectangle!");	
		}
	}		
},
false);


