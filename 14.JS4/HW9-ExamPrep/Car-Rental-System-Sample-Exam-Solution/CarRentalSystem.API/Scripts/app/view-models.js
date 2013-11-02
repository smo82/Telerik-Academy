/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
	var data = null;

	function getLoginViewModel(successCallback) {		
		var viewModel = {
			username: "",
			password: "",
            message: "",
            login: function () {
                var self = this;
				data.users.login(this.get("username"), this.get("password"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}

						self.set("message", "");
					}, function (err) {
					    var errMessageText = err.statusText;
					    self.set("message", errMessageText);
					});
			},
			register: function () {
			    var self = this;
				data.users.register(this.get("username"), this.get("password"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}

						self.set("message", "");
					}, function (err) {
					    var errMessageText = err.statusText;
					    self.set("message", errMessageText);
					});
			}
		};
		return kendo.observable(viewModel);
	};

	function getCarsViewModel() {
		return data.cars.all()
			.then(function (cars) {
				var viewModel = {
					cars: cars,
					message: ""
				};

				return kendo.observable(viewModel);
			}, function (err) {
			    var errMessageText = err.statusText;
			    var viewModel = {
			        cars: [],
			        message: errMessageText
			    };

			    return kendo.observable(viewModel);
			});
	}

	return {
		getLoginVM: getLoginViewModel,
		getCarsVM: getCarsViewModel,
		setPersister: function (persister) {
			data = persister
		}
	};
}());