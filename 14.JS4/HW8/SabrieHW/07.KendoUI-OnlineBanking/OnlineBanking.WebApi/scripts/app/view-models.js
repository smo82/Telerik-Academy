/// <reference path="../libs/_references.js" />
window.vmFactory = (function () {
    var data = null;
    function getLoginViewModel(successCallback) {
        var viewModel = {
            displayName: "",
            password: "",
            login: function () {
                data.users.login(this.get("displayName"), this.get("password"))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                });
            },
            register: function () {
                data.users.register(this.get("displayName"), this.get("password"))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                });
            }
        };
        return kendo.observable(viewModel);
    }
    function getAccountsViewModel() {
        return data.accounts.getAll()
        .then(function (accounts) {
            var viewModel = {
                accounts: accounts,
                message: "",
                logout: function () {
                    data.users.logout()
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function () {
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
                }
            };
            return kendo.observable(viewModel);
        });
    }
    function getAccountDetailsViewModel(id) {
        return data.accounts.getAccountById(id)
        .then(function (account) {
            var viewModel = {
                account: account,
                message: "",
                logout: function () {
                    data.users.logout()
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function () {
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
                }
            };
            return kendo.observable(viewModel);
        });
    }
    function getDepositVM(id, successCallback, errorCallback) {
        var viewModel = {
            amount: "",
            id: id,
            deposit: function (e) {
                e.preventDefault();
                data.accounts.makeDeposit(id, this.get('amount'))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    if (errorCallback) {
                        errorCallback();
                    }
                });
            }
        };
        return kendo.observable(viewModel);
    }
    function getWithdrawVM(id, successCallback, errorCallback) {
        var viewModel = {
            amount: "",
            id: id,
            withdraw: function (e) {
                e.preventDefault();
                data.accounts.withdraw(id, this.get('amount'))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    if (errorCallback) {
                        errorCallback();
                    }
                });
            }
        };
        return kendo.observable(viewModel);
    }
    return {
        getLoginVM: getLoginViewModel,
        getAccountsVM: getAccountsViewModel,
        getAccountDetailsVM: getAccountDetailsViewModel,
        getDepositVM: getDepositVM,
        getWithdrawVM: getWithdrawVM,
        setPersister: function (persister) {
            data = persister;
        }
    };
}());