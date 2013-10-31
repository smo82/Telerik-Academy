/// <reference path="OOPUtils.js" />
/// <reference path="ClassOfStudents.js" />

(function () {
    School = Class.create({
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classesOfstudents = [];
        },
        addClassOfStudents: function (classOfStudents) {
            this.classesOfstudents.push(classOfStudents);
        }
    });
}())