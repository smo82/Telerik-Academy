/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
	var rootUrl = "Scripts/partials/";

	var templates = {};

	function getTemplate(name) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			if (templates[name]) {
				resolve(templates[name])
			}
			else {
				$.ajax({
					url: rootUrl + name + ".html",
					type: "GET",
					success: function (templateHtml) {
						templates[name] = templateHtml;
						resolve(templateHtml);
					},
					error: function (err) {
						reject(err)
					}
				});
			}
		});
		return promise;
	}

	function getHomeView() {
	    return getTemplate("home-form");
	}

	function getLoginView() {
		return getTemplate("login-form");
	}

	function getRegisterView() {
	    return getTemplate("register-form");
	}

	function getLogoutView() {
	    return getTemplate("logout-form");
	}

	function getAppointmentsView() {
		return getTemplate("appointments-form");
	}

	function getCurrentAppointmentsView() {
	    return getTemplate("current-appointments-form");
	}

	function getTodoListsView() {
	    return getTemplate("todoLists-form");
	}

	function getSingleTodoListView() {
	    return getTemplate("todos-form");
	}

	return {
	    getHomeView: getHomeView,
	    getLoginView: getLoginView,
	    getRegisterView: getRegisterView,
	    getLogoutView: getLogoutView,
	    getAppointmentsView: getAppointmentsView,
	    getCurrentAppointmentsView: getCurrentAppointmentsView,
	    getTodoListsView: getTodoListsView,
	    getSingleTodoListView: getSingleTodoListView
	};
}());