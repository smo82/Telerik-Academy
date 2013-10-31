namespace SchoolSystemTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseCreation()
        {
            Course newCourse = new Course("Quality Code");
            string courseName = newCourse.Name;

            Assert.AreEqual("Quality Code", courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseCreationNullFirstName()
        {
            Course newCourse = new Course(null);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            Course newCourse = new Course("Quality Code");
            Student newStudent = new Student("Andrey", "Petrov");
            newCourse.StudentJoin(newStudent);

            int remainingStudentsNumber = newCourse.Students.Count;

            Assert.AreEqual(1, remainingStudentsNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseAddNullStudent()
        {
            Course newCourse = new Course("Quality Code");
            newCourse.StudentJoin(null);

            int remainingStudentsNumber = newCourse.Students.Count;

            Assert.AreEqual(1, remainingStudentsNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseAddStudentOverload()
        {
            Course newCourse = new Course("Quality Code");
            for (int i = 0; i < 30; i++)
            {
                Student newStudent = new Student("Andrey", "Petrov");
                newCourse.StudentJoin(newStudent);
            }
        }

        [TestMethod]
        public void TestCourseLeaveStudent()
        {
            Course newCourse = new Course("Quality Code");
            Student newStudent = new Student("Andrey", "Petrov");
            newCourse.StudentJoin(newStudent);
            newCourse.StudentLeave(newStudent);

            int remainingStudentsNumber = newCourse.Students.Count;

            Assert.AreEqual(0, remainingStudentsNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseLeaveFromEmptyStudentList()
        {
            Course newCourse = new Course("Quality Code");
            /*
             * In this case we expect first the check for an emtpy student list to be done
             * For that reason we call the test with null student
             */
            newCourse.StudentLeave(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseLeaveNullStudent()
        {
            Course newCourse = new Course("Quality Code");
            Student newStudent = new Student("Andrey", "Petrov");
            newCourse.StudentJoin(newStudent);
            newCourse.StudentLeave(null);
        }
    }
}
