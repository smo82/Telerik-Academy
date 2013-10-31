var button = document.getElementById("checkButton");

button.addEventListener('click', function (){
	var a = parseInt(document.getElementById("a").value);
	var b = parseInt(document.getElementById("b").value);
	var h = parseInt(document.getElementById("h").value);

	if
		(isNaN(a) || isNaN(b) || isNaN(h))
	{
		alert("Either A or B or C is not a number!");
	}	
	else
	{
		var area = (a+b)*h/2;
		
		alert("The trapezoids area is: " + area);
	}		
},
false);


