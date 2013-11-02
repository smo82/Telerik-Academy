define(["dataPersister", "mustache", "jquery", "q", "masterDetailTable", "class"], function (dataPersister, Mustache, $, Q, masterDetailTable) {

    function displayStudentsData(serviceRoot, contentSelector, studentsTemplateSelector) {
        var studentsDataPromis = dataPersister.getStudentsData(serviceRoot);
        studentsDataPromis.then(function (studentsData) {
            var template = $(studentsTemplateSelector).html();
            var studentsTemplate = Mustache.compile(template);

            var tableViewObject = masterDetailTable.getMasterDetailTableView(studentsData, studentsTemplate);

            $(contentSelector).append(tableViewObject);
        });
    }

    function getMarksData(serviceRoot, studentId, contentSelector, marksTemplateSelector) {
        var marksDataPromis = dataPersister.getMarksData(serviceRoot, studentId);
        marksDataPromis.then(function (marksData) {
            var template = $(marksTemplateSelector).html();
            var marksTemplate = Mustache.render(template, { "Marks": marksData });
            $("#content").html(marksTemplate);
        });

        return marksDataPromis;
    }

    return {
        displayStudentsData: displayStudentsData,
        displayStudentsMarks: getMarksData,
    }
});