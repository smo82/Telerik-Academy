window.persisters = (function () {
    var sessionKey = "";
    var mainUsername = "";
    function getJSON(requestUrl) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }
    function postJSON(requestUrl, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }
    function putJSON(requestUrl, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }
    var displayName = localStorage.getItem("displayName");
    sessionKey = localStorage.getItem("sessionKey");
    function saveUserData(userData) {
        localStorage.setItem("displayName", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        displayName = userData.displayName;
        sessionKey = userData.sessionKey;
    }
    function clearUserData() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
        displayName = null;
        sessionKey = null;
    }
    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                displayName: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "login", user)
            .then(function (data) {
                saveUserData(data);
                sessionKey = data.sessionKey;
                mainUsername = data.displayName;
                document.location.href = '#/my-accounts';
                return data;
            });
        },
        register: function (username, password) {
            var user = {
                displayName: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "register", user)
            .then(function (data) {
                saveUserData(data);
                sessionKey = data.sessionKey;
                mainUsername = data.displayName;
                return data.displayName;
            });
        },
        logout: function () {
            if (!sessionKey) {
                document.location.href = '#/';
            }
            return putJSON(this.apiUrl + "logout?sessionKey=" + sessionKey).then(function () {
                clearUserData();
            });
        },
        currentUser: function () {
            var displayName = localStorage.getItem("displayName");
            return displayName;
        }
    });
    var AccountsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        getAll: function () {
            var sessionKey = localStorage.getItem('sessionKey');
            var url = this.apiUrl + '?sessionKey=' + sessionKey;
            return getJSON(url);
        },
        // GET api/accounts/5?sessionKey=...
        getAccountById: function (accountId) {
            var sessionKey = localStorage.getItem('sessionKey');
            var url = this.apiUrl + '/' + accountId + '?sessionKey=' + sessionKey;
            return getJSON(url);
        },
        // PUT api/accounts/2?depositSum=...&sessionKey=...
        makeDeposit: function (accountId, amount) {
            var sessionKey = localStorage.getItem('sessionKey');
            var url = this.apiUrl + '/' + accountId + '?depositSum=' + amount + '&sessionKey=' + sessionKey;
            return putJSON(url);
        },
        // PUT api/accounts/2?depositSum=...&sessionKey=...
        withdraw: function (accountId, amount) {
            var sessionKey = localStorage.getItem('sessionKey');
            var url = this.apiUrl + '/' + accountId + '?withdrawSum=' + amount + '&sessionKey=' + sessionKey;
            return putJSON(url);
        }
    });
    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.accounts = new AccountsPersister(apiUrl + "accounts");
        }
    });
    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    };
}());