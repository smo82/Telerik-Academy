var controls = (function(){

  var Image = {
    init: function(name, thumbnailUrl, largeImageUrl) {
      this.name = name;
      this.thumbnailUrl = thumbnailUrl;
      this.largeImageUrl = largeImageUrl;
    },

    render: function() {
      var imageNode = document.createElement("li");
      imageNode.innerHTML = "<img src='" + this.thumbnailUrl + "' alt='" + this.name + "'>";
      return imageNode;
    }
  };

  var Slider = {
    init: function(selector) {
      this.sliderItem = document.querySelector(selector);
      this.images = [];

      this.bigImage = document.createElement("img");
      this.bigImage.style.display = "none";
      this.bigImage.id = "bigImage";

      this.imageList = document.createElement("ul");

      this.previous = document.createElement("button");
      this.previous.style.display = "none";
      this.previous.innerHTML = "previous";
      this.previous.id = "previous";

      this.next = document.createElement("button");
      this.next.style.display = "none";
      this.next.innerHTML = "next";
      this.next.id = "next";

      var slider = this;
      var currentImage;

      this.sliderItem.addEventListener("click",
      function(ev) {
        if (!ev) {
          ev = window.event;
        }
        ev.stopPropagation();
        ev.preventDefault();

        var clickedItem = ev.target;

        if ((clickedItem instanceof HTMLImageElement) &&
            (clickedItem.id != "bigImage")) {
          if (slider.bigImage.style.display === "none"){
            slider.bigImage.style.display = "";
          }

          var imageId = clickedItem.parentNode.id.substr(3);
          var imageIdInt = parseInt(imageId);

          var imageUrlBig = slider.images[imageIdInt].largeImageUrl;
          slider.bigImage.src = imageUrlBig;

          currentImage = imageIdInt;
        }

        if ((clickedItem instanceof HTMLButtonElement) &&
            (clickedItem.id == "previous")) {
          currentImage--;

          var imageUrlBig = slider.images[currentImage].largeImageUrl;
          slider.bigImage.src = imageUrlBig;
        }

        if ((clickedItem instanceof HTMLButtonElement) &&
            (clickedItem.id == "next")) {
          currentImage++;
        
          var imageUrlBig = slider.images[currentImage].largeImageUrl;
          slider.bigImage.src = imageUrlBig;
        }

        if (currentImage != undefined){
          if (currentImage > 0){
            if (slider.previous.style.display === "none"){
              slider.previous.style.display = "";
            }
          } else {
            if (slider.previous.style.display !== "none"){
              slider.previous.style.display = "none";
            }
          }

          if (currentImage < slider.images.length - 1){
            if (slider.next.style.display === "none"){
              slider.next.style.display = "";
            }
          } else {
            if (slider.next.style.display !== "none"){
              slider.next.style.display = "none";
            }
          }
        }

      }, false);
    },

    addImage: function(name, thumbnailUrl, largeImageUrl){
      var image = Object.create(Image);
      image.init(name, thumbnailUrl, largeImageUrl);
      this.images.push(image)
    },

    render: function() {
      while (this.sliderItem.firstChild) {
        this.sliderItem.removeChild(this.sliderItem.firstChild);
      }

      while (this.imageList.firstChild) {
        this.imageList.removeChild(this.imageList.firstChild);
      }

      for (var i = 0, len = this.images.length; i < len; i += 1) {
        var domItem = this.images[i].render();
        domItem.id = "img" + i;
        this.imageList.appendChild(domItem);
      }
      this.sliderItem.appendChild(this.imageList);

      innerContainer = document.createElement("div");
      innerContainer.id = "innerContainer";
      innerContainer.appendChild(this.previous);
      innerContainer.appendChild(this.bigImage);
      innerContainer.appendChild(this.next);
      this.sliderItem.appendChild(innerContainer);
      return this;
    }
  };

  return{
    getSlider : function(selector) {
      var slider = Object.create(Slider);
      slider.init(selector);
      return slider;
    },
  }
}());