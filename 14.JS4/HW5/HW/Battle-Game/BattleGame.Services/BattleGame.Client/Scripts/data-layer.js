/// <reference path="class.js" />
/// <reference path="http-requester.js" />

define(["classDef", "jquery", "q", "httpRequester", "sha1"], function (Class, $, Q, HttpRequester, CryptoJS) {
    var Data = Data || {};

    Data = (function () {

        var DataPersister = Class.create({
            init: function (serviceRootUrl) {
                this.serviceRootUrl = serviceRootUrl;

                this.user = new UserPersister(serviceRootUrl + "user/");
                this.games = new GamePersister(serviceRootUrl + "game/", this.user);
                this.guesses = new GuessPersister(serviceRootUrl + "guess/", this.user);
                this.messages = new MessagePersister(serviceRootUrl + "messages/", this.user);
                this.battle = new BattlePersister(serviceRootUrl + "battle/", this.user);
            },

            isUserLoggedIn: function () {
                return this.user.isUserLoggedIn();
            }
        });

        var UserPersister = Class.create({
            init: function (serviceRootUrl) {
                this.serviceRootUrl = serviceRootUrl;
            },

            _getSessionKey: function () {
                return localStorage.getItem("sessionKey");
            },

            _getNickname: function () {
                return localStorage.getItem("nickname");
            },

            _getUsername: function () {
                return localStorage.getItem("username");
            },

            _setSessionKey: function (value) {
                localStorage.setItem("sessionKey", value);
            },

            _setNickname: function (value) {
                this.nickname = value;
                localStorage.setItem("nickname", value);
            },

            _setUsername: function (value) {
                this.username = value;
                localStorage.setItem("username", value);
            },

            _clearSessionKey: function () {
                localStorage.removeItem("sessionKey");
            },

            _clearNickname: function () {
                localStorage.removeItem("nickname");
            },

            _clearUsername: function () {
                localStorage.removeItem("username");
            },

            register: function (username, nickname, password) {
                var self = this;

                return HttpRequester.postJson(this.serviceRootUrl + "register", {
                    username: username,
                    nickname: nickname,
                    authCode: CryptoJS.SHA1(username + password).toString(),
                }).then(function (result) {
                    self._setSessionKey(result.sessionKey);
                    self._setNickname(result.nickname);
                    self._setUsername(username);
                });
            },

            login: function (username, password) {
                var self = this;

                return HttpRequester.postJson(this.serviceRootUrl + "login", {
                    username: username,
                    authCode: CryptoJS.SHA1(username + password).toString(),
                }).then(function (result) {
                    self._setSessionKey(result.sessionKey);
                    self._setNickname(result.nickname);
                    self._setUsername(username);
                });
            },

            logout: function () {
                var self = this;

                return HttpRequester.putJson(this.serviceRootUrl + "logout/" + this._getSessionKey(), null)
                    .then(function () {
                        self._clearSessionKey();
                        self._clearNickname();
                        self._clearUsername();
                    });
            },

            isUserLoggedIn: function () {
                return (this._getNickname() !== null);
            },

            getCurrentUserData: function () {
                return {
                    username: this._getUsername(),
                    nickname: this._getNickname(),
                    sessionKey: this._getSessionKey()
                }
            },

            getAllUserScores: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "scores/" + this._getSessionKey());
            }
        });

        var GamePersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            create: function (gameTitle, gamePassword) {
                var gameOptions = {
                    title: gameTitle
                }

                if (gamePassword) {
                    gameOptions.password = CryptoJS.SHA1(gamePassword).toString();
                }

                return HttpRequester.postJson(this.serviceRootUrl + "create/" + this.userPersister.getCurrentUserData().sessionKey, gameOptions)
            },

            join: function (gameId, gamePassword) {
                var joinOptions = {
                    id: gameId
                }

                if (gamePassword) {
                    gameOptions.password = CryptoJS.SHA1(gamePassword).toString();
                }

                return HttpRequester.postJson(this.serviceRootUrl + "join/" + this.userPersister.getCurrentUserData().sessionKey, joinOptions)
            },

            start: function (gameId) {
                debugger;
                return HttpRequester.putJson(this.serviceRootUrl + gameId + "/start/" + this.userPersister.getCurrentUserData().sessionKey, null);
            },

            getOpen: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "open/" + this.userPersister.getCurrentUserData().sessionKey);
            },

            getCurrentUserActive: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "my-active/" + this.userPersister.getCurrentUserData().sessionKey);
            },

            getField: function (gameId) {
                return HttpRequester.getJson(this.serviceRootUrl + gameId + "/field/" + this.userPersister.getCurrentUserData().sessionKey);
            }
        });

        var BattlePersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            move: function (gameId, unitId, positionX, positionY) {
                return HttpRequester.postJson(this.serviceRootUrl + gameId + "/move/" + this.userPersister.getCurrentUserData().sessionKey, {
                    unitId: unitId,
                    position: {
                        "x": positionX,
                        "y": positionY
                    }
                });
            },

            attack: function (gameId, unitId, positionX, positionY) {
                return HttpRequester.postJson(this.serviceRootUrl + gameId + "/attack/" + this.userPersister.getCurrentUserData().sessionKey, {
                    unitId: unitId,
                    position: {
                        "x": positionX,
                        "y": positionY
                    }
                });
            },

            degend: function (gameId, unitId) {
                return HttpRequester.postJson(this.serviceRootUrl + gameId + "/defend/" + this.userPersister.getCurrentUserData().sessionKey, unitId);
            },
        });

        var GuessPersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            make: function (guessNumber, gameId) {
                return HttpRequester.postJson(this.serviceRootUrl + "make/" + this.userPersister.getCurrentUserData().sessionKey, {
                    gameId: gameId,
                    number: guessNumber
                });
            }
        });

        var MessagePersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            getUserUnread: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "unread/" + this.userPersister.getCurrentUserData().sessionKey)
            },

            getUserAll: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "all/" + this.userPersister.getCurrentUserData().sessionKey)
            }
        });

        return {
            getDataPersister: function (serviceRootUrl) { return new DataPersister(serviceRootUrl); }
        }
    }())

    return Data;
});