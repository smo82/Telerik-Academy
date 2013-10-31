
function changeShareVideoButtonValue(video){
    var shareTag = document.getElementById('share-tag');
    console.log(shareTag);
    shareTag.setAttribute('href', 'http://www.youtube.com/watch?v=' + video);
    console.log('http://www.youtube.com/watch?v=' + video);
}

var video = document.getElementById('load-video').value;
changeShareVideoButtonValue(video);

var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '390', //must be bigger than 200px
        width: '640', //must be bigger than 200px
        //videoId: 'QEXFS2kV9UY',
        events: {
            'onReady': onPlayerReady,
        }
    });

    console.log(player);
}

function onPlayerReady(event) {    
    var video = document.getElementById('load-video').value;
    player.cueVideoById(video, 0, "large");
}

document.getElementById('pause').addEventListener('click', function () {
        player.pauseVideo();
}, false);

document.getElementById('stop').addEventListener('click', function () {
        player.stopVideo();
}, false);

document.getElementById('mute').addEventListener('click', function () {
        player.mute();
}, false);

document.getElementById('unmute').addEventListener('click', function () {
        player.unMute();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('set-volume-video').addEventListener('click', function () {
    var volume = document.getElementById('volume-video').value;
    player.setVolume(volume);
}, false);

document.getElementById('playbeck-quality').addEventListener('change', function (event) {    
    var quality = event.target.value;
    player.setPlaybackQuality(quality);
    console.log(quality);
}, false);


document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;

    player.cueVideoById(video, 0, "large");
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');

    player.cuePlaylist(videoPlaylist, 0, 0, "large");
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);