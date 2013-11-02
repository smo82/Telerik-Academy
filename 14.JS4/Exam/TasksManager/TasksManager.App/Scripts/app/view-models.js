/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function getHomeViewModel() {
        var viewModel = {
        };
        return kendo.observable(viewModel);
    };

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            email: "",
            message: "",
            login: function () {
                var self = this;

                //Verify username
                var userName = this.get("username");
                if (userName.length < 6 || userName.length > 30) {
                    self.set("message", "Username must be between 6 and 30 characters");
                    return;
                }

                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }

					    self.set("message", "");
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            email: "",
            message: "",
            register: function () {
                var self = this;

                //Verify username
                var userName = this.get("username");
                if (userName.length < 6 || userName.length > 30) {
                    self.set("message", "Username must be between 6 and 30 characters");
                    return;
                }

                //Verify email
                var email = this.get("email");
                if (email == "") {
                    self.set("message", "Email is invalid");
                    return;
                }

                data.users.register(this.get("username"), this.get("password"), this.get("email"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }

					    self.set("message", "");
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getLogoutViewModel(successCallback) {
        var viewModel = {
            username: data.users.currentUser(),
            message: "",
            logout: function () {
                var self = this;
                data.users.logout()
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }

					    self.set("message", "");
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getAppointmentsViewModel() {
        var viewModel = {
            appointments: [],
            subject: "",
            description: "",
            appointmentDate: new Date(),
            duration: "",
            dateFilter: "",
            message: "",
            create: function () {
                var self = this;

                //Verify Subject date
                var subject = this.get("subject");
                if (!subject) {
                    self.set("message", "Invalide subject");
                    return;
                }

                //Verify Description date
                var description = this.get("description");
                if (!description) {
                    self.set("message", "Invalide description");
                    return;
                }

                //Verify Appointment date
                var appointmentDatepicker = this.get("appointmentDate");
                var appointmentDate = kendo.toString(appointmentDatepicker, "yyyy-MM-dd");
                if (!appointmentDate) {
                    self.set("message", "Invalide appointment date");
                    return;
                }

                //Verify Duration date
                var durationAsString = this.get("duration");
                var duration = parseInt(durationAsString);
                if (!duration) {
                    self.set("message", "Invalide duration");
                    return;
                }

                data.appointments.create(this.get("subject"), this.get("description"), appointmentDate, this.get("duration"))
					.then(function () {
					    self.set("subject", "");
					    self.set("description", "");
					    self.set("appointmentDate", "");
					    self.set("duration", "");
					    self.set("message", "");

					    self.getAll();
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            },
            getAll: function () {
                var self = this;

                data.appointments.getAll()
                    .then(function (appointments) {
                        self.set("appointments", appointments);
                        self.set("message", "");
                    }, function (err) {
                        var errMessageText = err.responseJSON.Message;
                        self.set("message", errMessageText);
                    });
            },
            getAllForDate: function () {
                var self = this;
                var dateFilterDatepicker = this.get("dateFilter");
                var dateFilter = kendo.toString(dateFilterDatepicker, "yyyy-MM-dd");
                
                //Verify Date filter
                if (!dateFilter) {
                    self.set("message", "Invalide date filter");
                    return;
                }

                if (dateFilter) {
                    data.appointments.getAllForDate(dateFilter)
                        .then(function (appointments) {
                            self.set("appointments", appointments);
                            self.set("message", "");
                        }, function (err) {
                            var errMessageText = err.responseJSON.Message;
                            self.set("message", errMessageText);
                        });
                } else {
                    self.getAll();
                }
            },
        };

        var viewModelObservable = kendo.observable(viewModel);

        data.appointments.getAll()
			.then(function (appointments) {
			    viewModelObservable.set("appointments", appointments);
			    viewModelObservable.set("message", "");
			}, function (err) {
			    var errMessageText = err.responseJSON.Message;
			    viewModelObservable.set("message", errMessageText);
			});

        return viewModelObservable;
    };

    function getCurrentAppointmentsViewModel() {
        var viewModel = {
            appointments: [],
            toggleState: "Expand",
            message: "",
            getAll: function () {
                var self = this;

                data.appointments.getCurrent()
                    .then(function (appointments) {
                        if (self.get("toggleState") == "Collapse") {
                            self.set("appointments", appointments);
                        } else {
                            self.set("appointments", []);
                        }
                        self.set("message", "");
                    }, function (err) {
                        var errMessageText = err.responseJSON.Message;
                        self.set("message", errMessageText);
                    });
            },
            displayToggle: function () {
                var self = this;

                if (self.get("toggleState") == "Expand") {
                    self.set("toggleState", "Collapse");
                } else {
                    self.set("toggleState", "Expand");
                };

                self.getAll();
            },
        };

        var viewModelObservable = kendo.observable(viewModel);

        data.appointments.getCurrent()
			.then(function (appointments) {
			    if (viewModelObservable.get("toggleState") == "Collapse") {
			        viewModelObservable.set("appointments", appointments);
			    } else {
			        viewModelObservable.set("appointments", []);
			    }
			    viewModelObservable.set("message", "");
			}, function (err) {
			    var errMessageText = err.responseJSON.Message;
			    viewModelObservable.set("message", errMessageText);
			});

        return viewModelObservable;
    };

    function getTodoListViewModel() {
        var viewModel = {
            todoLists: [],
            title: "",
            message: "",
            create: function () {
                var self = this;
                data.todoLists.create(this.get("title"))
					.then(function () {
					    self.set("title", "");
					    self.set("message", "");

					    self.getAll();
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            },
            getAll: function () {
                var self = this;

                data.todoLists.getAll()
                    .then(function (todoLists) {
                        self.set("todoLists", todoLists);
                        self.set("message", "");
                    }, function (err) {
                        var errMessageText = err.responseJSON.Message;
                        self.set("message", errMessageText);
                    });
            },
        };

        var viewModelObservable = kendo.observable(viewModel);

        data.todoLists.getAll()
			.then(function (todoLists) {
			    viewModelObservable.set("todoLists", todoLists);
			    viewModelObservable.set("message", "");
			}, function (err) {
			    var errMessageText = err.responseJSON.Message;
			    viewModelObservable.set("message", errMessageText);
			});

        return viewModelObservable;
    };

    function getSingleListViewModel(id) {
        var viewModel = {
            todos: [],
            id: id,
            title: "",
            todoText: "",
            message: "",
            create: function () {
                var self = this;

                data.todos.create(this.get("id"), this.get("todoText"))
					.then(function () {
					    self.set("todoText", "");

					    self.getData();
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            },
            getData: function () {
                var self = this;

                data.todos.getData(this.get("id"))
                    .then(function (todoList) {
                        self.set("title", todoList.title);
                        self.set("todos", todoList.todos);
                        self.set("message", "");
                    }, function (err) {
                        var errMessageText = err.responseJSON.Message;
                        self.set("message", errMessageText);
                    });
            },
            changeIsDone: function (e) {
                var self = this;
                var todoId = $(e.target).data('parameter');

                data.todos.changeIsDone(todoId)
					.then(function () {
					    self.getData();
					}, function (err) {
					    var errMessageText = err.responseJSON.Message;
					    self.set("message", errMessageText);
					});
            },
        };

        var viewModelObservable = kendo.observable(viewModel);

        data.todos.getData(id)
			.then(function (todoList) {
			    viewModelObservable.set("title", todoList.title);
			    viewModelObservable.set("todos", todoList.todos);
			    viewModelObservable.set("message", "");
			}, function (err) {
			    var errMessageText = err.responseJSON.Message;
			    viewModelObservable.set("message", errMessageText);
			});

        return viewModelObservable;
    };

    return {
        getHomeVM: getHomeViewModel,
        getLoginVM: getLoginViewModel,
        getRegisterVM: getRegisterViewModel,
        getLogoutVM: getLogoutViewModel,
        getAppointmentsVM: getAppointmentsViewModel,
        getCurrentAppointmentsVM: getCurrentAppointmentsViewModel,
        getTodoListVM: getTodoListViewModel,
        getSingleListVM: getSingleListViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());