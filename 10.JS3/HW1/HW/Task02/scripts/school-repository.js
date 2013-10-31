var School = Class.create({
  init: function(name, town) {
    this.name = name;
    this.town = town;
    this.classes = [];
  },
  addClass: function(schoolClass) {
    this.classes.push(schoolClass)
  }
});

var SchoolClass = Class.create({
  init: function(name, capacity, teacher) {
    this.name = name;
    this.capacity = capacity;
    this.teacher = teacher;
    this.students = [];
  },
  addStudent: function(student) {
    this.students.push(student)
  }
});

var Person = Class.create({
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
});

var Student = Class.create({
  init: function(fname, lname, age, grade) {
    this._super.init(fname, lname, age);
    this.grade = grade;
  },
  introduce: function () {
    return "Name: " + this.fname + " " + this.lname + ", Age: " + this.age + ", grade: " + this.grade;
  }
});
Student.inherit(Person);

var Teacher = Class.create({
  init: function(fname, lname, age, speciality) {
    this._super.init(fname, lname, age);
    this.speciality = speciality;
  }
});
Teacher.inherit(Person);

var student1 = new Student("Spas", "Grigorov", 15, 8);
var student2 = new Student("Ivan", "Petrov", 7, 1);

console.log(student1.introduce());
console.log(student2.introduce());

var teacher1 = new Teacher("Stoqn", "Stoqnov", 50, "History");
console.log(teacher1.introduce());

var schoolClass1 = new SchoolClass("JS", 300, teacher1);
schoolClass1.addStudent(student1);
schoolClass1.addStudent(student2);
console.log(schoolClass1);

var school1 = new School("Telerik", "Sofia");
school1.addClass(schoolClass1);
console.log(school1);