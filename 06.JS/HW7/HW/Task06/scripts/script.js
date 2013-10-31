/*
Task06
Write a function that groups an array of persons by age, first or last name. 
The function must return an associative array, with keys - the groups, and 
values -arrays with persons in this groups
Use function overloading (i.e. just one function)

var persons = {…};
var groupedByFname = group(persons,"firstname");
var groupedByAge= group(persons,"age");
*/


function AssociativeArrayToString( arr ){
	var result = [];

	for (prop in arr){
		result.push (prop + " = {" + arr[prop].toString() + "}")
	}

	return "[" + result.join() + "]";
}


function Person (pName, pLastname, pAge)
{
	return{
		firstname : pName,
		lastname : pLastname,
		age : pAge,
		toString : function(){
			return this.firstname + " " + this.lastname + " (" + this.age + ")";
		}
	}
}

function group(persons,property){
	switch (property){
		case "firstname" :
			return groupByFirstName(persons);
			break;
		case "lastname" :
			return groupByLastName(persons);
			break;
		case "age" :
			return groupByAge(persons);
			break;
	}

	return [];
}

function groupByFirstName(persons){
	var result = [];

	for (var i = 0; i < persons.length; i++) {
		if (result[persons[i].firstname])
			result[persons[i].firstname].push(persons[i]);
		else
			result[persons[i].firstname] = [persons[i]];
	};

	return result;
}

function groupByLastName(persons){
	var result = [];

	for (var i = 0; i < persons.length; i++) {
		if (result[persons[i].lastname])
			result[persons[i].lastname].push(persons[i]);
		else
			result[persons[i].lastname] = [persons[i]];
	};

	return result;
}

function groupByAge(persons){
	var result = [];

	for (var i = 0; i < persons.length; i++) {
		if (result[persons[i].age])
			result[persons[i].age].push(persons[i]);
		else
			result[persons[i].age] = [persons[i]];
	};

	return result;
}

var personArr = [
	Person("Gosho", "Petrov", 32),
	Person("Bay", "Ivan", 81),
	Person("Bay", "Stoyan", 83),
	Person("Dimitar", "Petrov", 81),
	Person("Malyk", "Vancho", 1)
]

jsConsole.writeLine("The list of persons is:");
for (var i = 0; i < personArr.length; i++) {
	jsConsole.writeLine(personArr[i].toString());
};

jsConsole.writeLine("-----------------------");
jsConsole.writeLine("Grouped list by first name is:");
jsConsole.writeLine(AssociativeArrayToString(group(personArr,"firstname")));

jsConsole.writeLine("-----------------------");
jsConsole.writeLine("Grouped list by last name is:");
jsConsole.writeLine(AssociativeArrayToString(group(personArr,"lastname")));

jsConsole.writeLine("-----------------------");
jsConsole.writeLine("Grouped list by age name is:");
jsConsole.writeLine(AssociativeArrayToString(group(personArr,"age")));