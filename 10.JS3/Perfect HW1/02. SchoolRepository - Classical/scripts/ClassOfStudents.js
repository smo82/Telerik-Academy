/// <reference path="OOPUtils.js" />
/// <reference path="Teacher.js" />
/// <reference path="Student.js" />

(function () {
    ClassOfStudents = Class.create({
        init: function (name, capacity, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.formTeacher = formTeacher;
            this.setOfStudents = [];
        },
        addStudent: function (student) {
            if (this.setOfStudents.length < this.capacity) {
                this.setOfStudents.push(student);
            }
        }
    });
}())