using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Students.Models;
using Students.DataLayer;
using Students.Repositories;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private DbAllRepositories allRepositories;

        public StudentsController(DbAllRepositories allRepositories)
        {
            this.allRepositories = allRepositories;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetStudents()
        {
            DbStudentsRepository studentRepository = this.allRepositories.GetStudentsRepository();
            var studentEntities = studentRepository.All();

            var studentModels =
                from studEntity in studentEntities
                select new StudentModel()
                {
                    Id = studEntity.Id,
                    FirstName = studEntity.FirstName,
                    LastName = studEntity.LastName,
                    Age = studEntity.Age,
                    Grade = studEntity.Grade,
                    SchoolId = studEntity.School.Id
                };

            return studentModels.ToList();
        }

        // GET api/Students/5
        public StudentDetails GetStudents(int id)
        {
            DbStudentsRepository studentRepository = this.allRepositories.GetStudentsRepository();

            var student = studentRepository.Get(id);
            if (student == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No such user was found");
                throw new HttpResponseException(errResponse);
            }

            var studentDetails = new StudentDetails()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade,
                SchoolId = student.School.Id,

                Marks = (from mark in student.Marks
                         select new MarkModel()
                         {
                             Id = mark.Id,
                             Subject = mark.Subject,
                             Value = mark.Value
                         }).ToList()
            };

            return studentDetails;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetStudents(string subject, decimal value)
        {
            DbStudentsRepository studentRepository = this.allRepositories.GetStudentsRepository();

            var studentEntities = studentRepository.All().Where(s => s.Marks.Any(m => (m.Subject == subject && m.Value > value)));
                        
            var studentModels =
                from studEntity in studentEntities
                select new StudentModel()
                {
                    Id = studEntity.Id,
                    FirstName = studEntity.FirstName,
                    LastName = studEntity.LastName,
                    Age = studEntity.Age,
                    Grade = studEntity.Grade,
                    SchoolId = studEntity.School.Id
                };

            return studentModels.ToList();
        }
        
        // POST api/Students
        public HttpResponseMessage PostStudent(StudentModel studentModel)
        {
            if (studentModel == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The supported student model cannot be null");
                throw new HttpResponseException(errResponse);
            }

            if (studentModel.SchoolId == 0)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The school Id is not correct");
                throw new HttpResponseException(errResponse);
            }

            DbSchoolRepository schoolRepository = this.allRepositories.GetSchoolRepository();

            Student student = new Student()
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Age = studentModel.Age,
                Grade = studentModel.Grade,
                School = schoolRepository.Get(studentModel.SchoolId)
            };
            
            DbStudentsRepository studentRepository = this.allRepositories.GetStudentsRepository();

            studentRepository.Add(student);

            StudentModel createdStudentModel = new StudentModel()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade,
                SchoolId = student.School.Id
            };

            var response = Request.CreateResponse<StudentModel>(HttpStatusCode.Created, createdStudentModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdStudentModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}