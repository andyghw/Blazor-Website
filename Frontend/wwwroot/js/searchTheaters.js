function JSMethod() {
    initMap();
}


var map;
var service;
var infowindow;
var currentLatitude
var currentLongitude
var map;

function initMap() {
    document.getElementById('more')
    // Create the map.
    if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(function (position) {
            currentLatitude = position.coords.latitude;
            currentLongitude = position.coords.longitude;
            var pyrmont = { lat: currentLatitude, lng: currentLongitude };
            map = new google.maps.Map(document.getElementById('map'), {
                center: pyrmont,
                zoom: 15
            });

            // Create the places service.
            var service = new google.maps.places.PlacesService(map);
            var getNextPage = null;
            var moreButton = document.getElementById('more');
            moreButton.onclick = function () {
                moreButton.disabled = true;
                if (getNextPage) getNextPage();
            };

            // Perform a nearby search.
            service.nearbySearch(
                { location: pyrmont, type: ['movie_theater'], keyword: 'movie', rankBy: google.maps.places.RankBy.DISTANCE },
                function (results, status, pagination) {
                    if (status !== 'OK') return;

                    createMarkers(results);
                    moreButton.disabled = !pagination.hasNextPage;
                    getNextPage = pagination.hasNextPage && function () {
                        pagination.nextPage();
                    };
                });
        });  
    }
}

function createMarkers(places) {
    var bounds = new google.maps.LatLngBounds();
    var placesList = document.getElementById('places');

    for (var i = 0, place; place = places[i]; i++) {
        var image = {
            url: 'https://cdn4.iconfinder.com/data/icons/small-n-flat/24/map-marker-512.png',
            size: new google.maps.Size(71, 71),
            origin: new google.maps.Point(0, 0),
            anchor: new google.maps.Point(17, 34),
            scaledSize: new google.maps.Size(25, 25)
        };

        var marker = new google.maps.Marker({
            map: map,
            icon: image,
            title: place.name,
            position: place.geometry.location
        });

        var li = document.createElement('li');
        li.innerHTML = '<a target="_blank" href="https://www.google.com/maps/search/' + place.name + '/@' + currentLatitude + ',' + currentLongitude + 'z">' + place.name + '</a>';
        placesList.appendChild(li);

        bounds.extend(place.geometry.location);
    }
    map.fitBounds(bounds);
}