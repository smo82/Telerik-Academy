using Students.Data;
using Students.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Service.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/students
        public IQueryable<StudentModel> Get()
        {
            StudentsDbEntities context = new StudentsDbEntities();
            IQueryable<StudentModel> studentsDetails =
                (from student in context.Students
                 select new StudentModel()
                 {
                     FirstName = student.FirstName,
                     LastName = student.LastName,
                     Grade = student.Grade,
                     Age = student.Age,
                     Marks =
                         (from mark in student.Marks
                          select new MarkModel()
                          {
                              Subject = mark.Subject,
                              Score = mark.Score
                          })
                 });
            return studentsDetails;
        }
    }
}
