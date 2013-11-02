﻿/// <reference path="Scripts/q.js" />
/// <reference path="Scripts/jquery-2.0.2.js" />

define(["jquery", "q"], function ($, Q) {

    var HttpRequester = (function () {

        var promiseAjaxRequest = function (url, type, data) {
            var ajaxDeferred = Q.defer();

            if(data){
                data = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                data: data,
                contentType: "application/json",
                success: function (responseData) {
                    ajaxDeferred.resolve(responseData);
                },
                error: function (errorData) {
                    ajaxDeferred.reject(errorData);
                }
            });

            return ajaxDeferred.promise;
        }

        var promiseAjaxRequestGet = function (url) {
            return promiseAjaxRequest(url, "GET");
        }

        var promiseAjaxRequestPost = function (url, data) {
            return promiseAjaxRequest(url, "POST", data);
        }

        var promiseAjaxRequestPut = function (url, data) {
            return promiseAjaxRequest(url, "PUT", data);
        }

        return {
            getJson: promiseAjaxRequestGet,

            postJson: promiseAjaxRequestPost,

            putJson: promiseAjaxRequestPut
        }
    }());

    return HttpRequester;
});