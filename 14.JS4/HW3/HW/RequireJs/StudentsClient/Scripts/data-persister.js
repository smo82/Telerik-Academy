define(["httpRequester"], function (httpRequester) {
    function getStudentsData(serviceRoot) {
        var studentsService = serviceRoot + "students";
        var studentsDataPromis = httpRequester.getJson(studentsService);
        return studentsDataPromis;
    }

    function getMarksData(serviceRoot, studentId) {
        var marksService = serviceRoot + "marks/" + studentId;
        var marksDataPromis = httpRequester.getJson(marksService);
        return marksDataPromis;
    }

    return {
        getStudentsData: getStudentsData,
        getMarksData: getMarksData
    }
    
});