/// <reference path="OOPUtils.js" />
/// <reference path="Person.js" />
(function () {
    Teacher = Class.create({
        init: function (firstName, lastName, age, speciallity) {
            this._super.init.apply(this, arguments);
            this.speciallity = speciallity;
        }
    });
    Teacher.inherit(Person);
}())