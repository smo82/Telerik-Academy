var controls = (function(){
  var Student = {
    init: function(fName,lName,grade) {
      this.fName = fName;
      this.lName = lName;
      this.grade = grade;
    },

    render: function(){
      var rowHolder = $(document.createElement("tr"));
      var fNameCell =  $(document.createElement("td"));
      fNameCell.text(this.fName);
      var lNameCell =  $(document.createElement("td"));
      lNameCell.text(this.lName);
      var gradeCell =  $(document.createElement("td"));
      gradeCell.text(this.grade);
      rowHolder.append(fNameCell);
      rowHolder.append(lNameCell);
      rowHolder.append(gradeCell);

      return rowHolder;
    }
  };

  var HeaderRow = {
    init: function(colTitle1, colTitle2, colTitle3){
      this.colTitle1 = colTitle1;
      this.colTitle2 = colTitle2;
      this.colTitle3 = colTitle3;
    },

    render: function(){
      var rowHolder = $(document.createElement("tr"));
      var col1Cell =  $(document.createElement("th"));
      col1Cell.text(this.colTitle1);
      var col2Cell =  $(document.createElement("th"));
      col2Cell.text(this.colTitle2);
      var col3Cell =  $(document.createElement("th"));
      col3Cell.text(this.colTitle3);
      rowHolder.append(col1Cell);
      rowHolder.append(col2Cell);
      rowHolder.append(col3Cell);

      return rowHolder;
    }
  }

  var StudentsView = {
    init: function (selector){
      this.viewHolder = $(selector);
      this.students = [];
      this.headerRow = undefined;

      this.viewTableHolder = $(document.createElement("table"));
      this.viewTableHolder.attr("id", "studentsTable");
    },

    addHeaderData: function(colTitle1, colTitle2, colTitle3){
      var headerRow = Object.create(HeaderRow);
      headerRow.init(colTitle1, colTitle2, colTitle3);
      this.headerRow = headerRow;
    },

    addStudents: function (studentsCollection){
      for (var i = 0; i < studentsCollection.length; i++) {
        this.students.push(studentsCollection[i]);
      };
    },

    render: function(){
      while (this.viewTableHolder.firstChild) {
        this.viewTableHolder.removeChild(this.viewTableHolder.firstChild);
      }

      if (this.headerRow){
        var rowHolder = this.headerRow.render();
        this.viewTableHolder.append(rowHolder);
      }

      for (var i = 0; i < this.students.length; i++) {
        var studentRowHolder = this.students[i].render(); 
        this.viewTableHolder.append(studentRowHolder);
      };

      this.viewHolder.append(this.viewTableHolder);
    }
  }

  return{
    createStudent : function(fName,lName,grade){
      var student = Object.create(Student);
      student.init(fName,lName,grade);
      return student;
    },
    createStudentsView: function (selector){
      var studentView = Object.create(StudentsView);
      studentView.init(selector);
      return studentView;
    }
  }
}());