/*
Task03
Write a function that makes a deep copy of an object
The function should work for both primitive and reference types

*/

function Student (pName, pParam)
{
	return{
		name : pName,
		param : pParam,
		toString : function(){
			return this.name + " : " + this.param.toString();
		}
	}
}

function DeepCopy (obj){
	var newObject = {};
	for (field in obj)
	{
		if (typeof obj[field] === "object")
			newObject[field] = DeepCopy(obj[field]);
		else
			newObject[field] = obj[field];
	}
	return newObject;
}

var someStudent = Student("Student1", 1);
var compositStudent = Student("Student2", someStudent);

jsConsole.writeLine("Original object: " + compositStudent.toString());
var newStudent = DeepCopy(compositStudent);
jsConsole.writeLine("Copied object: " + newStudent.toString());

jsConsole.writeLine("------------------------------------------------");
compositStudent.param.name = "Student123";
compositStudent.param.param = 11;
jsConsole.writeLine("The parameters of the first object were changed!");
jsConsole.writeLine("Original object: " + compositStudent.toString());
jsConsole.writeLine("Copied object: " + newStudent.toString());

