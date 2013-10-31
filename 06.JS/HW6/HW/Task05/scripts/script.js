/*
Task05
Write a function that counts how many times given number appears in given array. 
Write a test function to check if the function is working correctly.
*/

Array.prototype.toString = function(){
	return "[" + this.join() + "]";
}

function CountNumberInArray(arr, number){
	var count = 0;
	for (var i = 0; i < arr.length; i++) {
		if (arr[i] === number)
			count++;
	};
	return count;
}

function TestCountNumberInArray (){
	var arr = [1,2,3,4,5,6,7,8];
	var val = 5;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The first array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + val);	
	jsConsole.writeLine("The result is : " + CountNumberInArray(arr, val));	

	arr = [1,2,1,4,1,6,1,8];
	val = 1;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The second array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + val);	
	jsConsole.writeLine("The result is : " + CountNumberInArray(arr, val));	

	arr = [];
	val = 11;

	jsConsole.writeLine("--------------------------------------------------");	
	jsConsole.writeLine("The third array is: " + arr.toString());	
	jsConsole.writeLine("The counted number is : " + val);	
	jsConsole.writeLine("The result is : " + CountNumberInArray(arr, val));	
}

TestCountNumberInArray();

