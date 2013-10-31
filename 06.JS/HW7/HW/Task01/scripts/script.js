/*
Task01
Write functions for working with shapes in  standard Planar coordinate system
- Points are represented by coordinates P(X, Y)
- Lines are represented by two points, marking their beginning and ending
  - L(P1(X1,Y1),P2(X2,Y2))
- Calculate the distance between two points
- Check if three segment lines can form a triangle
*/

function CreatePoint(xValue,yValue)
{
	return{
		x : xValue,
		y : yValue,
		toString : function(){
			return "(" + this.x + "," + this.y + ")";
		}
	}
}

function CreateLine(beginPoint, endPoint)
{
	return{
		A : beginPoint,
		B : endPoint,
		toString : function(){
			return "(" + this.A.toString() + "," + this.B.toString() + ")";
		}
	}
}

function CalculatePointDistance (firstPoint, secondPoint)
{
	return Math.sqrt((firstPoint.x - secondPoint.x)*(firstPoint.x - secondPoint.x) + (firstPoint.y - secondPoint.y)*(firstPoint.y - secondPoint.y));
}

function CreateLinePoints(x1, y1, x2, y2)
{
	return{
		a : CreatePoint(x1, y1),
		b : CreatePoint(x2, y2),
		toString : function(){
			return "(" + this.a.toString() + "," + this.b.toString() + ")";
		},
		lenght : function CalculateLineLenght(){
			return CalculatePointDistance(this.a, this.b);
		}
	}
}

function CheckIfPossibleTriangle(firstLine, secondLine, thirdLine){
	var check = true;
	if (firstLine.lenght() + secondLine.lenght() < thirdLine.lenght())
		check = false;
	if (firstLine.lenght() + thirdLine.lenght() < secondLine.lenght())
		check = false;
	if (secondLine.lenght() + thirdLine.lenght() < firstLine.lenght())
		check = false;

	return check;
}

var firstLine = CreateLinePoints(0, 0, 1, 1);
jsConsole.writeLine("First line: " + firstLine.toString() + ", Lenght: " + firstLine.lenght());
var secondLine = CreateLinePoints(2, 2, 2.5, 2.5);
jsConsole.writeLine("First line: " + secondLine.toString() + ", Lenght: " + secondLine.lenght());
var thirdLine = CreateLinePoints(0, 0, -1, -1);
jsConsole.writeLine("First line: " + thirdLine.toString() + ", Lenght: " + thirdLine.lenght());

jsConsole.writeLine("Is a triangle possible? - " + CheckIfPossibleTriangle(firstLine, secondLine, thirdLine));
