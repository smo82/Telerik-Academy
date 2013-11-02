/// <reference path="Libs/class.js" />
/// <reference path="Libs/sha1.js" />
/// <reference path="http-requester.js" />

var persister = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(data) {
        localStorage.setItem("nickname", data.nickname);
        localStorage.setItem("sessionKey", data.sessionKey);
        nickname = data.nickname;
        sessionKey = data.sessionKey;
    }

    function removeUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = null;
        sessionKey = null;
    }

    var Main = Class.create({
        init: function (url) {
            if (url[url.length - 1] != "/") {
                url += "/"
            }

            this.rootUrl = url;
            this.game = new Game(this.rootUrl);
            this.battle = new Battle(this.rootUrl);
            this.messages = new Messages(this.rootUrl);
            this.user = new User(this.rootUrl);
        },
        isUserLoggedIn: function () {
            var n = nickname != "" && nickname != null && nickname != undefined;
            var sk = sessionKey != "" && sessionKey != null && sessionKey != undefined;
            return (n && sk) == true;
        },
        nickname: function() {
            return nickname;
        }
    });

    var Game = Class.create({
        init: function (url) {
            this.rootUrl = url + "game/";
        },
        create: function (game, success, error) {
            var url = this.rootUrl + "create/" + sessionKey;
            var gameData = {
                title: game.title,
            };

            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }

            httpRequester.post(url, gameData, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        join: function (game, success, error) {
            var url = this.rootUrl + "join/" + sessionKey;
            httpRequester.post(url, game, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        start: function (gameId, success, error) {
            var url = this.rootUrl + gameId + "/start/" + sessionKey;
            httpRequester.get(url, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        field: function (gameId, success, error) {
            var url = this.rootUrl + gameId + "/field/" + sessionKey;
            httpRequester.get(url, function (gameInfo) {
                success(gameInfo);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        open: function (success, error) {
            var url = this.rootUrl + "open/" + sessionKey;
            httpRequester.get(url, function (data) {
                success(data);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        myactive: function (success, error) {
            var url = this.rootUrl + "my-active/" + sessionKey;
            httpRequester.get(url, function (data) {
                success(data);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
    });

    var Battle = Class.create({
        init: function (url) {
            this.rootUrl = url + "battle/";
        },
        move: function (gameId, moveData, success, error) {
            var url = this.rootUrl + gameId + "/move/" + sessionKey;
            httpRequester.post(url, moveData, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        attack: function (gameId, attackData, success, error) {
            var url = this.rootUrl + gameId + "/attack/" + sessionKey;
            httpRequester.post(url, attackData, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        defend: function (gameId, unitId, success, error) {
            var url = this.rootUrl + gameId + "/defend/" + sessionKey;
            httpRequester.post(url, unitId, function () {
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        }
    });

    var Messages = Class.create({
        init: function (url) {
            this.rootUrl = url + "messages/";
        },
        unread: function (success, error) {
            var url = this.rootUrl + "unread/" + sessionKey;
            httpRequester.get(url, function (messages) {
                success(messages);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        all: function (success, error) {
            var url = this.rootUrl + "all/" + sessionKey;
            httpRequester.get(url, function (messages) {
                success(messages);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
    });

    var User = Class.create({
        init: function (url) {
            this.rootUrl = url + "user/";
        },
        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.post(url, userData, function (data) {
                saveUserData(data);
                success()
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.post(url, userData, function (data) {
                saveUserData(data);
                success()
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;
            httpRequester.get(url, function () {
                removeUserData();
                success();
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
        scores: function (success, error) {
            var url = this.rootUrl + "scores/" + sessionKey;
            httpRequester.get(url, function (scores) {
                success(scores);
            }, function (err) {
                error(err.responseJSON.Message);
            });
        },
    });

    return {
        get: function (url) {
            return new Main(url);
        }
    }
})();