/*
Task07
Write a Function that returns the index of the first element in array that is 
bigger than its neighbors, or -1, if there’s no such element.
Use the function from the previous exercise.

*/

Array.prototype.toString = function(){
	return "[" + this.join() + "]";
}

function ChechIfBiggerThenNeighbors(index, arr){
	if (index < 0 || index >= arr.length)
		return "Wrong index!";

	var isBigger = true;
	if (index - 1 >= 0 && arr[index] <= arr[index - 1])
		isBigger = false;

	if (index + 1 < arr.length && arr[index] <= arr[index + 1])
		isBigger = false;

	return isBigger;
}

function FindFirstBiggerThenNeighbors (arr){
	if (arr.length == 0)
		return -1;

	for (var i = 0; i < arr.length; i++) {
		if (ChechIfBiggerThenNeighbors(i, arr))
			return i;
	};

	return -1;
}

function TestCheckIndexIfBigger (){
	var arr = [1,2,3,4,5,6,7,8];

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The first array is: " + arr.toString());	
	jsConsole.writeLine("What is the index of the first number bigger then its neighbors? : " + FindFirstBiggerThenNeighbors(arr));	

	var arr = [1,2,3,4,5,6,7,7];

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The first array is: " + arr.toString());	
	jsConsole.writeLine("What is the index of the first number bigger then its neighbors? : " + FindFirstBiggerThenNeighbors(arr));	

	arr = [1,2,1,4,1,6,1,8];

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The second array is: " + arr.toString());	
	jsConsole.writeLine("What is the index of the first number bigger then its neighbors? : " + FindFirstBiggerThenNeighbors(arr));	

	arr = [];

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The third array is: " + arr.toString());	
	jsConsole.writeLine("What is the index of the first number bigger then its neighbors? : " + FindFirstBiggerThenNeighbors(arr));	
}

TestCheckIndexIfBigger();

