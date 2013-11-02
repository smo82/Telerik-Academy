/// <reference path="libs/require.js" />


require.config({
    waitSeconds: 200,

    paths: {
        jquery: "Lib/jquery-2.0.2",
        q: "Lib/q",
        sha1: "Lib/cryptojs-sha1",
        classDef: "Lib/class",
        sha1: "Lib/cryptojs-sha1",
        sammy: "Lib/sammy-0.7.4",
        mustache: "Lib/mustache",

        httpRequester: "http-requester",
        dataLayer: "data-layer",
        ui: "ui-controls",
        controllers: "controllers",
    }
});

require(["controllers", "dataLayer", "jquery", "q", "sammy"], function (Controllers, Data, jQuery, Q, sammy) {
    var localPersister = Data.getDataPersister("http://localhost:22954/api/");
    var accessController = Controllers.getAccessController(localPersister, "#main-container");
    var gameController = Controllers.getGameController(localPersister, "#main-container");

    var app = sammy("#main-container", function () {
        this.get("#/", function () {
            if (accessController.isUserLoggedIn()) {
                window.location.replace("#/game");
            }
            else {
                window.location.replace("#/login");
            }
        });

        this.get("#/login", function () {
            jQuery("#main-container").html("");
            accessController.loginUser().then(function () {
                jQuery("#main-container").html("");
                window.location.replace("#/game");
                return false;
            }).done();
        });

        this.get("#/game", function () {
            if (!accessController.isUserLoggedIn()) {
                jQuery("#main-container").html("");
                window.location.replace("#/login");
                return;
            }

            jQuery("#main-container").append("<a href='#/' id='logout-button'>Logout</a>");

            jQuery("#logout-button").on("click", function () {
                jQuery("#main-container").html("");
                gameController.stopGame();
                accessController.logoutUser();
                window.location.replace("#/login");
                return false;
            });

            gameController.startGame();
        });
    });

    app.run("#/");
});