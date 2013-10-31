/*
Task10
Write a program that extracts from a given text all palindromes, e.g. "ABBA", 
"lamal", "exe".

*/

function isPalindrome(word){
	if (word === "")
		return false;
	for (var i = 0; i < Math.floor(word.length/2); i++) {
		if (word[i] != word[word.length-i-1])
			return false;
	}

	return true;
}

function extractPalindromes(text){
	var words = text.split(/[\s,;.!?]+/);
	var palindromes = [];

	for (var i = 0; i < words.length; i++) {
		if (isPalindrome(words[i]))
			palindromes.push(words[i]);
	};

	return palindromes;
}

var i;
var text = "Some text ABBA and lamal and exe!";
jsConsole.writeLine("The original text is: " + text);
jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("The list of found palindromes is: ");

var palindromes = extractPalindromes(text);
for (i = 0; i < palindromes.length; i++) {
	jsConsole.writeLine(palindromes[i]);
};
