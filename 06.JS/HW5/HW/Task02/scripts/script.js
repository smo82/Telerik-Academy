/*
Task02
Write a script that compares two char arrays lexicographically (letter by letter).
*/

var stringTextField = document.getElementById("string");
var firstCharArr = [];
var secondCharArr = [];

var buttonProcess = document.getElementById("buttonProcess");

jsConsole.writeLine('Please enter your first string and press "Process"');

buttonProcess.addEventListener('click',ProcessEvent,false);

function ProcessEvent()
{
	if (stringTextField.value)
	{
		if (firstCharArr.length == 0)
		{
			firstCharArr = stringTextField.value.split('');
			jsConsole.writeLine('Your first array is: ');
			printArr (firstCharArr);
			jsConsole.writeLine();
			jsConsole.writeLine('Please enter your second string and press "Process"');
			stringTextField.value = "";
		}
		else
		{
			secondCharArr = stringTextField.value.split('');
			jsConsole.writeLine('Your second array is: ');
			printArr (secondCharArr);

			var resultMatch = matchArrays(firstCharArr, secondCharArr);
			
			jsConsole.writeLine();
			jsConsole.writeLine("--------------------------------------");

			if (resultMatch < 0)
				jsConsole.writeLine('The first array is smaller then the second!');
			else if (resultMatch > 0)
				jsConsole.writeLine('The first array is bigger then the second!');
			else
				jsConsole.writeLine('The two arrays are equal!');
		}
	}
	else
	{
		alert("Empty string!");
	}
}

function printArr (arr)
{
	for (var i = 0; i < arr.length; i++) {
		jsConsole.write("arr[" + i + "] = " + arr[i] + "; ");
	};
}

function matchArrays(arr1, arr2)
{
	if (arr1.length < arr2.length)
		return matchShorterWithBiggerArr(arr1, arr2);
	else
		return matchShorterWithBiggerArr(arr2, arr1) * (-1);
}

function matchShorterWithBiggerArr(shorterArr, longerArr)
{
	var index = 0;
	while (index < shorterArr.length)
	{
		if (shorterArr[index] < longerArr[index])
			return -1;
		else if (shorterArr[index] > longerArr[index])
			return 1;

		index++;
	}

	if (shorterArr.length == longerArr.length)
		return 0;
	else
		return -1;
}
