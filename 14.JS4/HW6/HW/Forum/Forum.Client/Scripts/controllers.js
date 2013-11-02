/// <reference path="class.js" />
/// <reference path="data-layer.js" />
/// <reference path="ui-controls.js" />
/// <reference path="q.js" />

define(["classDef", "ui", "jquery", "q"], function (Class, UI, $, Q) {
    var Controllers = Controllers || {};

    Controllers = (function () {
        var ForumController = Class.create({
            init: function (dataPersister, mainContainerSelector, tagsContainerSelector) {
                this.dataPersister = dataPersister;
                this.mainContainerSelector = mainContainerSelector;
                this.tagsContainerSelector = tagsContainerSelector;
                this.mainForumControl = null;

            },

            displayMainView: function () {
                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                this.mainForumControl = new UI.MainForumControl();
                var mainForumControlPromis = this.mainForumControl.build(this.mainContainerSelector);

                return mainForumControlPromis;
            },

            displayForumPosts: function () {
                var self = this;

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                this.dataPersister.posts.getAll().then(function (data) {
                    var postListControl = new UI.PostListControl(self.mainContainerSelector, data);
                });
            },

            displayForumPostsWithTags: function (tags) {
                var self = this;

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                this.dataPersister.posts.getWithTags(tags).then(function (data) {
                    var postListControl = new UI.PostListControl(self.mainContainerSelector, data);
                });
            },

            displayForumPostById: function (id) {
                var self = this;

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                this.dataPersister.posts.getById(id).then(function (data) {
                    var postListControl = new UI.PostDisplayControl(self.mainContainerSelector, data);
                });
            },
            
            displayPostCommentForm: function (id) {
                var self = this;

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                this.dataPersister.posts.getById(id).then(function (data) {
                    var postListControl = new UI.PostCommentControl(self.mainContainerSelector, id, data);

                    postListControl.attachPostCommentClickHandler(function (postData) {
                        self.dataPersister.posts.comment(postData.postId, postData.commentText).then(function () {
                            window.location.replace("#/post/" + postData.postId);
                        });
                    }, true);
                });
            },

            displaySearchByTagsForm: function (id) {
                var self = this;

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                var searchByTagsControl = new UI.SearchByTagsControl(self.mainContainerSelector);

                searchByTagsControl.attachSearchByTagsClickHandler(function (searchData) {
                    window.location.replace("#/posts/" + searchData.tagsConstraint);
                }, true);
            },

            displayTags: function () {
                var self = this;

                var tagsContainer = $(this.tagsContainerSelector);
                tagsContainer.html("");

                this.dataPersister.tags.getAll().then(function (data) {
                    var tagsListControl = new UI.TagsListControl(self.tagsContainerSelector, data);
                });
            },
        });

        var AccessController = Class.create({
            init: function (dataPersister, mainContainerSelector) {
                this.dataPersister = dataPersister;

                this.mainContainerSelector = mainContainerSelector;
                this.loginControl = null;
                this.registerControl = null;
            },

            isUserLoggedIn: function () {
                return this.dataPersister.isUserLoggedIn();
            },

            getUserData: function () {
                return dataPersister.getUserData();
            },

            loginUser: function () {
                var loginDeferred = Q.defer();

                this.handleLoginProcedure(loginDeferred);

                return loginDeferred.promise;
            },

            logoutUser: function () {
                this.dataPersister.user.logout();
            },

            handleLoginProcedure: function (deferred) {
                var self = this;

                self.loginControl = new UI.LoginControl();

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                self.loginControl.build(this.mainContainerSelector).then(function () {
                    self.loginControl.attachLoginClickHandler(function (loginData) {
                        self.dataPersister.user.login(loginData.username, loginData.password).then(function () {
                            deferred.resolve();
                        },
                        function (error) {
                            self.loginControl.reportError(error.responseText);
                        })
                    }, true);

                    mainContainer.append("<a href='#' id='go-to-register'>Register</a>");
                    $("#go-to-register").on("click", function () {
                        self.handleRegisterProcedure(deferred);
                        return false;
                    })
                }).done();

            },

            handleRegisterProcedure: function (deferred) {
                var self = this;

                self.registerControl = new UI.RegisterControl();

                var mainContainer = $(this.mainContainerSelector);
                mainContainer.html("");

                self.registerControl.build(this.mainContainerSelector).then(function () {
                    self.registerControl.attachRegisterClickHandler(function (registerData) {
                        self.dataPersister.user.register(registerData.username, registerData.nickname, registerData.password).then(function () {
                            deferred.resolve();
                        }, function (error) {
                            self.registerControl.reportError(error.responseText);
                        });
                    }, true);

                    mainContainer.append("<a href='#' id='go-to-login'>Login</a>");
                    $("#go-to-login").on("click", function () {
                        self.handleLoginProcedure(deferred);
                        return false;
                    })
                }).done();
            }

        });
        
        return {
            getAccessController: function (dataPersister, mainContainerSelector) { return new AccessController(dataPersister, mainContainerSelector); },
            getForumController: function (dataPersister, mainContainerSelector, tagsContainerSelector) { return new ForumController(dataPersister, mainContainerSelector, tagsContainerSelector); },
        }
    }());

    return Controllers;
});