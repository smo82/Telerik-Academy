var maxProp = getFirstProp(document);
var minProp = maxProp;

getMaxAndMinProp(document);

jsConsole.writeLine("The smallest lexicographically property in 'document' is: " + minProp);
jsConsole.writeLine("The biggest lexicographically property in 'document' is: " + maxProp);

var maxProp = getFirstProp(window);
var minProp = maxProp;
getMaxAndMinProp(window);
jsConsole.writeLine("The smallest lexicographically property in 'window' is: " + minProp);
jsConsole.writeLine("The biggest lexicographically property in 'window' is: " + maxProp);


var maxProp = getFirstProp(navigator);
var minProp = maxProp;
getMaxAndMinProp(navigator);
jsConsole.writeLine("The smallest lexicographically property in 'navigator' is: " + minProp);
jsConsole.writeLine("The biggest lexicographically property in 'navigator' is: " + maxProp);


//Returns the first property of an object
function getFirstProp (obj)
{
	for (var prop in obj) {
		return prop;
	}
}

//Gets lexicographically the minimal and maximal property of an object
function getMaxAndMinProp (obj)
{
	for (var prop in obj) {
		if (prop > maxProp)
			maxProp = prop;
		else if (prop < minProp)
			minProp = prop;
	};
}
