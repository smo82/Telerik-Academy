window.persisters = (function () {
	var accessToken = "";
	var loggedUsername = "";

	function saveUserData(data) {
	    localStorage.setItem("username", data.username);
	    localStorage.setItem("accessToken", data.accessToken);
	    loggedUsername = data.username;
	    accessToken = data.accessToken;
	}

	function clearUserData() {
	    localStorage.removeItem("username");
	    localStorage.removeItem("accessToken");
	    loggedUsername = "";
	    accessToken = "";
	}

	function getAccessToken() {
	    return localStorage.getItem("accessToken");
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

	function putJSON(requestUrl, data, headers) {
	    var promise = new RSVP.Promise(function (resolve, reject) {
	        $.ajax({
	            url: requestUrl,
	            type: "PUT",
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
		init: function (apiUrl, logoutUrl) {
		    this.apiUrl = apiUrl;
		    this.logoutUrl = logoutUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.logoutUrl + "token", user)
				.then(function (data) {
				    saveUserData(data);
				});
		},
		register: function (username, password, email) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString(),
				email: email
			};
			return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    return data.username;
				});
		},
		logout: function () {
		    if (!getAccessToken()) {
		        var promise = new RSVP.Promise(function (resolve, reject) {
		            var errorObject = { responseJSON: { Message: "You are not logged in" } };

		            reject(errorObject);
		        });

		        return promise;
			}

			var headers = {
			    "X-accessToken": getAccessToken()
			};

			clearUserData()
			return putJSON(this.apiUrl + "logout", {}, headers);
		},
		currentUser: function () {
		    return localStorage.getItem("username");
		}
	});

	var AppointmentPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    getAll: function () {
	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return getJSON(this.apiUrl + "all", headers);
	    },
	    create: function (subject, description, appointmentDate, duration) {
	        var appointment = {
	            subject: subject,
	            description: description,
	            appointmentDate: appointmentDate,
	            duration: duration,
	        };

	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return postJSON(this.apiUrl, appointment, headers);
	    },
	    getAllForDate: function (date) {
	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return getJSON(this.apiUrl + "?date=" + date, headers);
	    },
	    getCurrent: function () {
	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return getJSON(this.apiUrl + "current", headers);
	    },
	});

	var TodoListsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    getAll: function () {
	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return getJSON(this.apiUrl, headers);
	    },
	    create: function (title) {
	        var todoList = {
	            title: title,
	            todos: []
	        };

	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        return postJSON(this.apiUrl, todoList, headers);
	    },
	});

	var TodoPersister = Class.create({
	    init: function (apiUrl, todoApiUrl) {
	        this.apiUrl = apiUrl;
	        this.todoApiUrl = todoApiUrl;
	    },
	    getData: function (id) {
	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        var apiWithIdUrl = this.apiUrl + id + "/todos/";
	        return getJSON(apiWithIdUrl, headers);
	    },
	    create: function (id, text) {
	        var todo = {
	            text: text
	        };

	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        var apiWithIdUrl = this.apiUrl + id + "/todos/";
	        return postJSON(apiWithIdUrl, todo, headers);
	    },
	    changeIsDone: function (id) {
	        var data = {
	        };

	        var headers = {
	            "X-accessToken": getAccessToken()
	        };

	        var todoApiWithIdUrl = this.todoApiUrl + id;
	        return putJSON(todoApiWithIdUrl, data, headers);
	    },
	});

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "users/", apiUrl + "auth/");
			this.appointments = new AppointmentPersister(apiUrl + "appointments/");
			this.todoLists = new TodoListsPersister(apiUrl + "lists/");
			this.todos = new TodoPersister(apiUrl + "lists/", apiUrl + "todos/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());