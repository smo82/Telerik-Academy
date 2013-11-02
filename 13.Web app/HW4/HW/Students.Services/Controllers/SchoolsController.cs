using Students.Models;
using Students.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Services.Models;

namespace Students.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        private DbAllRepositories allRepositories;

        public SchoolsController(DbAllRepositories allRepositories)
        {
            this.allRepositories = allRepositories;
        }

        // GET api/Students
        public IEnumerable<SchoolModel> GetStudents()
        {
            DbSchoolRepository schoolRepository = this.allRepositories.GetSchoolRepository();

            var schoolEntities = schoolRepository.All();

            var schoolModels =
                from schEntity in schoolEntities
                select new SchoolModel()
                {
                    Id = schEntity.Id,
                    Name = schEntity.Name,
                    Location = schEntity.Location
                };

            return schoolModels.ToList();
        }

        // GET api/Students/5
        public SchoolDetails GetStudent(int id)
        {
            DbSchoolRepository schoolRepository = this.allRepositories.GetSchoolRepository();

            var school = schoolRepository.Get(id);
            var schoolDetails = new SchoolDetails()
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location,
                Students = (from student in school.Students
                            select new StudentModel()
                            {
                                Id = student.Id,
                                FirstName = student.FirstName,
                                LastName = student.LastName,
                                Age = student.Age,
                                Grade = student.Grade
                            }).ToList()
            };

            return schoolDetails;
        }

        // POST api/Students
        public HttpResponseMessage PostStudent(SchoolModel schoolModel)
        {
            DbSchoolRepository schoolRepository = this.allRepositories.GetSchoolRepository();

            School school = new School()
            {
                Name = schoolModel.Name,
                Location = schoolModel.Location
            };

            schoolRepository.Add(school);

            SchoolModel createdSchoolModel = new SchoolModel()
            {
                Id = school.Id,
                Name = school.Name,
                Location = school.Location
            };

            var response = Request.CreateResponse<SchoolModel>(HttpStatusCode.Created, createdSchoolModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdSchoolModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}
