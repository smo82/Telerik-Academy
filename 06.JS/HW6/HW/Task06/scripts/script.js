/*
Task06
Write a function that checks if the element at given position in given array 
of integers is bigger than its two neighbors (when such exist).
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

function TestCheckIndexIfBigger (){
	var arr = [1,2,3,4,3,6,7,8];
	var index = 5;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The first array is: " + arr.toString());	
	jsConsole.writeLine("The index checked is : " + index);	
	jsConsole.writeLine("Is the value bigger then its neighbors? : " + ChechIfBiggerThenNeighbors(index, arr));	

	arr = [1,2,1,4,1,6,1,8];
	index = 1;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The second array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + index);	
	jsConsole.writeLine("Is the value bigger then its neighbors? : " + ChechIfBiggerThenNeighbors(index, arr));	

	arr = [];
	index = 11;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The third array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + index);	
	jsConsole.writeLine("Is the value bigger then its neighbors? : " + ChechIfBiggerThenNeighbors(index, arr));	

	arr = [1,2];
	index = 1;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The third array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + index);	
	jsConsole.writeLine("Is the value bigger then its neighbors? : " + ChechIfBiggerThenNeighbors(index, arr));	
}

TestCheckIndexIfBigger();

