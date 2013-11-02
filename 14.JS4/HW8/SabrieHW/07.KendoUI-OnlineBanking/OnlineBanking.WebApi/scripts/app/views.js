/// <reference path="../libs/_references.js" />
window.viewsFactory = (function () {
    var rootUrl = "scripts/partials/";
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
    function getLoginView() {
        return getTemplate("login-form");
    }
    function getAccountsView() {
        return getTemplate("accounts");
    }
    function getAccountDetailsView() {
        return getTemplate("account-details");
    }
    function getDepositView() {
        return getTemplate("deposit");
    }
    function getWithdrawView() {
        return getTemplate("withdraw");
    }
    function getMenuView() {
        return getTemplate("nav-menu-form");
    }
    return {
        getLoginView: getLoginView,
        getAccountsView: getAccountsView,
        getMenuView: getMenuView,
        getAccountDetailsView: getAccountDetailsView,
        getDepositView: getDepositView,
        getWithdrawView: getWithdrawView
    };
}());