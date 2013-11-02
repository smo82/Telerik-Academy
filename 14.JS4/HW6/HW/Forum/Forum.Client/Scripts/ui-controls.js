/// <reference path="q.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="http-requester.js" />
/// <reference path="class.js" />

define(["classDef", "jquery", "q", "httpRequester", "mustache"], function (Class, $, Q, HttpRequester, Mustache) {
    var UI = UI || {}

    UI = (function () {
        var buildControlPromise = function (controlHtmlUrl, rootElement) {
            var buildDeferred = Q.defer();

            HttpRequester.getJson(controlHtmlUrl).then(function (partialHtml) {
                var container = $("<div class='control-container'>" + partialHtml + "</div>");
                $(rootElement).append(container);
                rootElement = container;

                buildDeferred.resolve(rootElement);
            }, function (error) {
                buildDeferred.reject(error);
            });

            return buildDeferred.promise;
        }

        var LoginControl = Class.create({
            build: function (selector) {
                var self = this;
                self.rootElement = $(selector);

                return buildControlPromise("../login-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;
                });
            },

            getUsernameText: function () {
                return $("#login-username-input").val();
            },

            getPasswordText: function () {
                return $("#login-password-input").val();
            },

            attachLoginClickHandler: function (handler, removePreviousHandlers) {

                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                this.rootElement.on("click", "#login-button", function () {
                    var loginData = {
                        username: self.getUsernameText(),
                        password: self.getPasswordText()
                    };

                    handler(loginData);
                });
            },

            reportError: function (errorMessage) {
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);

                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            }
        });

        var RegisterControl = Class.create({
            build: function (selector) {
                var self = this;
                self.rootElement = $(selector);

                return buildControlPromise("../register-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;
                });
            },

            getUsernameText: function () {
                return $("#register-username-input").val();
            },

            getPasswordText: function () {
                return $("#register-password-input").val();
            },

            getNicknameText: function () {
                return $("#register-nickname-input").val();
            },

            attachRegisterClickHandler: function (handler, removePreviousHandlers) {
                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#register-button", function () {
                    var registerData = {
                        username: self.getUsernameText(),
                        nickname: self.getNicknameText(),
                        password: self.getPasswordText()
                    };

                    handler(registerData);
                });
            },

            reportError: function (errorMessage) {
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);


                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            }
        });

        var ListControl = Class.create({
            build: function (selector, header, data, dataDisplayPropertyName) {

                var self = this;
                self.rootElement = $(selector);
                self.listElements = new Array();

                return buildControlPromise("../list-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;

                    self.header = self.rootElement.children("h2.control-header"),
                    self.listContainer = self.rootElement.children("ul.control-data-container");

                    self.header.text(header);

                    self.changeData(data, dataDisplayPropertyName);
                });
            },

            changeData: function (newData, dataDisplayPropertyName) {
                this.listContainer.html("");

                if (newData) {
                    for (var i in newData) {
                        var listElement = $("<li>" + newData[i][dataDisplayPropertyName] + "</li>");

                        this.listContainer.append(listElement);

                        this.listElements.push(listElement);
                    }
                }
            },

            attachItemClickHandler: function (handler, removePreviousHandlers) {
                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                self.rootElement.on("click", "li", function (event) {
                    var itemData = {
                        itemIndex: $(this).index(),
                        item: $(this)
                    }
                    handler(itemData);
                })
            }
        });

        var CreateGameControl = Class.create({
            build: function (selector) {
                var self = this;
                self.rootElement = $(selector);

                return buildControlPromise("../create-game-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;
                });
            },

            getTitleText: function () {
                return $("#create-game-title-input").val();
            },

            getPasswordText: function () {
                return $("#create-game-password-input").val();
            },

            attachCreateClickHandler: function (handler, removePreviousHandlers) {

                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#create-game-button", function () {
                    var gameCreateData = {
                        title: self.getTitleText(),
                        password: self.getPasswordText()
                    };

                    handler(gameCreateData);
                });
            },

            reportSuccess: function (message) {
                var messageObject = { "Message": message };

                var template = "<p class='success-message' style='color:green'> {{Message}} </p>";
                var outputSuccessMessage = Mustache.render(template, messageObject);

                this.rootElement.append(outputSuccessMessage);
                successMessage.fadeOut(2000, function () {
                    successMessage.remove();
                });
            },

            reportError: function (errorMessage) {
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);

                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            },

            clearErrorReport: function () {
                var errorMessages = this.rootElement.children(".error-message");
                errorMessages.fadeOut(200, function () {
                    errorMessages.remove();
                });
            },

            clearControle: function () {
                $("#create-game-title-input").val("");
                $("#create-game-number-input").val("");
                $("#create-game-password-input").val("");
            }

        });

        /*********************************************/
        /*To delete!!*/
        var MakeGuessControl = Class.create({
            build: function (selector) {

                var self = this;
                self.rootElement = $(selector);

                return buildControlPromise("../make-guess-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;
                });
            },

            getNumberText: function () {
                return $("#guess-number-input").val();
            },

            attachGuessClickHandler: function (handler, removePreviousHandlers) {

                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#make-guess-button", function () {
                    var makeGuessData = {
                        number: parseInt(self.getNumberText())
                    };

                    handler(makeGuessData);
                });
            },

            show: function () {
                this.rootElement.show();
            },

            hide: function () {
                this.rootElement.hide();
            },

            reportError: function (errorMessage) {
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);

                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            },

            clearErrorReport: function () {
                this.rootElement.children(".error-message").remove();
            }
        });

        var JoinGameControl = Class.create({
            buildAfterContent: function (listItem) {
                var container = $("<div class='control-container'></div>");
                this.rootElement = container;
                $(listItem).append(container);

                return HttpRequester.getJson("../join-game-control.html").then(function (joinHtml) {
                    container.append(joinHtml);
                });
            },

            getRoot: function () {
                return this.rootElement;
            },

            deleteFromDom: function () {
                $("#game-login-container").parent().remove();
            },

            getPasswordText: function () {
                return $("#game-login-password-input").val();
            },

            attachJoinClickHandler: function (handler, removePreviousHandlers) {

                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#game-login-button", function () {
                    var gameLoginData = {
                        password: self.getPasswordText()
                    };

                    handler(gameLoginData);
                    return false;
                });
            },

            reportError: function (errorMessage) {
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);

                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            },

            clearErrorReport: function () {
                this.rootElement.children(".error-message").remove();
            }
        });

        var GridViewControl = Class.create({
            build: function (selector, mainHeader, headers, dataMatrix) {
                var container = $("<div class='control-container'></div>");
                $(selector).append(container);
                this.rootElement = container;

                this.mainHeader = mainHeader;
                this.headers = headers;

                this.changeData(dataMatrix);
            },

            changeData: function (data) {
                var resultHtml = "<h2>" + this.mainHeader + "</h2><table>";

                resultHtml += "<thead>";
                resultHtml += "<tr>";
                for (var i in this.headers) {
                    resultHtml += "<th>" + this.headers[i] + "</th>";
                }
                resultHtml += "</tr>";
                resultHtml += "</thead>";

                resultHtml += "<tbody>";
                for (var row in data) {
                    var currRow = data[row];
                    resultHtml += "<tr>";
                    for (var col in currRow) {
                        resultHtml += "<td>" + currRow[col] + "</td>";
                    }
                    resultHtml += "</tr>";
                }
                resultHtml += "</tbody>";
                resultHtml += "</table>";

                this.rootElement.html(resultHtml);
            }
        });

        var BattleGameGridElementControl = Class.create({
            build: function (selector, x, y, data) {
                var container = $("<div class='control-container battle-game-grid-element-container' id='" + id + "'></div>");
                $(selector).append(container);
                var id = "gridCellElement-" + x + "-" + y;
                container.attr("id", id);
                this.id = id;
                this.rootElement = container;
                this.unit = {};

                this.x = x;
                this.y = y;
            },

            changeData: function (data) {
                // Remove all classes that start with "owner_"
                this.rootElement[0].className = this.rootElement[0].className.replace(/\bowner_.*?\b/g, '');
                if (!jQuery.isEmptyObject(data)) {
                    this.unit = data;

                    var type = "";

                    if (data.type == "warrior") {
                        type = "W";
                    } else if (data.type == "ranger") {
                        type = "V";
                    }

                    var resultHtml = "<h2>" + type + "</h2>";


                    this.rootElement.html(resultHtml);

                    this.rootElement.addClass("owner_" + data.owner);
                } else {
                    this.unit = {};
                    this.rootElement.html("");
                }
            },

            markAsSelected: function () {
                this.rootElement.addClass("selected");
            },

            markAsUnSelected: function () {
                this.rootElement.removeClass('selected');
            },
        });

        var BattleGameGridViewControl = Class.create({
            build: function (selector, mainHeader, headers, height, width, dataMatrix) {
                var container = $("<div class='control-container'></div>");
                $(selector).append(container);
                this.rootElement = container;

                this.mainHeader = mainHeader;
                this.headers = headers;
                this.height = height;
                this.width = width;

                this.gridElements;

                this.initGameGrid();
                this.initGameGridElements(dataMatrix);
                this.changeData(dataMatrix);
            },

            initGameGrid: function () {
                var resultHtml = "<h2>" + this.mainHeader + "</h2><table>";

                resultHtml += "<thead>";
                resultHtml += "<tr>";
                for (var i in this.headers) {
                    resultHtml += "<th>" + this.headers[i] + "</th>";
                }
                resultHtml += "</tr>";
                resultHtml += "</thead>";

                resultHtml += "<tbody>";
                for (var i = 0; i < this.height; i++) {
                    resultHtml += "<tr>";
                    for (var j = 0; j < this.width; j++) {
                        resultHtml += "<td id='gridCell-" + i + "-" + j + "'></td>";
                    }
                    resultHtml += "</tr>";
                }

                resultHtml += "</tbody>";
                resultHtml += "</table>";

                this.rootElement.html(resultHtml);
            },

            initGameGridElements: function () {
                this.gridElements = new Array(this.height);
                for (var i = 0; i < this.height; i++) {
                    this.gridElements[i] = new Array(this.width);
                }

                for (var i = 0; i < this.height; i++) {
                    for (var j = 0; j < this.width; j++) {
                        this.gridElements[i][j] = new BattleGameGridElementControl();
                        this.gridElements[i][j].build("#gridCell-" + i + "-" + j, i, j, {})
                    }
                }
            },

            changeData: function (dataMatrix) {
                if (dataMatrix.length > 0) {
                    for (var i = 0; i < this.height; i++) {
                        for (var j = 0; j < this.width; j++) {
                            this.gridElements[i][j].changeData(dataMatrix[i][j]);
                        }
                    }
                }
            },

            attachBattleGridElementClickHandler: function (handler, removePreviousHandlers) {
                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", ".battle-game-grid-element-container", function (event) {
                    var clickedElement = $(event.target);
                    if (!(clickedElement).is('div')) {
                        clickedElement = clickedElement.parent();
                    }

                    var clickedElementId = clickedElement.attr("id");

                    var clickedElement;
                    var currentElement;
                    for (var i = 0; i < self.height; i++) {
                        for (var j = 0; j < self.width; j++) {
                            currentElement = self.gridElements[i][j];
                            if ((!jQuery.isEmptyObject(currentElement)) && (currentElement.id == clickedElementId)) {
                                clickedElement = currentElement;
                            }
                        }
                    }

                    var data = {
                        clickedElement: clickedElement,
                        clickedElementId: clickedElementId
                    };

                    handler(data);
                    return false;
                });
            },

            clearErrorReport: function () {
                this.rootElement.children(".error-message").remove();
            },

            reportError: function (errorMessage) {
                debugger;
                var errorMessageAsObject = jQuery.parseJSON(errorMessage);

                var template = "<p class='error-message' style='color:red'> {{Message}} </p>";
                var outputErrorMessage = Mustache.render(template, errorMessageAsObject);

                this.rootElement.append(outputErrorMessage);
            }
        });



        var MainForumControl = Class.create({
            build: function (selector) {
                var self = this;
                self.rootElement = $(selector);

                return buildControlPromise("../main-forum-control.html", this.rootElement).then(function (newRootElement) {
                    self.rootElement = newRootElement;
                });
            }
        });

        var PostListControl = Class.create({
            init: function (selector, data) {
                var self = this;
                self.rootElement = $(selector);

                this.build(data);
            },

            build: function (data) {
                var dataAsObject = { "data": data };
                var template = "<ul>{{#data}}<li><a href='#/post/{{id}}/comment'> {{id}} : {{title}} - {{text}} </a></li>{{/data}}</ul>";
                var postList = Mustache.render(template, dataAsObject);
                this.rootElement.html(postList);
            }
        });

        var PostDisplayControl = Class.create({
            init: function (selector, data) {
                var self = this;
                self.rootElement = $(selector);

                this.build(data);
            },

            build: function (data) {
                var dataAsObject = { "data": data };
                var template =
                    "<ul>{{#data}}" +
                        "<li>id :{{id}}</li>" +
                        "<li>title : {{title}}</li>" +
                        "<li>Comments:<ul>{{#comments}}<li>{{text}}</li>{{/comments}}</ul></li>" +
                        "<li>Tags:<ul>{{#tags}}<li>{{.}}</li>{{/tags}}</ul></li>" +
                    "{{/data}}</ul>";
                var postList = Mustache.render(template, dataAsObject);
                this.rootElement.html(postList);
            }
        });

        var PostCommentControl = Class.create({
            init: function (selector, id, data) {
                var self = this;
                self.rootElement = $(selector);
                self.postId = id;

                this.build(data);
            },

            build: function (data) {
                var dataAsObject = { "data": data };
                var template =
                    "<ul>{{#data}}" +
                        "<li>id :{{id}}</li>" +
                        "<li>title : {{title}}</li>" +
                        "<li>Comments:<ul>{{#comments}}<li>{{text}}</li>{{/comments}}</ul></li>" +
                        "<li>Tags:<ul>{{#tags}}<li>{{.}}</li>{{/tags}}</ul></li>" +
                    "{{/data}}</ul>" + 
                    "<br />" + 
                    "<textarea id='commentText'></textarea>" +
                    "<br />" +
                    "<input id='commentButton' type='submit' value='Post Comment'>";
                var postList = Mustache.render(template, dataAsObject);
                this.rootElement.html(postList);
            },
            
            getCommentText: function () {
                return $("#commentText").val();
            },

            attachPostCommentClickHandler: function (handler, removePreviousHandlers) {
                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#commentButton", function (event) {
                    var clickedElement = $(event.target);
                    event.preventDefault()

                    var data = {
                        clickedElement: clickedElement,
                        postId: self.postId,
                        commentText: self.getCommentText()
                    };

                    handler(data);
                    return false;
                });
            },
        });

        var SearchByTagsControl = Class.create({
            init: function (selector) {
                var self = this;
                self.rootElement = $(selector);

                this.build();
            },

            build: function () {
                var template =
                    "<h1>Search a post by tags</h1>" +
                    "<br />" +
                    "<span>Please enter the tags separated by commas:</span>" +
                    "<br />" +
                    "<textarea id='tagsSearchConstraint'></textarea>" +
                    "<br />" +
                    "<input id='searchButton' type='submit' value='Search'>";
                this.rootElement.html(template);
            },

            getTagsSearchConstraint: function () {
                return $("#tagsSearchConstraint").val();
            },

            attachSearchByTagsClickHandler: function (handler, removePreviousHandlers) {
                var self = this;

                if (removePreviousHandlers) {
                    $(this.rootElement).off("click");
                }

                $(this.rootElement).on("click", "#searchButton", function (event) {
                    var clickedElement = $(event.target);
                    event.preventDefault()

                    var data = {
                        clickedElement: clickedElement,
                        tagsConstraint: self.getTagsSearchConstraint()
                    };

                    handler(data);
                    return false;
                });
            },
        });

        var TagsListControl = Class.create({
            init: function (selector, data) {
                var self = this;
                self.rootElement = $(selector);

                this.build(data);
            },

            build: function (data) {
                var dataAsObject = { "data": data };
                var template =
                    "<h2>All tags:</h2>" +
                    "<ul>{{#data}}<li> {{id}} : {{name}} </li>{{/data}}</ul>";
                var tagsList = Mustache.render(template, dataAsObject);
                this.rootElement.html(tagsList);
            }
        });

        return {
            LoginControl: LoginControl,
            RegisterControl: RegisterControl,
            ListControl: ListControl,
            JoinGameControl: JoinGameControl,
            GuessControl: MakeGuessControl,
            CreateGameControl: CreateGameControl,
            GridViewControl: GridViewControl,
            BattleGameGridViewControl: BattleGameGridViewControl,

            MainForumControl: MainForumControl,
            PostListControl: PostListControl,
            PostDisplayControl: PostDisplayControl,
            PostCommentControl: PostCommentControl,
            SearchByTagsControl: SearchByTagsControl,
            TagsListControl: TagsListControl
        }
    }());

    return UI;
});