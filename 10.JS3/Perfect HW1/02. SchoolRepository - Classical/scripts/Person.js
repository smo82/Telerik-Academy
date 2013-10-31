/// <reference path="OOPUtils.js" />

(function () {
    Person = Class.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            var introduction = "";
            for (var prop in this) {
                if (typeof (this[prop]) === 'number' || typeof (this[prop]) === 'string') {
                    introduction += prop + ": " + this[prop] + ", ";
                }
            }
            return introduction.slice(0, introduction.length - 2);
        }
    });
}())