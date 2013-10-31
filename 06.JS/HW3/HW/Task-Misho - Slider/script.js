var currentLi = 0;
var liArr = document.getElementsByTagName("li");
NextImage ();
var buttonNext = document.getElementById("next");
var buttonPrevious = document.getElementById("previous");

buttonNext.addEventListener("click", NextImage, false);
buttonPrevious.addEventListener("click", PreviousImage, false);

//Applies the click of the next button
function NextImage (){
	//We hide the previous image
	Hide(GetPrevious());
	//We make the current image small and we display it to the left
	DisplayImage(currentLi, "200px", "140px", "10px");
	//We select the next image
	currentLi = GetNext();
	//We make the new current image big
	DisplayImage(currentLi, "450px", "10px", "290px");
	//We make the next image small and we display it to the right
	DisplayImage(GetNext(), "200px", "140px", "900px");
}

//Applies the click of the previous button
function PreviousImage (){
	//We hide the small image to the right
	Hide(GetNext());
	//We make the current image small and we display it to the right
	DisplayImage(currentLi, "200px", "140px", "900px");
	//We select the previous image
	currentLi = GetPrevious();
	//We make the new current image big
	DisplayImage(currentLi, "450px", "10px", "290px");
	//We make the previous image small and we display it to the left
	DisplayImage(GetPrevious(), "200px", "140px", "10px");
}

function GetNext(){
	if (currentLi == liArr.length-1)
		return 0;		
	else
		return currentLi+1;
}

function GetPrevious(){
	if (currentLi == 0)
		return liArr.length-1;	
	else
		return currentLi-1;
}

//Displays the image with a given size and on a given position
function DisplayImage(mainLi, size, top, left){
	liArr[mainLi].style.display = "inline-block";		
	var img = liArr[mainLi].getElementsByTagName("img");
	img[0].style.height = size;
	liArr[mainLi].style.top = top;
	liArr[mainLi].style.left = left;
}

function Hide(hiddenLi){
	liArr[hiddenLi].style.display = "none";
}