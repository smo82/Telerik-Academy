/*
Task08
Write a JavaScript function that replaces in a HTML document given as string all 
the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
Sample HTML fragment:

<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a 
training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the 
courses.</p>

<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a 
training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the 
courses.</p>

*/

function escapeString(str){
	var escapedStr = str.replace(/&/g, '&amp;');
	escapedStr = escapedStr.replace(/</g, '&lt;');
	escapedStr = escapedStr.replace(/>/g, '&gt;');
	escapedStr = escapedStr.replace(/"/g, '&quot;');
	escapedStr = escapedStr.replace(/'/g, "&#39");

	return escapedStr;
}

function parseUrl(html){
	/*-------------------------------------*/
	/*Replace <a href='...'> with [URL=...]*/
	/*-------------------------------------*/
	var replacedStr = "<a href='";
	var replacedStrEnd = "'>";
	var replacementStr = "[URL=";
	var replacementStrEnd = "]";
	var previousIndex = 0;
	var index = html.indexOf(replacedStr);
	var result = [];

	while (index >=0){
		//Push in the new array the text before the search string
		result.push(html.substring(previousIndex, index));
		//After that push the replacing string
		result.push(replacementStr);
		//Then we search the index of the closing string - in our case "'>"
		previousIndex = index + replacedStr.length;
		index = html.indexOf(replacedStrEnd, previousIndex);
		//We push the text between the search string and the closing string
		result.push(html.substring(previousIndex, index));
		//We push the replacing closing string
		result.push(replacementStrEnd);
		//We search for a next occurrence of the searched string
		previousIndex = index + replacedStrEnd.length;
		index = html.indexOf(replacedStr, previousIndex);
	}
	//We push the text after the last occurrence of the searched closing string
	result.push(html.substring(previousIndex, html.length));

	html = result.join("");
	result = [];

	/*------------------------*/
	/*Replace </a> with [/URL]*/
	/*------------------------*/
	replacedStr = "</a>";
	replacementStr = "[/URL]";
	index = html.indexOf(replacedStr);
	previousIndex = 0;

	while (index >=0){
		result.push(html.substring(previousIndex, index));
		result.push(replacementStr);
		previousIndex = index + replacedStr.length;
		index = html.indexOf(replacedStr, previousIndex);
	}
	result.push(html.substring(previousIndex, html.length));

	return result.join("");

	//Another way:
	//html = html.replace(new RegExp("</a>", 'g'), "[/URL]");
	//return html;
}

var html = "<p>Please visit <a href='http://academy.telerik. com'>our site</a> to choose a training course. Also visit <a href='www.devbg.org'>our forum</a> to discuss the courses.</p>";
jsConsole.writeLine("The original html is: " + escapeString(html));
jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("The formatted html is: " + escapeString(parseUrl(html)));
