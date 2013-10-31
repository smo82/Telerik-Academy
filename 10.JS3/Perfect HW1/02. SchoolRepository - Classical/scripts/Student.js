/// <reference path="OOPUtils.js" />
/// <reference path="Person.js" />

(function () {
    Student = Class.create({
        init: function (firstName, lastName, age, grade) {
            this._super.init.apply(this, arguments);
            this.grade = grade;
        }
    });
    Student.inherit(Person);
}())