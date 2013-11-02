/// <reference path="Libs/jquery-2.0.2.js" />

var httpRequester = (function () {
    function get(url, success, error) {
        $.ajax({
            url: url,
            contentType: "application/json",
            type: "GET",
            success: success,
            error: error,
            timeout: 5000
        });
    }

    function post(url, data, success, error) {
        $.ajax({
            url: url,
            data: JSON.stringify(data),
            contentType: "application/json",
            type: "POST",
            success: success,
            error: error,
            timeout: 5000
        });
    }

    return {
        get: get,
        post: post
    }
})();