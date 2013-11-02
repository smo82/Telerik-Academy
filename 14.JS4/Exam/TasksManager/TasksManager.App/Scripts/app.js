/// <reference path="libs/_references.js" />


(function () {
    var appLayout = new kendo.Layout(
        '<div id="logout-content"></div>' +
        '<div id="current-appointments-content"></div>' +
        '<div id="main-content"></div>');

	var data = persisters.get("api/");
	vmFactory.setPersister(data);

	var router = new kendo.Router();

	router.route("/", function () { homeRoute(); });

	router.route("/home", function () { homeRoute(); });

	router.route("/login", function () {
		if (data.users.currentUser()) {
			router.navigate("/");
		}
		else {
			viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
					var loginVm = vmFactory.getLoginVM(
						function () {
							router.navigate("/");
						});

					var view = new kendo.View(loginViewHtml,
						{ model: loginVm });

					appLayout.showIn("#main-content", view);
				});

			clearLoggedUserContent();
		}
	});

	router.route("/register", function () {
	    if (data.users.currentUser()) {
	        router.navigate("/");
	    }
	    else {
	        //Login user layouts
	        displayLoginUserLayouts();

            //Register layout
	        viewsFactory.getRegisterView()
				.then(function (registerViewHtml) {
				    var registerVm = vmFactory.getRegisterVM(
						function () {
                            alert("You were registered successfully!")

                            setTimeout(function () {
                                router.navigate("/login");
                            }, 1000);
						});

				    var view = new kendo.View(registerViewHtml,
						{ model: registerVm });

				    appLayout.showIn("#main-content", view);
				});
	    }
	});
    
	router.route("/appointments", function () {
	    if (!data.users.currentUser()) {
	        router.navigate("/login");
	    }
	    else {
	        //Login user layouts
	        displayLoginUserLayouts();

            //Appointments layout
	        viewsFactory.getAppointmentsView()
				.then(function (appointmentsViewHtml) {
				    var appointmentsVm = vmFactory.getAppointmentsVM();

				    var view = new kendo.View(appointmentsViewHtml,
						{ model: appointmentsVm });

				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	router.route("/todo-lists", function () {
	    if (!data.users.currentUser()) {
	        router.navigate("/login");
	    }
	    else {
	        //Login user layouts
	        displayLoginUserLayouts();

	        //Todo lists layout
	        viewsFactory.getTodoListsView()
				.then(function (todoListsViewHtml) {
				    var todoListsVm = vmFactory.getTodoListVM();

				    var view = new kendo.View(todoListsViewHtml,
						{ model: todoListsVm });

				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	router.route("/todo-list/:id", function (id) {
	    if (!data.users.currentUser()) {
	        router.navigate("/login");
	    }
	    else {
	        //Login user layouts
	        displayLoginUserLayouts();

	        //Single todo list layout
	        viewsFactory.getSingleTodoListView()
				.then(function (singleTodoListViewHtml) {
				    var singleTodoListVm = vmFactory.getSingleListVM(id);

				    var view = new kendo.View(singleTodoListViewHtml,
						{ model: singleTodoListVm });

				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	var homeRoute = function () {
	    if (data.users.currentUser()) {
	        // Login user layouts
	        displayLoginUserLayouts();

	        // Home main layout
	        viewsFactory.getHomeView()
                .then(function (homeViewHtml) {
                    var homeVm = vmFactory.getHomeVM();

                    var view = new kendo.View(homeViewHtml,
                        { model: homeVm });

                    appLayout.showIn("#main-content", view);
                });
	    }
	    else {
	        clearLoggedUserContent();
	        router.navigate("/login");
	    }
	};
    
	var displayLoginUserLayouts = function () {
        //Logout layout
	    displayLogoutLayout();

	    //Current appointments layout
	    displayCurrentAppointmentsLayout();
	}

	var displayLogoutLayout = function () {
	    if (!data.users.currentUser()) {
	        return;
	    }

	    if (checkIfElementExist('#logout-fieldset')) {
	        return;
	    }

	    viewsFactory.getLogoutView()
            .then(function (logoutViewHtml) {
                var logoutVm = vmFactory.getLogoutVM(
                    function () {
                        router.navigate("/login");
                    });

                var view = new kendo.View(logoutViewHtml,
                    { model: logoutVm });

                appLayout.showIn("#logout-content", view);
            });
	}

	var displayCurrentAppointmentsLayout = function () {
	    if (!data.users.currentUser()) {
	        return;
	    }

	    if (checkIfElementExist('#current-appointments')) {
	        return;
	    }

	    viewsFactory.getCurrentAppointmentsView()
            .then(function (currentAppointmentsViewHtml) {
                var currentAppointmentsVm = vmFactory.getCurrentAppointmentsVM();

                var view = new kendo.View(currentAppointmentsViewHtml,
                    { model: currentAppointmentsVm });

                appLayout.showIn("#current-appointments-content", view);
            });
	}

	var clearLoggedUserContent = function () {
        //Clear logout content
	    appLayout.showIn("#logout-content",
                getEmptyViewModel()
            );

	    //Clear current appointments content
	    appLayout.showIn("#current-appointments-content",
                getEmptyViewModel()
            );
	}

	var getEmptyViewModel = function () {
	    return new kendo.View("<span></span>", { model: kendo.observable({}) });
	};

	var checkIfElementExist = function(selector){
	    if ($(selector).length > 0) {
	        return true;
	    }

	    return false;
	};

	$(function () {
		appLayout.render("#app");
		router.start();
	});
}());