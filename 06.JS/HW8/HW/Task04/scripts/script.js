/*
Task04
You are given a text. Write a function that changes the text in all regions:
<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)

Example:
"We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. 
We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else."

The expected result:

"We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else."

Regions can be nested
*/

function escapeStrint(str){
	var escapedStr = str.replace(/&/g, '&amp;');
	escapedStr = escapedStr.replace(/</g, '&lt;');
	escapedStr = escapedStr.replace(/>/g, '&gt;');
	escapedStr = escapedStr.replace(/"/g, '&quot;');
	escapedStr = escapedStr.replace(/'/g, "&#39");

	return escapedStr;
}

function toMixedCase(str){
	var mixedCase = [];

	for (var i = 0; i < str.length; i++) {
		if (Math.random() > 0.5)
			mixedCase.push(str[i].toLowerCase())
		else
			mixedCase.push(str[i].toUpperCase())
	};

	return mixedCase.join("");
}

function parseTextFormat(str){

	var indexClose = 0;
	var index = str.indexOf("<");
	var innerLevel = 0;
	var result = [];
	var inTagText = [];

	while (index >= 0)
	{
		if (innerLevel == 0)
			result.push(str.substring(indexClose, index));
		else
			inTagText.push(str.substring(indexClose, index));

		indexClose = str.indexOf(">", index+1) + 1;
		var command = str.substring(index, indexClose);
		
		if (command[1] == '/')
		{
			if (innerLevel == 1)
			{
				var inTagTextStr = inTagText.join("");
				inTagText = [];
				switch (command){
					case "</lowcase>":
						result.push(inTagTextStr.toLowerCase());
						inTagText = [];
						break;
					case "</upcase>":
						result.push(inTagTextStr.toUpperCase());
						inTagText = [];
						break;
					case "</mixcase>":
						result.push(toMixedCase(inTagTextStr));
						inTagText = [];
						break;
				}
			}
			
			innerLevel--;

		}
		else
			innerLevel++;

		index = str.indexOf("<", indexClose);
	}

	if (indexClose < str.length)
		result.push(str.substring(indexClose, str.length));
	
	return result.join("");
}

var str = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
var strEscaped = escapeStrint(str);
jsConsole.writeLine("The text is: " + strEscaped);
jsConsole.writeLine("The formatted text is: " + parseTextFormat(str));

jsConsole.writeLine("-------------------------------------------------------");
str = "We are <mixcase>living  in a <upcase>yellow submarine</upcase></mixcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
strEscaped = escapeStrint(str);
jsConsole.writeLine("The second text is: " + strEscaped);
jsConsole.writeLine("The formatted text is: " + parseTextFormat(str));