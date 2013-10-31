var School = {
  init: function(name, town) {
    this.name = name;
    this.town = town;
    this.classes = [];
  },
  addClass: function(schoolClass) {
    this.classes.push(schoolClass)
  }
};

var SchoolClass = {
  init: function(name, capacity, teacher) {
    this.name = name;
    this.capacity = capacity;
    this.teacher = teacher;
    this.students = [];
  },
  addStudent: function(student) {
    this.students.push(student)
  }
};

var Person = {
  init: function(fname, lname, age) {
    this.fname = fname;
    this.lname = lname;
    this.age = age;
  },
  introduce: function() {
    var result = "";
    for(var prop in this) {
      if ((typeof this[prop] !== 'function') &&
          (prop != '_super')){
        result += prop + ": " + this[prop] + ", "; 
      }
    }
    return result.substring(0, result.length - 2);
  }
};

var Student = Person.extend({
  init: function(fname, lname, age, grade) {
    Person.init.apply(this, arguments);
    this.grade = grade;
  },
  introduce: function () {
    return "Name: " + this.fname + " " + this.lname + ", Age: " + this.age + ", grade: " + this.grade;
  }
});

var Teacher = Person.extend({
  init: function(fname, lname, age, speciality) {
    Person.init.apply(this, arguments);
    this.speciality = speciality;
  }
});

var student1 = Object.create(Student);
student1.init("Spas", "Grigorov", 15, 8);

var student2 = Object.create(Student);
student2.init("Ivan", "Petrov", 7, 1);

console.log(student1.introduce());
console.log(student2.introduce());

var teacher1 = Object.create(Teacher);
teacher1.init("Stoqn", "Stoqnov", 50, "History");
console.log(teacher1.introduce());

var schoolClass1 = Object.create(SchoolClass);
schoolClass1.init("JS", 300, teacher1);
schoolClass1.addStudent(student1);
schoolClass1.addStudent(student2);
console.log(schoolClass1);

var school1 = Object.create(School);
school1.init("Telerik", "Sofia");
school1.addClass(schoolClass1);
console.log(school1);