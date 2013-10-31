/*
Task12
Write a function that creates a HTML UL using a template for every HTML LI. 
The source of the list should be an array of elements. 
Replace all placeholders marked with –{…}–   
with the value of the corresponding property of the object. 
Example: 

<div data-type="template" id="list-item">
 <strong>-{name}-</strong> <span>-{age}-</span>
</div>

var people = [{name: "Peter", age: 14},…];
var tmpl = document.getElementById("list-item").innerHtml;
var peopleList = generateList(people,template);
//peopleList = "<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>"

*/

function escapeString(str){
	var escapedStr = str.replace(/&/g, '&amp;');
	escapedStr = escapedStr.replace(/</g, '&lt;');
	escapedStr = escapedStr.replace(/>/g, '&gt;');
	escapedStr = escapedStr.replace(/"/g, '&quot;');
	escapedStr = escapedStr.replace(/'/g, "&#39");

	return escapedStr;
}

/*Function that creates a <li> tag for a list of objects and a given template*/
function generateList(objectArr, template){
	
	var result = [];
	result.push("<ul>");

	for (var i = 0; i < objectArr.length; i++) {
		result.push(generateListItem(objectArr[i], template));
	};

	result.push("</ul>");

	return result.join("");
}

/*Function that creates a <li> tag for a given object and a given template*/
function generateListItem(obj, template){
	var index = template.indexOf("-{");
	var indexEnd = 0;
	var previousIndex = 0;
	var placeholder = "";
	var result = ["<li>"];

	while (index >=0){
		result.push(template.substring(previousIndex, index));
		indexEnd = template.indexOf("}-", index);
		placeholder = template.substring(index+2, indexEnd);
		result.push(obj[placeholder]);
		previousIndex = indexEnd + 2;
		index = template.indexOf("-{", previousIndex);
	}
	result.push(template.substring(previousIndex, template.length));
	result.push("</li>");

	return result.join("");
}

/*Constructor of the person object*/
function person(name, age){
	return {
		name: name, 
		age: age,
		toString : function (){return this.name + " - " + this.age}
	}
}

var people = [person("Peter", 14), person("Stefan", 28), person("Stoqn", 55)];
var template = document.getElementById("list-item").innerHTML;

jsConsole.writeLine("The format string is: " + escapeString(template));
jsConsole.writeLine("The list of objects is: " + people);
jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("The result list is: " + escapeString(generateList(people, template)));
jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("Please see the result list added under this jsConsole div.");
document.getElementById("list-item").innerHTML = generateList(people, template);


