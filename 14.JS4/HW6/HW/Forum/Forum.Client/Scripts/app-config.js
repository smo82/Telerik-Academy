/// <reference path="libs/require.js" />


require.config({
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
    var localPersister = Data.getDataPersister("http://localhost:3094/api/");
    var accessController = Controllers.getAccessController(localPersister, "#main-container");
    var forumController = Controllers.getForumController(localPersister, "#main-container", "#tags-container");
    
    var homePage = function () {
        if (accessController.isUserLoggedIn()) {
            forumController.displayMainView();
            forumController.displayTags();
        }
        else {
            window.location.replace("#/login");
        }
    };

    var app = sammy("#main-container", function () {
        this.get("#/", function () {
            homePage();
        });

        this.get("#/home", function () {
            homePage();
        });

        this.get("#/login", function () {
            jQuery("#main-container").html("");
            accessController.loginUser().then(function () {
                jQuery("#main-container").html("");
                window.location.replace("#/");
                return false;
            }).done();
        });

        this.get("#/posts", function () {
            forumController.displayForumPosts();
        });

        this.get("#/posts/tags", function () {
            forumController.displaySearchByTagsForm();
        });

        this.get("#/posts/:tags", function () {
            forumController.displayForumPostsWithTags(this.params["tags"]);
        });

        this.get("#/post/:id", function () {
            forumController.displayForumPostById(this.params["id"]);
        });

        this.get("#/post/:id/comment", function () {
            forumController.displayPostCommentForm(this.params["id"]);
        });
    });

    app.run("#/");
});