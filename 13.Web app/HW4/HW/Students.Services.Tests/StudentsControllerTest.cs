using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Transactions;
using Students.Models;
using Students.Repositories;
using Students.DataLayer;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Students.Services.Controllers;
using System.Collections.Generic;
using System.Linq;
using Students.Services.Models;
using System.Net;

namespace Students.Services.Tests
{
    [TestClass]
    public class StudentsControllerTest
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public DbAllRepositories allRepositories { get; set; }

        private static TransactionScope tranScope;

        public StudentsControllerTest()
        {
            this.dbContext = new StudentsContext();
            this.allRepositories = new DbAllRepositories(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
            ClearDb(); 
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void PostNullStudent_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            studentsController.PostStudent(null);
        }

        [TestMethod]
        public void PostCorrectStudent_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            School school = new School()
            {
                Name = "Telerik"
            };

            DbSet<School> schools = this.dbContext.Set<School>();
            schools.Add(school);
            this.dbContext.SaveChanges();

            StudentModel initialStudent = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                SchoolId = school.Id
            };

            HttpResponseMessage response = studentsController.PostStudent(initialStudent);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            StudentModel resultStudent = response.Content.ReadAsAsync<StudentModel>().Result;

            Assert.AreEqual(initialStudent.FirstName, resultStudent.FirstName);
            Assert.AreEqual(initialStudent.LastName, resultStudent.LastName);
            Assert.AreEqual(initialStudent.Age, resultStudent.Age);
            Assert.AreEqual(initialStudent.Grade, resultStudent.Grade);
            Assert.AreEqual(initialStudent.SchoolId, resultStudent.SchoolId);
        }

        [TestMethod]
        public void GetAllStudents_WhenOneExist_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            School school = new School()
            {
                Name = "Telerik"
            };

            DbSet<School> schools = this.dbContext.Set<School>();
            schools.Add(school);
            this.dbContext.SaveChanges();

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };
            DbSet<Student> students = this.dbContext.Set<Student>();
            students.Add(initialStudent);
            this.dbContext.SaveChanges();

            IEnumerable<StudentModel> response = studentsController.GetStudents();
            Assert.AreEqual(1, response.Count());

            StudentModel student = response.First();

            Assert.AreEqual(initialStudent.Id, student.Id);
        }

        [TestMethod]
        public void GetAllStudents_WhenNoneExist_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            IEnumerable<StudentModel> response = studentsController.GetStudents();
            Assert.AreEqual(0, response.Count());
        }

        [TestMethod]
        public void GetStudentById_WhenOneExist_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            School school = new School()
            {
                Name = "Telerik"
            };

            DbSet<School> schools = this.dbContext.Set<School>();
            schools.Add(school);
            this.dbContext.SaveChanges();

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };
            DbSet<Student> students = this.dbContext.Set<Student>();
            students.Add(initialStudent);
            this.dbContext.SaveChanges();

            StudentDetails resultStudent = studentsController.GetStudents(initialStudent.Id);
            Assert.IsNotNull(resultStudent);

            Assert.AreEqual(initialStudent.Id, resultStudent.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetStudentById_WhenNoneExist_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            StudentDetails resultStudent = studentsController.GetStudents(12);
        }

        [TestMethod]
        public void GetStudentsByMarksOnSubject_WhenSearchCorrect_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            School school = new School()
            {
                Name = "Telerik"
            };

            DbSet<School> schools = this.dbContext.Set<School>();
            schools.Add(school);
            this.dbContext.SaveChanges();

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };
            DbSet<Student> students = this.dbContext.Set<Student>();
            students.Add(initialStudent);

            Mark mathMark = new Mark()
            {
                Subject = "math",
                Value = 5
            };
            initialStudent.Marks.Add(mathMark);

            Mark englishMark = new Mark()
            {
                Subject = "english",
                Value = 2
            };
            initialStudent.Marks.Add(mathMark);

            this.dbContext.SaveChanges();

            IEnumerable<StudentModel> result = studentsController.GetStudents("math", 4);
            Assert.AreEqual(1, result.Count());

            StudentModel resultStudent = result.First();

            Assert.AreEqual(initialStudent.Id, resultStudent.Id);
        }

        [TestMethod]
        public void GetStudentsByMarksOnSubject_WhenSearchNotCorrect_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            School school = new School()
            {
                Name = "Telerik"
            };

            DbSet<School> schools = this.dbContext.Set<School>();
            schools.Add(school);
            this.dbContext.SaveChanges();

            Student initialStudent = new Student()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                School = school
            };
            DbSet<Student> students = this.dbContext.Set<Student>();
            students.Add(initialStudent);

            Mark mathMark = new Mark()
            {
                Subject = "math",
                Value = 5
            };
            initialStudent.Marks.Add(mathMark);

            Mark englishMark = new Mark()
            {
                Subject = "english",
                Value = 2
            };
            initialStudent.Marks.Add(mathMark);

            this.dbContext.SaveChanges();

            IEnumerable<StudentModel> result = studentsController.GetStudents("math", 6);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetStudentsByMarksOnSubject_WhenNoneExists_Test()
        {
            StudentsController studentsController = new StudentsController(this.allRepositories);
            SetupController(studentsController);

            IEnumerable<StudentModel> result = studentsController.GetStudents("math", 4);
            Assert.AreEqual(0, result.Count());
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
