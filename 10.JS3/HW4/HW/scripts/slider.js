var controls = (function(){

  var slideNumber = function(newNumber, bottomValue, topValue){
    if (newNumber < bottomValue){
      newNumber = topValue;
    } else if (newNumber > topValue){
      newNumber = bottomValue;
    }

    return newNumber;
  }

  var Item = {
    init: function(innerHtmlCode) {
      this.innerHtmlCode = innerHtmlCode;
      this.itemContainer = $("<div></div>");
      this.itemContainer.attr("class", "sliderItem");
    },

    render: function() {
      return this.itemContainer.html(this.innerHtmlCode);
    }
  };

  var Slider = {
    init: function(selector) {
      this.sliderItem = $(selector);
      this.items = [];

      this.mainSlideContainter = $(document.createElement("div"));
      this.mainSlideContainter.attr("id", "mainSlideContainter");

      this.slideList = $(document.createElement("div"));
      this.slideList.attr("id", "slideItemHolder")

      this.previousButton = $(document.createElement("button"));
      this.previousButton.text("previous");
      this.previousButton.attr("id", "previousButton");

      this.nextButton = $(document.createElement("button"));
      this.nextButton.text("next");
      this.nextButton.attr("id", "nextButton");

      this.slideShowStartButton = $(document.createElement("button"));
      this.slideShowStartButton.text("SlideShow Start");
      this.slideShowStartButton.attr("id", "slideShowStartButton");

      this.slideShowStopButton = $(document.createElement("button"));
      this.slideShowStopButton.text("SlideShow Stop");
      this.slideShowStopButton.attr("id", "slideShowStopButton");

      this.currentSlide = 0;

      var slider = this;
      var slideshowTimer;
      this.sliderItem.on("click",
      function(ev) {
        if (!ev) {
          ev = window.event;
        }
        ev.stopPropagation();
        ev.preventDefault();

        var clickedItemHtml = ev.target;
        var clickedItem = $(clickedItemHtml);

        if (clickedItemHtml instanceof HTMLButtonElement){

          if(clickedItem.attr("id") == "previousButton") {
            slider.currentSlide = slideNumber(slider.currentSlide - 1, 0, slider.items.length-1);
            slider.render();
          }

          if(clickedItem.attr("id") == "nextButton") {
            slider.currentSlide = slideNumber(slider.currentSlide + 1, 0, slider.items.length-1);          
            slider.render();
          }
        
          if(clickedItem.attr("id") == "slideShowStartButton") {
            slideshowTimer = setInterval(function() {
              slider.currentSlide = slideNumber(slider.currentSlide + 1, 0, slider.items.length-1);   
              slider.render();
            }, 2000);
          }
        
          if(clickedItem.attr("id") == "slideShowStopButton") {
            clearInterval(slideshowTimer);
          }
        }

      });
    },

    addItem: function(innerHtmlCode){
      var item = Object.create(Item);
      item.init(innerHtmlCode);
      this.items.push(item)
    },

    render: function() {
      while (this.sliderItem.firstChild) {
        this.sliderItem.removeChild(this.sliderItem.firstChild);
      }

      while (this.slideList.firstChild) {
        this.slideList.removeChild(this.slideList.firstChild);
      }

      for (var i = 0, len = this.items.length; i < len; i += 1) {
        var domItem = this.items[i].render();
        domItem.attr("id", "slide" + i);
        this.slideList.append(domItem);
      }
      this.sliderItem.append(this.slideList);

      if (this.items[this.currentSlide]){
        this.mainSlideContainter.html(this.items[this.currentSlide].innerHtmlCode);
      }

      innerContainer = $(document.createElement("div"));
      innerContainer.attr("id", "innerContainer");

      navContainer = $(document.createElement("div"));
      innerContainer.attr("id", "navContainer");
      innerContainer.append(navContainer);
      navContainer.append(this.previousButton);
      navContainer.append(this.nextButton);
      navContainer.append(this.slideShowStartButton);
      navContainer.append(this.slideShowStopButton);      

      innerContainer.append(this.mainSlideContainter);
      this.sliderItem.append(innerContainer);
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