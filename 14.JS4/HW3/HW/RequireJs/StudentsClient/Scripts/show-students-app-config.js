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
        setTimeout(function () { }, 5000);
        var serviceRoot = "http://localhost:3521/api/";
        var contentSelector = "#content";
        var studentsTemplateSelector = "#students-template";
        controllers.displayStudentsData(serviceRoot, contentSelector, studentsTemplateSelector);
    });
}());