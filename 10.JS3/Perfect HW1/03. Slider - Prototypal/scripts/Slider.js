/// <reference path="ImageCollection.js" />
/// <reference path="ImageInfo.js" />
(function () {
    Slider = {
        init: function (sliderContainerSelector, selectedSelector) {
            this.sliderContainer = document.querySelector(sliderContainerSelector);
            this._initSliderContainer();

            this.sliderSelectedContainer;
            this._initSliderSelected(selectedSelector);

            this.images = Object.create(ImageCollection);
            this.images.init();
            this.currentImg = this.images.getFirst();
        },
        _initSliderContainer: function () {
            this.sliderContainer.style.position = "relative";
            var self = this;
            this.sliderContainer.addEventListener("click", function (ev) {
                if (ev.target.nodeName === "IMG") {
                    self.sliderSelectedContainer.style.display = "";
                    self.displayByTitle(ev.target.title);                   
                }
                else if(ev.target.nodeName === "BUTTON"){
                }
                else {
                    self.sliderSelectedContainer.style.display = "none";
                }

            }, false);
        },
        _initSliderSelected: function (selectedSelector) {
            this.sliderSelectedContainer = document.createElement("div");
            this.sliderSelectedContainer.style.display = "none";
            this.sliderSelectedContainer.style.position = "";
            this.sliderSelectedContainer.setAttribute("id", selectedSelector);

            this.sliderContainer.appendChild(this.sliderSelectedContainer);

        },
        _displayCurrentImg: function (currentImgInfo) {
            var self = this;
            while (this.sliderSelectedContainer.firstChild) {
                this.sliderSelectedContainer.removeChild(this.sliderSelectedContainer.firstChild);
            }

            var btnContainer = document.createElement("div");

            var btnLeft = document.createElement("button");
            btnLeft.innerHTML = "Previous";
            btnLeft.addEventListener("click", function (ev) {
                ev.preventDefault();
                self.displayPrevious();
            }, false);

            var btnRight = document.createElement("button");
            btnRight.innerHTML = "Next";
            btnRight.addEventListener("click", function (ev) {
                ev.preventDefault();
                self.displayNext();
            }, false);

            btnContainer.appendChild(btnLeft);
            btnContainer.appendChild(btnRight);

            this.sliderSelectedContainer.appendChild(btnContainer);

            var currentImg = document.createElement("img");
            currentImg.title = currentImgInfo.title;
            currentImg.src = currentImgInfo.imageURL;

            this.sliderSelectedContainer.appendChild(currentImg);
        },
        displayByTitle: function (title) {
            var currentImgInfo = this.images.setCurrentByTitle(title);
            this._displayCurrentImg(currentImgInfo);
        },
        displayNext: function () {
            var currentImgInfo = this.images.getNext();
            this._displayCurrentImg(currentImgInfo);
        },
        displayPrevious: function () {
            var currentImgInfo = this.images.getPrevious();
            this._displayCurrentImg(currentImgInfo);
        },
        addImage: function (imgTitle, imgSrc, thumbnailSrc) {
            this.images.addImage(imgTitle, imgSrc, thumbnailSrc);
        },
        render: function () {
            var fragment = document.createDocumentFragment();
            for (var img in this.images.images) {
                if (img !== "extend") {
                    var newImg = document.createElement("img");
                    newImg.title = this.images.images[img].title;
                    newImg.src = this.images.images[img].thumbnailURL;

                    fragment.appendChild(newImg);
                }                
            }

            this.sliderContainer.appendChild(fragment);
        }
    };
}())