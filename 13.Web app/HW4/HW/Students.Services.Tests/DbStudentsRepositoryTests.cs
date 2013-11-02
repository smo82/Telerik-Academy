using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Repositories;
using System.Data.Entity;
using Students.Models;
using System.Transactions;
using Students.DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace Students.Services.Tests
{
    [TestClass]
    public class DbStudentsRepositoryTests
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope;

        public DbStudentsRepositoryTests()
        {
            this.dbContext = new StudentsContext();
            this.studentsRepository = new DbStudentsRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
            ClearDb(); 
            // I clean the data base before each test in order for the tests to not stumble in to already exinsting data in the
            // database. It is possible this Database clearing to be done once before all the test, but it requires additional 
            // parameterization so I do it here :)
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        //------------------------------------------------------------------------------------------------------------------------------------
        // IMPORTANT
        //
        // Please note that on the first execution of the code the Code First is trying to create the data base end throws an exception
        // saing that you are not allowed to create database in multi-statement transaction. In order to work around this problem please
        // first execute the tests without the [TestInitialize] and [TestCleanup] methods. This way on the first execution the database
        // will be created and the code will not try to create it again.
        //------------------------------------------------------------------------------------------------------------------------------------
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateRepository_WithNullContext_Test()
        {
            DbStudentsRepository studentsRepository = new DbStudentsRepository(null);
        }

        [TestMethod]
        public void AddStudent_Test()
        {
            School school = new School()
            {
                Name = "Telerik"
            };

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15, 
                Grade = 9,
                School = school
            };

            Student studentCreated = this.studentsRepository.Add(initialStudent);

            Student foundStudent = this.dbContext.Set<Student>().Find(studentCreated.Id);

            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(initialStudent.FirstName, foundStudent.FirstName);
            Assert.AreEqual(initialStudent.LastName, foundStudent.LastName);
            Assert.AreEqual(initialStudent.Age, foundStudent.Age);
            Assert.AreEqual(initialStudent.Grade, foundStudent.Grade);
        }

        [TestMethod]
        public void AddStudent_ShouldRetyrnNotZeroID_Test()
        {
            School school = new School()
            {
                Name = "Telerik"
            };
            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };

            Student studentCreated = this.studentsRepository.Add(initialStudent);

            Student foundStudent = this.dbContext.Set<Student>().Find(studentCreated.Id);

            Assert.IsTrue(foundStudent.Id != 0);
        }

        [TestMethod]
        public void GetStudent_ByExistingId_Test()
        {
            School school = new School()
            {
                Name = "Telerik"
            };

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };

            this.dbContext.Set<Student>().Add(initialStudent);

            Student foundStudent = this.studentsRepository.Get(initialStudent.Id);

            Assert.IsNotNull(foundStudent);
            Assert.AreEqual(foundStudent.Id, initialStudent.Id);
        }

        [TestMethod]
        public void GetStudent_ByIncorrectId_ShouldReturnNull_Test()
        {
            School school = new School()
            {
                Name = "Telerik"
            };

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };

            this.dbContext.Set<Student>().Add(initialStudent);

            Student foundStudent = this.studentsRepository.Get(124142);

            Assert.IsNull(foundStudent);
        }

        [TestMethod]
        public void GetAllStudents_WhenNonExist_Test()
        {
            IQueryable<Student> foundStudent = this.studentsRepository.All();

            Assert.AreEqual(foundStudent.Count(), 0);
        }

        [TestMethod]
        public void GetAllStudents_WhenOnlyOneExists_Test()
        {
            School school = new School()
            {
                Name = "Telerik"
            };

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };

            this.dbContext.Set<Student>().Add(initialStudent);
            this.dbContext.SaveChanges();

            IQueryable<Student> foundStudent = this.studentsRepository.All();

            Assert.AreEqual(foundStudent.Count(), 1);

            Student onlyStudent = foundStudent.First();
            Assert.AreEqual(onlyStudent.Id, initialStudent.Id);
        }

        private static void ClearDb()
        {
            StudentsContext studentContext = new StudentsContext();

            DbSet<Mark> marks = studentContext.Set<Mark>();
            List<Mark> marksAsList = marks.ToList();

            foreach (Mark mark in marksAsList)
            {
                marks.Remove(mark);
            }

            DbSet<Student> students = studentContext.Set<Student>();
            List<Student> studentsAsList = studentContext.Set<Student>().ToList();

            foreach (Student student in studentsAsList)
            {
                students.Remove(student);
            }

            DbSet<School> schools = studentContext.Set<School>();
            List<School> schoolsAsList = schools.ToList();


            foreach (School school in schoolsAsList)
            {
                schools.Remove(school);
            }

            studentContext.SaveChanges();
        }
    }
}
