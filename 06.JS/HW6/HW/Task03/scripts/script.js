/*
Task03
Write a function that finds all the occurrences of word in a text
- The search can be case sensitive or case insensitive
- Use function overloading

*/

var wordField = document.getElementById("word");

var buttonProcess = document.getElementById("buttonProcess");

const text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
jsConsole.writeLine('The text is:');
jsConsole.writeLine(text);
jsConsole.writeLine('Please enter the word you want to search and press the "Process" button.');

buttonProcess.addEventListener('click',countWord,false);

function countWord()
{
	if (wordField.value.length == 0)
		alert("Please enter a word!");
	else
	{	
		/*
		//Case insensitive call
		var result = findWord(wordField.value, 2);
		*/

		//Case sensitive call
		var result = findWord(wordField.value);
		if (result.length == 0)
			jsConsole.writeLine("The word was not found");
		else
			jsConsole.writeLine("The word was found " + result.length + " 	times");

	}
}

function findWord (word)
{
	if (arguments.length == 1)
		return findAllMatches (word, "g");
	else
	{
		switch (arguments[1])
		{
			/*Case sensitive*/
			case 1 :
				return findAllMatches (word, "g");
				break;
			/*Case insensitive*/
			case 2 :
				return findAllMatches (word, "gi");
				break;
		}
	}
}

function findAllMatches (word, paramCase)
{
	var regex = new RegExp(word, paramCase);
	var result;
	var indices = [];
	while ( (result = regex.exec(text)) ) {
	    indices.push(result.index);
	}
	return indices;
}