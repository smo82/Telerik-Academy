var firstIntInput = document.getElementById("firstInt");
var secondIntInput = document.getElementById("secondInt");

var button = document.getElementById("process");

button.addEventListener('click', process, false);
	
function process (){

	var firstInt = parseInt(firstIntInput.value);
	var secondInt = parseInt(secondIntInput.value);
	if (isNaN(firstInt))
	{
		alert("The first number is not an integer!");
	}
	else if (isNaN(secondInt))
	{
		alert("The second number is not an integer!");	
	}
	else{
		if (firstInt > secondInt){
			firstIntInput.value = secondInt;
			secondIntInput.value = firstInt;
		}
	}
}
