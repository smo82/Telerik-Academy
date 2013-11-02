/// <reference path="libs/_references.js" />
(function () {
    var appLayout =
    new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("http://localhost:56847/api/");
    vmFactory.setPersister(data);
    var router = new kendo.Router();
    router.route("/", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            router.navigate("/my-accounts");
        }
    });
    router.route("/login", function () {
        if (data.users.currentUser()) {
            router.navigate("/my-accounts");
        }
        else {
            viewsFactory.getLoginView()
            .then(function (loginViewHtml) {
                var loginVm = vmFactory.getLoginVM(
                function () {
                    router.navigate("/my-accounts");
                });
                var view = new kendo.View(loginViewHtml,
                { model: loginVm });
                appLayout.showIn("#main-content", view);
            });
        }
    });
    router.route("/my-accounts", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            viewsFactory.getAccountsView()
            .then(function (accountsViewHtml) {
                vmFactory.getAccountsVM()
                .then(function (vm) {
                    console.log(vm.accounts);
                    var view =
                    new kendo.View(accountsViewHtml,
                    { model: vm });
                    console.log(view);
                    appLayout.showIn("#main-content", view);
                });
            });
        }
    });
    router.route("/account/:id", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            viewsFactory.getAccountDetailsView()
            .then(function (accountViewHtml) {
                vmFactory.getAccountDetailsVM(id)
                .then(function (vm) {
                    var view =
                    new kendo.View(accountViewHtml,
                    { model: vm });
                    appLayout.showIn("#main-content", view);
                });
            });
        }
    });
    router.route("/account/:id/deposit", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            var successHandler = function () {
                router.navigate('/my-accounts');
            }
            var errorHandler = function () {
                console.log("Operation unsuccessful");
            }
            viewsFactory.getDepositView()
            .then(function (depositViewHtml) {
                var vm = vmFactory.getDepositVM(id, successHandler, errorHandler)
                var view =
                new kendo.View(depositViewHtml,
                { model: vm });
                appLayout.showIn("#main-content", view);
            });
        }
    });
    router.route("/account/:id/withdraw", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            var successHandler = function () {
                router.navigate('/my-accounts');
            }
            var errorHandler = function () {
                console.log("Operation unsuccessful");
            }
            viewsFactory.getWithdrawView()
            .then(function (withdrawViewHtml) {
                var vm = vmFactory.getWithdrawVM(id, successHandler, errorHandler)
                var view =
                new kendo.View(withdrawViewHtml,
                { model: vm });
                appLayout.showIn("#main-content", view);
            });
        }
    });
    router.route("/logout", function () {
        console.log("in logout");
        var displayName = data.users.currentUser();
        if (!displayName) {
            router.navigate("/login");
        } else {
            data.users.logout()
            .then(function () {
                router.navigate("/login");
            });
        }
    });
    $(function () {
        appLayout.render("#app");
        router.start();
    });
    return {
        router: function () {
            return router;
        }
    }
}());