/// <reference path="class.js" />
/// <reference path="http-requester.js" />

define(["classDef", "jquery", "q", "httpRequester", "sha1"], function (Class, $, Q, HttpRequester, CryptoJS) {
    var Data = Data || {};

    Data = (function () {

        var DataPersister = Class.create({
            init: function (serviceRootUrl) {
                this.serviceRootUrl = serviceRootUrl;

                this.user = new UserPersister(serviceRootUrl + "users/");
                this.posts = new PostPersister(serviceRootUrl + "posts", this.user);
                this.tags = new TagsPersister(serviceRootUrl + "tags", this.user);
            },

            isUserLoggedIn: function () {
                return this.user.isUserLoggedIn();
            }
        });

        var PostPersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            getAll: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "?sessionKey=" + this.userPersister.getCurrentUserData().sessionKey);
            },

            getWithTags: function (tags) {
                return HttpRequester.getJson(this.serviceRootUrl + "?sessionKey=" + this.userPersister.getCurrentUserData().sessionKey + "&tags=" + tags);
            },

            getById: function (id) {
                return HttpRequester.getJson(this.serviceRootUrl + "?sessionKey=" + this.userPersister.getCurrentUserData().sessionKey + "&id=" + id);
            },

            comment: function (id, commentText) {
                return HttpRequester.putJson(this.serviceRootUrl + "?sessionKey=" + this.userPersister.getCurrentUserData().sessionKey + "&id=" + id, { "text": commentText });
            },
        });

        var TagsPersister = Class.create({
            init: function (serviceRootUrl, userPersister) {
                this.serviceRootUrl = serviceRootUrl;
                this.userPersister = userPersister;
            },

            getAll: function () {
                return HttpRequester.getJson(this.serviceRootUrl + "?sessionKey=" + this.userPersister.getCurrentUserData().sessionKey);
            },
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
                    displayName: nickname,
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

        return {
            getDataPersister: function (serviceRootUrl) { return new DataPersister(serviceRootUrl); }
        }
    }())

    return Data;
});