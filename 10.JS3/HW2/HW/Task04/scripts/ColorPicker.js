var controls = (function(){
  var redSlider;
  var greenSlider;
  var blueSlider;
  var targetHolder;

  function hexFromRGB(r, g, b) {
    var hex = [
      r.toString( 16 ),
      g.toString( 16 ),
      b.toString( 16 )
    ];
    $.each( hex, function( nr, val ) {
      if ( val.length === 1 ) {
        hex[ nr ] = "0" + val;
      }
    });
    return hex.join( "" ).toUpperCase();
  }

  function applyColor(){      
    var red = redSlider.slider( "value" );
    var green = greenSlider.slider( "value" );
    var blue = blueSlider.slider( "value" );
    var hex = hexFromRGB( red, green, blue );
    targetHolder.css( "background-color", "#" + hex );      
  }

  function init(selectorHolder, selectorTarget){
    colorSelectorHolder = $(selectorHolder);
    targetHolder = $(selectorTarget);
    redSlider = $(document.createElement("div"));
    redSlider.attr("id", "red");
    redSlider.attr("class", "ui-slider-range ui-slider-handle");
    greenSlider = $(document.createElement("div"));
    greenSlider.attr("id", "green");
    greenSlider.attr("class", "ui-slider-range ui-slider-handle");
    blueSlider = $(document.createElement("div"));
    blueSlider.attr("id", "blue");
    blueSlider.attr("class", "ui-slider-range ui-slider-handle");

    colorSelectorHolder.append(redSlider);
    colorSelectorHolder.append(greenSlider);
    colorSelectorHolder.append(blueSlider);

    $(function() {
      $( "#red, #green, #blue" ).slider({
        orientation: "horizontal",
        range: "min",
        max: 255,
        value: 127,
        slide: applyColor,
        change: applyColor
      });

      redSlider.slider("value", 127);
      greenSlider.slider("value", 127);
      blueSlider.slider("value", 127);
    });    
  }

  return {    
    initColorSelector : init
  }
}());