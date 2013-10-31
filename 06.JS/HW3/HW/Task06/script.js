var coeffAInput = document.getElementById("coeffA");
var coeffBInput = document.getElementById("coeffB");
var coeffCInput = document.getElementById("coeffC");

var button = document.getElementById("process");

button.addEventListener('click', process, false);
	
function process (){

	var coeffA = parseFloat(coeffAInput.value);
	var coeffB = parseFloat(coeffBInput.value);
	var coeffC = parseFloat(coeffCInput.value);
	if (isNaN(coeffA))
	{
		alert("Coefficient A is not a number!");
	}
	else if (isNaN(coeffB))
	{
		alert("Coefficient B is not a number!");	
	}
	else if (isNaN(coeffC))
	{
		alert("Coefficient C is not a number!");	
	}
	else{
		var discriminant = (coeffB * coeffB) - (4 * coeffA * coeffC);

        var x1;
        var x2;

        if (discriminant < 0)
            alert("The equasion has no real roots.");
        else if (discriminant == 0)
        {
            x1 = (-coeffB) / (2 * coeffA);            
            alert("The real roots are x1 = x2 = " + x1);
        }
        else
        {
            x1 = ((-coeffB) + Math.sqrt(discriminant)) / (2 * coeffA);
            x2 = ((-coeffB) - Math.sqrt(discriminant)) / (2 * coeffA);
            alert("The real roots are x1 = " + x1 + " and " + x2);
        }
	}
}
