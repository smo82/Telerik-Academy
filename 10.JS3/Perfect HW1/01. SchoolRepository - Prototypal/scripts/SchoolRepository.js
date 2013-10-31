/// <reference path="OOPUtils.js" />
/// <reference path="School.js" />

(function () {
    SchoolReposioty = {
        init: function () {
            this.schools = [];
        },
        addSchool: function (school) {
            this.schools.push(school);
        }
    }
}())