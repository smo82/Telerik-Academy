namespace SchoolSystemTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudentCreation()
        {
            Student newStudent = new Student("Andrey", "Petrov");

            string studentFirstName = newStudent.FirstName;
            Assert.AreEqual("Andrey", studentFirstName);

            string studentLastName = newStudent.LastName;
            Assert.AreEqual("Petrov", studentLastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentCreationNullFirstName()
        {
            Student newStudent = new Student(null, "Petrov");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentCreationNullLastName()
        {
            Student newStudent = new Student("Andrey", null);
        }

        [TestMethod]
        public void TestStudentUniqueId()
        {
            Student firstStudent = new Student("Andrey", "Petrov");
            Student secondStudent = new Student("Stoyan", "Stoyanov");

            bool areIdsEqual = firstStudent.Id == secondStudent.Id;

            Assert.IsFalse(areIdsEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStudentIdOverload()
        {
            for (int i = 10000; i < 100001; i++)
            {
                Student newStudent = new Student("Andrey", "Petrov");
            }
        }
    }
}
