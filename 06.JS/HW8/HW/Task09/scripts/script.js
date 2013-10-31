/*
Task09
Write a function for extracting all email addresses from given text. 
All substrings that match the format <identifier>@<host>…<domain> should be 
recognized as emails. Return the emails as array of strings.
*/

function escapeString(str){
	var escapedStr = str.replace(/&/g, '&amp;');
	escapedStr = escapedStr.replace(/</g, '&lt;');
	escapedStr = escapedStr.replace(/>/g, '&gt;');
	escapedStr = escapedStr.replace(/"/g, '&quot;');
	escapedStr = escapedStr.replace(/'/g, "&#39");

	return escapedStr;
}

function getEmails(text){
	var indexStartEmail = 0;
	var indexAt = text.indexOf("@");
	var indexDot = 0;
	var indexEndEmail = 0;
	var stringAtToEnd = "";
	var result = [];

	while (indexAt >=0){
		indexStartEmail = text.lastIndexOf(" ", indexAt);
		if (indexStartEmail == -1)
			indexStartEmail = 0;
		indexEndEmail = text.indexOf(" ", indexAt);
		if (indexEndEmail == -1)
			indexEndEmail = text.length-1;
		stringAtToEnd = text.substring(indexAt+1, indexEndEmail);
		indexDot = stringAtToEnd.indexOf(".");

		if ((indexDot > 0) && 
			(stringAtToEnd.indexOf(".", indexDot+1) === -1) &&
			(stringAtToEnd.length - indexDot - 1 < 6)){ 
			result.push(text.substring(indexStartEmail, indexEndEmail));
		}
		indexAt = text.indexOf("@", indexEndEmail);
	}

	return result;
}

var i;
var text = "Alaabala safsd fasd fas ala@bala.com sad;flkasd;kgsa @strangeString not@an_email asd;flkas;dfkl bala@ala.eu and not@an.correct_email! test@gmail.com.";
jsConsole.writeLine("The original text is: " + escapeString(text));
jsConsole.writeLine("-----------------------------------------------");
jsConsole.writeLine("The list of found e-mails is: ");

var emailsArr = getEmails(text);
for (i = 0; i < emailsArr.length; i++) {
	jsConsole.writeLine(emailsArr[i]);
};
