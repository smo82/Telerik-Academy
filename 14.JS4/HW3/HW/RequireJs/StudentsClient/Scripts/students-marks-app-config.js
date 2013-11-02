(function () {
    require.config({
        paths: {
            "jquery": "../Lib/jquery-2.0.3.min",
            "class": "../Lib/class",
            "q": "../Lib/q",
            "mustache": "../Lib/mustache",
            "functions": "functions",
            "dataPersister": "data-persister",
            "httpRequester": "httpRequester",
            "controllers": "controllers",
            "masterDetailTable": "masterDetailTable",
        }
    });

    require(["controllers"], function (controllers) {
        debugger;
        var serviceRoot = "http://localhost:3521/api/";
        var contentSelector = "#content";
        var marksTemplateSelector = "#marks-template";
        var studentId = getParameterByName("studentId");
        controllers.displayStudentsMarks(serviceRoot, studentId, contentSelector, marksTemplateSelector);

        function getParameterByName(name) {
            var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
            return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
        }
    });
}());