
//Map creation is here
//Defining map as a global variable to access from
//other functions
var map;
function initMap() 
{
//Enabling new cartography and themes
google.maps.visualRefresh = true;

//Setting starting options of map
var mapOptions = {
center: new google.maps.LatLng(40.823647, -73.943855),
zoom: 13,
mapTypeId: google.maps.MapTypeId.ROADMAP
};

//Getting map DOM element
var mapElement = document.getElementbyId("mapDiv");


//Creating a map with DOM element which is just
//obtained
map = new google.maps.Map(mapElement, mapOptions);

}
google.maps.event.addDomListener(window, 'load',initMap);
                                                           
