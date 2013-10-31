/*
Task02
Write a function that removes all elements with a given value

var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];

Attach it to the array class
Read about prototype and how to attach methods

*/

Array.prototype.toString = function(){
	return "[" + this.join() + "]";
}

Array.prototype.remove = function(value){
	//We copy the original array by value
	var newArray = this.slice(0);
	
	//We empty the original array
	this.length = 0;

	//We populate the original array only with the right values
	for (var i = 0; i < newArray.length; i++) {
		if (newArray[i] !== value)
			this.push(newArray[i]);
	};
}

var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
jsConsole.writeLine("Original array: " + arr.toString());
arr.remove(1);
jsConsole.writeLine("Modified array: " + arr.toString());
