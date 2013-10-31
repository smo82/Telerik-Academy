(function () {
    School = {
        init: function (name, town) {
            this.name = name;
            this.town = town;
            this.classesOfstudents = [];
        },
        addClassOfStudents: function (classOfStudents) {
            this.classesOfstudents.push(classOfStudents);
        }
    }
})();