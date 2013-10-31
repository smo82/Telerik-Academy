var n = document.getElementById("n");
var buttonProcess = document.getElementById("process");

var body = document.body;

buttonProcess.addEventListener('click',printNumbersToN,false);

function printNumbersToN()
{
	var nInt = parseInt(n.value);
	if (isNaN(nInt))
		alert("N is not an integer number!");
	else
	{
		for (var i = 1; i <= nInt; i++) {
			jsConsole.writeLine(i);
		};
	}	
}
