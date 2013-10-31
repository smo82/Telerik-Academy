/*
Task06
Write a function that extracts the content of a html page given as text. 
The function should return anything that is in a tag, without the tags:

<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>

result:
Sample sitetextmore textand more...in body
*/

function escapeStrint(str){
	var escapedStr = str.replace(/&/g, '&amp;');
	escapedStr = escapedStr.replace(/</g, '&lt;');
	escapedStr = escapedStr.replace(/>/g, '&gt;');
	escapedStr = escapedStr.replace(/"/g, '&quot;');
	escapedStr = escapedStr.replace(/'/g, "&#39");

	return escapedStr;
}

function extractTextFromHtml(str){

	var indexClose = 0;
	var index = str.indexOf("<");
	var result = [];

	while (index >= 0)
	{
		result.push(str.substring(indexClose, index));

		indexClose = str.indexOf(">", index+1) + 1;
		index = str.indexOf("<", indexClose);
	}

	if (indexClose < str.length)
		result.push(str.substring(indexClose, str.length));
	
	return result.join("");
}

var str = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
var strEscaped = escapeStrint(str);
jsConsole.writeLine("The HTML is: " + strEscaped);
jsConsole.writeLine("The extracted text is: " + extractTextFromHtml(str));
