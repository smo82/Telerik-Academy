var liArr = document.getElementsByTagName("li");

for (var i = 0; i < liArr.length; i++) {
	liArr[i].addEventListener("mouseover", onMouseOverFunc, false);
	liArr[i].addEventListener("mouseout", onMouseOutFunc, false);
	var liButton = liArr[i].getElementsByTagName("button");
	liButton[0].parent = liArr[i];
	liButton[0].addEventListener("click", onCloseClick, false);
};

function onMouseOverFunc(e){
	var section = e.currentTarget.getElementsByTagName("section");
	section[0].style.display = "block";
}

function onMouseOutFunc(e){
	var section = e.currentTarget.getElementsByTagName("section");
	section[0].style.display = "none";
}

function onCloseClick(e){
	var buttonParent = e.currentTarget.parent;
	var pos = 0;
	animLi();
	function animLi(){
		buttonParent.style.marginLeft = pos + "px";
		if (pos < 1500)
			setTimeout(animLi, 5);
		pos = pos + 5;
		console.log(pos);
	}

	setTimeout(function hideElement(){buttonParent.style.display = "none";}, 1500);	
}




