using Students.Models;
using Students.Repositories;
using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class MarksController : ApiController
    {
        private DbAllRepositories allRepositories;

        public MarksController(DbAllRepositories allRepositories)
        {
            this.allRepositories = allRepositories;
        }

        // POST api/Marks
        public HttpResponseMessage PostMarks(MarkModel marksModel)
        {
            if (marksModel == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The supported mark model cannot be null");
                throw new HttpResponseException(errResponse);
            }

            DbStudentsRepository studentRepository = this.allRepositories.GetStudentsRepository();

            Student student = studentRepository.Get(marksModel.StudentId);

            DbMarksRepository marksRepository = this.allRepositories.GetMarksRepository();

            Mark mark = new Mark()
            {
                Subject = marksModel.Subject,
                Value = marksModel.Value,
                Student = student
            };

            marksRepository.Add(mark);

            MarkModel createdMarkModel = new MarkModel()
            {
                Id = mark.Id,
                Subject = mark.Subject,
                Value = mark.Value,
                StudentId = mark.Student.Id
            };

            var response = Request.CreateResponse<MarkModel>(HttpStatusCode.Created, createdMarkModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdMarkModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
