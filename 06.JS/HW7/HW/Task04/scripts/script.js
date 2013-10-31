/*
Task04
Write a function that checks if a given object contains a given property

var obj  = …;
var hasProp = hasProperty(obj,"length");
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

function hasProperty(obj,prop){
	for (objProp in obj)
		if (objProp == prop)
			return true;

	return false;
}

var someStudent = Student("Student1", 1);
var compositStudent = Student("Student2", someStudent);

jsConsole.writeLine("Composite object: " + compositStudent.toString());
jsConsole.writeLine("Has property 'name': " + hasProperty(compositStudent, "name"));
jsConsole.writeLine("Has property 'lastName': " + hasProperty(compositStudent, "lastName"));
jsConsole.writeLine("Has property 'toString': " + hasProperty(compositStudent, "toString"));