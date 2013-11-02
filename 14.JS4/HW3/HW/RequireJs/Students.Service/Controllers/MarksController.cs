using Students.Data;
using Students.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Service.Controllers
{
    public class MarksController : ApiController
    {
        public IQueryable<MarkModel> Get(int id)
        {
            StudentsDbEntities context = new StudentsDbEntities();
            IQueryable<MarkModel> marksDetails =
                (from mark in context.Marks
                 where mark.StudentId == id
                 select new MarkModel()
                 {
                     Subject = mark.Subject,
                     Score = mark.Score
                 });
            return marksDetails;
        }
    }
}
