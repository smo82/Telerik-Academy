using CodeJewels.DataModel;
using CodeJewels.Service.Models;
using CodeJewels.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeJewels.Service.Controllers
{
    public class CodeJewelsController : ApiController
    {
        private DbAllRepositories allRepositories;

        public CodeJewelsController(DbAllRepositories allRepositories)
        {
            this.allRepositories = allRepositories;
        }

        // GET api/CodeJewels
        public IEnumerable<CodeJewelModel> GetCodeJewels()
        {
            DbCodeJewelsRepository codeJewelsRepository = this.allRepositories.GetCodeJewelRepository();
            var codeJewelsEntities = codeJewelsRepository.All();

            var codeJewelsModels =
                from codeJewelEntity in codeJewelsEntities
                select new CodeJewelModel()
                {
                    CodeJewelId = codeJewelEntity.CodeJewelId,
                    SourseCode = codeJewelEntity.SourseCode,
                    AuthorEmail = codeJewelEntity.AuthorEmail,
                    Rating = codeJewelEntity.Rating,
                    CategoryId = codeJewelEntity.CategoryId
                };

            return codeJewelsModels.ToList();
        }

        // GET api/CodeJewels/5
        public CodeJewelModel GetCodeJewels(int id)
        {
            DbCodeJewelsRepository codeJewelsRepository = this.allRepositories.GetCodeJewelRepository();

            var codeJewel = codeJewelsRepository.Get(id);
            if (codeJewel == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No such code jewel was found");
                throw new HttpResponseException(errResponse);
            }

            var codeJewelModel = new CodeJewelModel()
            {
                CodeJewelId = codeJewel.CodeJewelId,
                SourseCode = codeJewel.SourseCode,
                AuthorEmail = codeJewel.AuthorEmail,
                Rating = codeJewel.Rating,
                CategoryId = codeJewel.CategoryId
            };

            return codeJewelModel;
        }

        // GET api/CodeJewels
        public IEnumerable<CodeJewelModel> GetCodeJewels(string sourseCode, int categoryId)
        {
            DbCodeJewelsRepository codeJewelsRepository = this.allRepositories.GetCodeJewelRepository();

            var codeJewelsEntities = codeJewelsRepository.All().Where(s => s.SourseCode == sourseCode && s.CategoryId == categoryId);
                        
            var codeJewelModels =
                from codeJewelEntity in codeJewelsEntities
                select new CodeJewelModel()
                {
                    CodeJewelId = codeJewelEntity.CodeJewelId,
                    SourseCode = codeJewelEntity.SourseCode,
                    AuthorEmail = codeJewelEntity.AuthorEmail,
                    Rating = codeJewelEntity.Rating,
                    CategoryId = codeJewelEntity.CategoryId
                };

            return codeJewelModels.ToList();
        }

        // GET api/CodeJewels/up
        public HttpResponseMessage GetVoteCodeJewels(string vote, int id)
        {
            DbCodeJewelsRepository codeJewelsRepository = this.allRepositories.GetCodeJewelRepository();

            var codeJewel = codeJewelsRepository.Get(id);
            if (codeJewel == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No such code jewel was found");
                throw new HttpResponseException(errResponse);
            }

            vote = vote.ToLower();
            if (vote == "up")
            {
                codeJewel.Rating++;
            }
            else if (vote == "down")
            {
                codeJewel.Rating--;
            }
            else
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Incorrect vote");
                throw new HttpResponseException(errResponse);
            }

            codeJewelsRepository.Update(id, codeJewel);

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        // POST api/CodeJewels
        public HttpResponseMessage PostStudent(CodeJewelModel codeJewelModel)
        {
            if (codeJewelModel == null)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The supported code jewel model cannot be null");
                throw new HttpResponseException(errResponse);
            }

            if (codeJewelModel.CategoryId == 0)
            {
                var errResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The category Id is not correct");
                throw new HttpResponseException(errResponse);
            }

            DbCodeJewelsRepository codeJewelRepository = this.allRepositories.GetCodeJewelRepository();

            CodeJewel codeJewel = new CodeJewel()
            {
                SourseCode = codeJewelModel.SourseCode,
                AuthorEmail = codeJewelModel.AuthorEmail,
                CategoryId = codeJewelModel.CategoryId
            };

            codeJewelRepository.Add(codeJewel);

            CodeJewelModel createdCodeJewelModel = new CodeJewelModel()
            {
                CodeJewelId = codeJewel.CodeJewelId,
                SourseCode = codeJewel.SourseCode,
                AuthorEmail = codeJewel.AuthorEmail,
                Rating = codeJewel.Rating,
                CategoryId = codeJewel.CategoryId
            };
            
            var response = Request.CreateResponse<CodeJewelModel>(HttpStatusCode.Created, createdCodeJewelModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdCodeJewelModel.CodeJewelId });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }

        // DELETE api/CodeJewels/5
        public void Delete(int id)
        {
            DbCodeJewelsRepository codeJewelRepository = this.allRepositories.GetCodeJewelRepository();
            codeJewelRepository.Delete(id);
        }
    }
}
