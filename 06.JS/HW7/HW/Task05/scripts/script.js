/*
Task05
Write a function that finds the youngest person in a given array of persons and 
prints his/hers full name
Each person have properties firstname, lastname and age, as shown:

var persons = [
  {firstname : "Gosho", lastname: "Petrov", age: 32}, 
  {firstname : "Bay", lastname: "Ivan", age: 81},…];
*/

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

function FindTheYoungest(persons){
	if (persons.length == 0)
		return null;

	var youngest = persons[0];
	for (var i = 1; i < persons.length; i++) {
		if (persons[i].age < youngest.age)
			youngest = persons[i];
	};

	return youngest;
}

var personArr = [
	Person("Gosho", "Petrov", 32),
	Person("Bay", "Ivan", 81),
	Person("Malyk", "Vancho", 1)
]

jsConsole.writeLine("The list of persons is:");
for (var i = 0; i < personArr.length; i++) {
	jsConsole.writeLine(personArr[i].toString());
};

jsConsole.writeLine("-----------------------");
jsConsole.writeLine("The youngest person is:");
jsConsole.writeLine(FindTheYoungest(personArr).toString());