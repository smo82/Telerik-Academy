var classes = (function(){

  /*****************************************************************************/
  /* I don't use predicate classes because they interfere with the google api. */
  /*****************************************************************************/
  return {
    Coord : function(lat, long, name, description){  
      return {
        lat: lat,
        long: long,
        name: name,
        description: description,
      } 
    }
  }
}());

window.onload = function WindowLoad(event) {
  var cities = [];
  var sofiaCoord = classes.Coord(42.698586, 23.345947, "Sofia", "Sofia description");
  cities.push(sofiaCoord);
  var parisCoord = classes.Coord(48.89364, 2.33739, "Paris", "Paris description");
  cities.push(parisCoord);
  var londonCoord = classes.Coord(51.508742, -0.131836, "London", "London description");
  cities.push(londonCoord);
  var romeCoord = classes.Coord(41.902277, 12.436523, "Rome", "Rome description");
  cities.push(romeCoord);
  var barcelonaCoord = classes.Coord(41.376809, 2.241211, "Barcelona", "Barcelona description");
  cities.push(barcelonaCoord);
  var berlinCoord = classes.Coord(52.589701, 13.491211, "Berlin", "Berlin description");
  cities.push(berlinCoord);
  var moskvaCoord = classes.Coord(55.764213, 37.622681, "Moskva", "Moskva description");
  cities.push(moskvaCoord);
  var tokioCoord = classes.Coord(35.710838, 139.724121, "Tokio", "Tokio description");
  cities.push(tokioCoord);
  var shanghaiCoord = classes.Coord(31.203405, 121.420898, "Shanghai", "Shanghai description");
  cities.push(shanghaiCoord);
  var aucklandCoord = classes.Coord(-36.879621, 174.79248, "Auckland", "Auckland description");
  cities.push(aucklandCoord);

  var navDiv = document.getElementById("navigation");

  var cityButton;
  for (var i = 0; i < cities.length; i++) {
    cityButton = document.createElement("button");
    cityButton.innerHTML = cities[i].name;
    cityButton.id = i + "cityButton";
    navDiv.appendChild(cityButton);
  };

  navDiv.addEventListener('click', function (event) {
    clickedItem = event.target;
    currentCityCoord = parseInt(clickedItem.id);

    changeLocation();
  });

  var currentCityCoord = 0;

  var zoom = 5;
  var map;
  var infowindow;
      
  function googleMapInitialize() {
    var currentCity = cities[currentCityCoord];
    var pos = new google.maps.LatLng(parseInt(currentCity.lat), parseInt(currentCity.long));
    var mapOptions = {
        zoom: zoom,
        center: pos,
        mapTypeId: google.maps.MapTypeId.SATELLITE //ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    infowindow = new google.maps.InfoWindow({
        map: map,
        position: pos,
        content: currentCity.description
    });
  }
  google.maps.event.addDomListener(window, 'load', googleMapInitialize());

  function changeLocation(){
    var currentCity = cities[currentCityCoord];
    var pos = new google.maps.LatLng(currentCity.lat, currentCity.long);

    infowindow.close();
    infowindow = new google.maps.InfoWindow({
        map: map,
        position: pos,
        content: currentCity.description
    });

    map.panTo(pos);
    map.setZoom(zoom);
  }

  document.getElementById('previous').addEventListener('click', function () {
    currentCityCoord--;
    if (currentCityCoord < 0){
      currentCityCoord = cities.length - 1;
    }

    changeLocation();
  });

  document.getElementById('next').addEventListener('click', function () {
    currentCityCoord++;
    if (currentCityCoord > cities.length - 1){
      currentCityCoord = 0;
    }

    changeLocation();
  });
}


