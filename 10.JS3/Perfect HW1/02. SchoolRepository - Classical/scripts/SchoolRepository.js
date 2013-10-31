/// <reference path="OOPUtils.js" />
/// <reference path="School.js" />

(function () {
    SchoolRepository = Class.create({
        init: function () {
            this.schools = [];
        },
        addSchool: function (school) {
            this.schools.push(school);
        }
    });
}())