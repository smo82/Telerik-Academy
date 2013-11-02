/// <reference path="Libs/jquery-2.0.2.js" />
/// <reference path="Libs/class.js" />
/// <reference path="persister.js" />

var controller = (function () {
    var rootUrl = "http://localhost:22954/api/";

    var Controller = Class.create({
        init: function (selector) {
            this.selector = selector;
            this.persister = new persister.get(rootUrl);
            this.updater = null;
            this.interval = 5000;
            this.rows = 9;
            this.cols = 9;
            this.updateTooltip = false;
        },
        start: function () {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI();
            }
            else {
                this.loadLoginUI();
            }

            this.attachEventHandlers();
        },
        attachEventHandlers: function () {
            var self = this;
            var wrapper = $(this.selector);

            $("body").on("click", function () {
                $.noty.closeAll();
            });

            wrapper.on("click", "#login-form #btn-login", function () {
                var username = $("#tb-login-username").val();
                var password = $("#tb-login-password").val();
                var user = {
                    username: username,
                    password: password
                };

                self.persister.user.login(user, function () {
                    self.loadGameUI();
                    $("#login-form").find("p.error").remove();
                }, function (message) {
                    noty({ type: 'error', text: message });
                });

                return false;
            });

            wrapper.on("click", "#login-form #btn-register-form", function () {
                self.loadRegisterUI();
                return false;
            });

            wrapper.on("click", "#register-form #btn-register", function () {
                var username = $("#tb-reg-username").val();
                var nickname = $("#tb-reg-nickname").val();
                var password = $("#tb-reg-password").val();
                var user = {
                    username: username,
                    nickname: nickname,
                    password: password
                };

                self.persister.user.register(user, function () {
                    self.loadGameUI();
                    $("#register-form").find("p.error").remove();
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
                return false;
            });

            wrapper.on("click", "#register-form #btn-login-form", function () {
                self.loadLoginUI();
                return false;
            });

            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginUI();
                    clearInterval(self.updater);
                    $("#profile").find("p.error").remove();
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
                
                return false;
            });

            wrapper.on("click", "#opengames-list li", function () {
                $("#join-game-form").modal("show");
                $("#join-game-form").attr("data-game-id", $(this).attr("data-game-id"));
                return false;
            });

            wrapper.on("click", "#btn-create-game-form", function () {
                $("#create-game-form").modal("show");
            });

            wrapper.on("click", "#btn-create", function () {
                var title = $("#tb-create-title").val();
                var password = $("#tb-create-password").val();

                var game = {
                    title: title,
                };

                if (password) {
                    game.password = password;
                }

                self.persister.game.create(game, function () {
                    $("#create-game-form").modal("hide");
                    $("#create-game-form").find("p.error").remove();
                    self.loadOpenGames();
                    self.loadActiveGames();
                }, function (message) {
                    $("#create-game-form").modal("hide");
                    noty({ type: 'error', text: message });
                });

                return false;
            });

            wrapper.on("click", "#btn-scores", function () {
                self.persister.user.scores(function (scores) {
                    scores.sort(function (a, b) {
                        return -(a.score - b.score);
                    });

                    var list = $("#scores-list tbody");
                    list.empty();
                    for (var i = 0; i < scores.length; i++) {
                        list.append("<tr>" +
                            "<td>" + (i + 1) + "</td>" +
                            "<td>" + scores[i].nickname + "</td>" +
                            "<td>" + scores[i].score + "</td>" +
                            "</tr>");
                    }
                    $("#scores-form").modal("show");
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
            });

            wrapper.on("click", "#btn-join", function () {
                var password = $("#tb-join-password").val();
                var gameId = $("#join-game-form").attr("data-game-id");

                var game = {
                    id: gameId
                }

                if (password) {
                    game.password = password;
                }

                self.persister.game.join(game, function () {
                    $("#join-game-form").modal("hide");
                    self.loadOpenGames();
                    self.loadActiveGames();
                }, function (message) {
                    $("#join-game-form").modal("hide");
                    noty({ type: 'error', text: message });
                });

                return false;
            });

            wrapper.on("click", "#activegames-list .full-game", function () {
                $("#start-game-form").modal("show");
                $("#start-game-form").attr("data-game-id", $(this).attr("data-game-id"));
                return false;
            });

            wrapper.on("click", "#btn-start", function () {
                var gameId = $("#start-game-form").attr("data-game-id");

                self.persister.game.start(gameId, function () {
                    $("#start-game-form").modal("hide");
                    $("#start-game-form").find("p.error").remove();
                    self.loadActiveGames();
                }, function (message) {
                    $("#start-game-form").modal("hide");
                    noty({ type: 'error', text: message });
                });

                return false;
            });

            wrapper.on("click", "#activegames-list li:not(.full-game, .open-game)", function () {
                $("#game-name").text(" ➭ " + $(this).find("a").text());
                var gameId = $(this).attr("data-game-id");
                self.showGameField(gameId);

                return false;
            });

            wrapper.on("click", "#game-field td", function () {
                if ($(this).attr("data-selectable") == "true") {
                    $("#game-field table td").removeClass("selected");
                    $(this).addClass("selected");
                }

                return false;
            });

            wrapper.on("contextmenu", "#game-field td", function (ev) {
                ev.preventDefault();
                $("#game-field table td").removeClass("next");
                $(this).addClass("next");

                return false;
            });

            wrapper.on("click", "#btn-move", function () {
                var unitId = $("#game-field td.selected").attr("data-unit-id");
                var next = $("#game-field td.next");
                var gameId = $("#game-field table").attr("data-game-id");
                var x = next.parent().children().index($(next));
                var y = next.parent().parent().children().index($(next).parent());
                var moveData = {
                    unitId: unitId,
                    position: {
                        x: x,
                        y: y
                    }
                }

                self.persister.battle.move(gameId, moveData, function () {
                    self.showGameField(gameId);
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
            });

            wrapper.on("click", "#btn-attack", function () {
                var unitId = $("#game-field td.selected").attr("data-unit-id");
                var next = $("#game-field td.next");
                var gameId = $("#game-field table").attr("data-game-id");
                var x = next.parent().children().index($(next));
                var y = next.parent().parent().children().index($(next).parent());
                var moveData = {
                    unitId: unitId,
                    position: {
                        x: x,
                        y: y
                    }
                }

                self.persister.battle.attack(gameId, moveData, function () {
                    self.showGameField(gameId);
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
            });

            wrapper.on("click", "#btn-defend", function () {
                var unitId = $("#game-field td.selected").attr("data-unit-id");
                var gameId = $("#game-field table").attr("data-game-id");

                self.persister.battle.defend(gameId, unitId, function () {
                    self.showGameField(gameId);
                }, function (message) {
                    noty({ type: 'error', text: message });
                });
            });
        },
        loadLoginUI: function () {
            $(this.selector).load("login.html", function () { });
        },
        loadRegisterUI: function () {
            $(this.selector).load("register.html", function () { });
        },
        loadGameUI: function () {
            var self = this;
            $(this.selector).load("game.html", function () {
                $("#sp-profile-nickname").text(self.persister.nickname());
                self.loadOpenGames();
                self.loadActiveGames();
                self.loadAllMessages();
                self.loadGameField();
                self.startUpdater();
                $("#how-to-play").tooltipster();
                $("#accordion").accordion();
            });
        },
        loadGameField: function () {
            $("#game-field").children().hide();
            $("#game-field").append("<h1>Welcome to BattleGame.</h1><p id='copyright'>WebClient by <b>SVGN</b></p>");
        },
        showGameField: function (gameId) {
            $("#game-field").children("h1, #copyright").remove();
            $("#game-field table").remove();
            
            var table = $("<table/>");
            var row, i, j;
            for (i = 0; i < this.rows; i++) {
                row = $("<tr/>");
                for (j = 0; j < this.cols; j++) {
                    row.append("<td data-selectable='false'></td>")
                }
                table.append(row);
            }

            $("#game-field #game-buttons").after(table);
            $("#game-field table td").attr("data-selectable", "false");
            $("#game-field").children().show();

            var self = this;
            this.persister.game.field(gameId, function(gameInfo) {
                $("#game-turn").text(gameInfo.turn);
                if (gameInfo.inTurn == "red") {
                    $("#inturn-nickname").text(gameInfo.red.nickname);
                    $("#inturn-nickname").css("color", "red");
                }
                else {
                    $("#inturn-nickname").text(gameInfo.blue.nickname);
                    $("#inturn-nickname").css("color", "blue");
                }

                $("#game-field table").attr("data-game-id", gameId);

                var cell, unit, i, tooltip;
                for (i = 0; i < gameInfo.red.units.length; i++) {
                    unit = gameInfo.red.units[i];
                    tooltip =
                        "Attack: " + unit.attack + "<br />" +
                        "Armor: " + unit.armor + "<br />" +
                        "HitPoints: " + unit.hitPoints + "<br />";

                    cell = self.getCellByXY(unit.position.y, unit.position.x);
                    cell.attr("data-unit-id", unit.id);
                    cell.attr("data-selectable", "true");
                    if (unit.type == "warrior") {
                        cell.addClass("red-warrior");
                        tooltip = "Warrior<br />" + tooltip;
                        tooltip +=
                            "Range: 1<br />" +
                            "Speed: 2";
                    }
                    else {
                        cell.addClass("red-ranger");
                        tooltip = "Ranger<br />" + tooltip;
                        tooltip +=
                            "Range: 3<br />" +
                            "Speed: 1";
                    }

                    cell.attr("title", tooltip);
                }

                for (i = 0; i < gameInfo.blue.units.length; i++) {
                    unit = gameInfo.blue.units[i];
                    tooltip =
                        "Attack: " + unit.attack + "<br />" +
                        "Armor: " + unit.armor + "<br />" +
                        "HitPoints: " + unit.hitPoints + "<br />";

                    cell = self.getCellByXY(unit.position.y, unit.position.x);
                    cell.attr("data-unit-id", unit.id);
                    cell.attr("data-selectable", "true");
                    if (unit.type == "warrior") {
                        cell.addClass("blue-warrior");
                        tooltip = "Warrior<br />" + tooltip;
                        tooltip +=
                            "Range: 1<br />" +
                            "Speed: 2";
                    }
                    else {
                        cell.addClass("blue-ranger");
                        tooltip = "Ranger<br />" + tooltip;
                        tooltip +=
                            "Range: 3<br />" +
                            "Speed: 1";
                    }

                    cell.attr("title", tooltip);
                }

                    self.updateTooltip = true;
                    $("#game-field td[data-selectable='true']").tooltipster({
                        position: 'top',
                        theme: '.tooltipster-light',
                        trigger: 'hover',
                    });
                    $("#game-field table td[data-selectable='true']").removeAttr("title");
            }, function (message) {
                noty({ type: 'error', text: message });
            });
        },
        getCellByXY: function (rowIndex, colIndex) {
            var cell = $("#game-field table").first().find('tr').eq(rowIndex).find('td').eq(colIndex);
            return $(cell);
        },
        startUpdater: function () {
            var self = this;
            this.updater = setInterval(function () {
                self.loadOpenGames();
                self.loadActiveGames();
                self.updateMessages();
            }, this.interval)
        },
        loadOpenGames: function () {
            this.persister.game.open(function (games) {
                var list = $("#opengames-list");
                list.empty();
                for (var i = 0; i < games.length; i++) {
                    list.append("<li data-game-id='" + games[i].id + "'>" +
                        "<span class='label label-info'>Open</span>" +
                        "<a href='#'>" + $("<div/>").html(games[i].title).text() + "</a>" +
                        "<span> by " + games[i].creator + "</span>" +
                        "</li>");
                }
            }, function (message) {
                noty({ type: 'error', text: message });
            });
        },
        loadActiveGames: function () {
            this.persister.game.myactive(function (games) {
                var active = $("#activegames-list");
                active.empty();

                for (var i = 0; i < games.length; i++) {
                    if (games[i].status == "full") {
                        active.append("<li class='full-game' data-game-id='" + games[i].id + "'>" +
                        "<span class='label label-warning'>Full</span>" +
                        "<a href='#'>" + $("<div/>").html(games[i].title).text() + "</a>" +
                        "<span> by " + games[i].creator + "</span>" +
                        "</li>");
                    } else if (games[i].status == "open") {
                        active.append("<li class='open-game' data-game-id='" + games[i].id + "'>" +
                        "<span class='label label-info'>Open</span>" +
                        "<a href='#'>" + $("<div/>").html(games[i].title).text() + "</a>" +
                        "<span> by " + games[i].creator + "</span>" +
                        "</li>");
                    } else {
                        active.append("<li data-game-id='" + games[i].id + "'>" +
                        "<span class='label label-important'>Ready</span>" +
                        "<a href='#'>" + $("<div/>").html(games[i].title).text() + "</a>" +
                        "<span> by " + games[i].creator + "</span>" +
                        "</li>");
                    }
                }
            }, function (message) {
                noty({ type: 'error', text: message });
            });
        },
        loadAllMessages: function () {
            var self = this;
            this.persister.messages.all(function (messages) {
                var list = $("#messages-list");
                list.empty();
                for (var i = 0; i < messages.length; i++) {
                    var escapedMessage = $("<div/>").html(messages[i].text).text();
                    if (messages[i].type == "game-started") {
                        self.addMessage(escapedMessage, "info", "New");
                    }
                    else if (messages[i].type == "game-joined") {
                        self.addMessage(escapedMessage, "warning", "Join");
                    }
                    else if (messages[i].type == "game-finished") {
                        self.addMessage(escapedMessage, "success", "Finish");
                    }
                    else {
                        self.addMessage(escapedMessage, "important", "Move");
                    }
                }
            }, function (message) {
                noty({ type: 'error', text: message });
            });
        },
        updateMessages: function () {
            var self = this;
            this.persister.messages.unread(function (messages) {
                for (var i = 0; i < messages.length; i++) {
                    var escapedMessage = $("<div/>").html(messages[i].text).text();
                    if (messages[i].type == "game-started") {
                        self.addMessage(escapedMessage, "info", "Info");
                    }
                    else if (messages[i].type == "game-joined") {
                        self.addMessage(escapedMessage, "warning", "Join");
                    }
                    else if (messages[i].type == "game-finished") {
                        self.addMessage(escapedMessage, "success", "End");
                    }
                    else {
                        self.addMessage(escapedMessage, "important", "Move");
                        self.showGameField(messages[i].gameId);
                    }
                }
            }, function (message) {
                noty({ type: 'error', text: message });
            });
        },
        addMessage: function (message, type, label) {
            var list = $("#messages-list");
            var html = "<li><span class='label label-" + type + "'>" + label + " </span><span>" + message + "</span></li>";
            list.prepend(html);
        },
    });

    return {
        get: function (selector) {
            return new Controller(selector);
        }
    }
})();

$(function () {
    var game = controller.get("#wrapper");
    game.start();
});