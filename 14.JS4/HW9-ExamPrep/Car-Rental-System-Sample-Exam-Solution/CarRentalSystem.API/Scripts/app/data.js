window.persisters = (function () {
	var sessionKey = "";
	var loggedUsername = "";

	function saveUserData(data) {
	    localStorage.setItem("username", data.displayName);
	    localStorage.setItem("sessionKey", data.sessionKey);
	    loggedUsername = data.displayName;
	    sessionKey = data.sessionKey;
	}

	function getJSON(requestUrl, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: requestUrl,
				type: "GET",
				dataType: "json",
				headers: headers,
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

	function postJSON(requestUrl, data, headers) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			$.ajax({
				url: requestUrl,
				type: "POST",
				contentType: "application/json",
				data: JSON.stringify(data),
				dataType: "json",
				headers: headers,
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

	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);
				});
		},
		register: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveUserData(data);
					return data.displayName;
				});
		},
		logout: function () {
			if (!sessionKey) {
				//gyrmi
			}
			var headers = {
				"X-sessionKey": sessionKey
			};
			//clear sessionKey
			sessionKey = "";
			return putJSON(this.apiUrl + "logout", headers);
		},
		currentUser: function () {
			return loggedUsername;
		}
	});

	var CarsPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		all: function () {
			return getJSON(this.apiUrl);
		}
	});

	var StoresPersister = Class.create({
	})

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "users/");
			this.cars = new CarsPersister(apiUrl + "cars/");
			this.stores = new StoresPersister(apiUrl + "stores/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());