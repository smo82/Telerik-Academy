/// <reference path="OOPUtils.js" />
/// <reference path="Person.js" />

(function () {
    Teacher = Person.extend({
        init: function (firstName, lastName, age, speciallity) {
            this._super.init.apply(this, arguments);
            this.speciallity = speciallity;
        }
    });
}())