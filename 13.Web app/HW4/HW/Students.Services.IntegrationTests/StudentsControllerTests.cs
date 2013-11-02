using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Students.Repositories;
using System.Data.Entity;
using Students.DataLayer;
using Students.Models;
using Students.Services.Models;
using Newtonsoft.Json;
using System.Web.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace Students.Services.IntegrationTests
{
    [TestClass]
    public class StudentsControllerTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            DbContext context = new StudentsContext();
            DbAllRepositories allRepositories = new DbAllRepositories(context);
            this.httpServer = new InMemoryHttpServer("http://localhost/", allRepositories);
            ClearDb(); 
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void PostStudent_WhenDataCorrect_Test()
        {
            var studentModel = AddNewStudent();

            Assert.IsNotNull(studentModel);
            Assert.IsTrue(studentModel.Id != 0);
        }

        [TestMethod]
        public void PostStudent_WhenDataNotCorrect_Test()
        {
            var schoolModel = AddNewSchool();

            StudentModel initialStudent = new StudentModel()
            {
                FirstName = "Pesho"
            };

            var response = this.httpServer.CreatePostRequest("api/students", initialStudent);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetAllStudents_WhenTheyExist_Test()
        {
            var studentModel = AddNewStudent();

            var response = this.httpServer.CreateGetRequest("api/students");

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentSearchResult = JsonConvert.DeserializeObject<IList<StudentModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(studentSearchResult);
            Assert.AreEqual(1, studentSearchResult.Count);
        }

        [TestMethod]
        public void GetAllStudents_WhenThereAreNone_Test()
        {
            var response = this.httpServer.CreateGetRequest("api/students");

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentSearchResult = JsonConvert.DeserializeObject<IList<StudentModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(studentSearchResult);
            Assert.AreEqual(0, studentSearchResult.Count);
        }

        [TestMethod]
        public void GetStudentById_WhenHeExist_Test()
        {
            var studentModel = AddNewStudent();

            var response = this.httpServer.CreateGetRequest("api/students/" + studentModel.Id);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentSearchResult = JsonConvert.DeserializeObject<StudentModel>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(studentSearchResult);
            Assert.AreEqual(studentModel.Id, studentSearchResult.Id);
        }

        [TestMethod]
        public void GetStudentById_WhenHeDoesNotExist_Test()
        {
            var response = this.httpServer.CreateGetRequest("api/students/" + 17);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentSearchResult = JsonConvert.DeserializeObject<StudentModel>(contentString);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(studentSearchResult);
        }

        [TestMethod]
        public void GetStudentsByMarksOnSubject_WhenSearchIsCorrect_Test()
        {
            var studentModel = AddNewStudent();

            AddNewMark(studentModel);
            
            var response = this.httpServer.CreateGetRequest("api/students?subject=math&value=5.00");

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentsSearchResult = JsonConvert.DeserializeObject<IList<StudentModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(studentsSearchResult);
            Assert.AreEqual(1, studentsSearchResult.Count());
        }

        [TestMethod]
        public void GetStudentsByMarksOnSubject_WhenSearchIsNotCorrect_Test()
        {
            var studentModel = AddNewStudent();

            AddNewMark(studentModel);

            var response = this.httpServer.CreateGetRequest("api/students?subject=english&value=5.00");

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentsSearchResult = JsonConvert.DeserializeObject<IList<StudentModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(studentsSearchResult);
            Assert.AreEqual(0, studentsSearchResult.Count());
        }

        private StudentModel AddNewMark(StudentModel studentModel)
        {
            MarkModel initialMark = new MarkModel()
            {
                Subject = "math",
                Value = 6,
                StudentId = studentModel.Id
            };

            var response = this.httpServer.CreatePostRequest("api/marks", initialMark);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var createdMark = JsonConvert.DeserializeObject<StudentModel>(contentString);

            return createdMark;
        }

        private StudentModel AddNewStudent()
        {
            var schoolModel = AddNewSchool();

            StudentModel initialStudent = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Age = 15,
                Grade = 9,
                SchoolId = schoolModel.Id
            };

            var response = this.httpServer.CreatePostRequest("api/students", initialStudent);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var studentModel = JsonConvert.DeserializeObject<StudentModel>(contentString);

            return studentModel;
        }

        private SchoolModel AddNewSchool()
        {
            School school = new School()
            {
                Name = "Telerik"
            };

            var response = this.httpServer.CreatePostRequest("api/schools", school);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var schoolModel = JsonConvert.DeserializeObject<SchoolModel>(contentString);

            return schoolModel;
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
