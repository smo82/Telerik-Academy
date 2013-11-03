using Exam.Models;
using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<TicketViewModel> tickets = this.Data.Tickets.All().Select(TicketViewModel.FromTicket).ToList();

            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }        

        public ActionResult Details(int ticketId)
        {
            Ticket ticket = this.Data.Tickets.GetById(ticketId);

            if (ticket == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TicketDetailsViewModel ticketDetails = TicketDetailsViewModel.FromTicket.Compile()(ticket);

            return View(ticketDetails);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();

                ApplicationUser user = this.Data.AppicationUsers.All().FirstOrDefault(u => u.Id == userId);

                this.Data.Comments.Add(new Comment()
                {
                    User = user,
                    Content = commentModel.Comment,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { UserName = username, Content = commentModel.Comment };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        public ActionResult Add()
        {
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "CategoryId", "Name");

            List<Object> priorityValues = new List<Object>();            
            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
	        {
                priorityValues.Add(new { PriorityId = (int)priority, PriorityText = priority.ToString() });
	        }

            ViewBag.Priority = new SelectList(priorityValues, "PriorityId", "PriorityText", Priority.Medium);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Ticket ticket)
        {
            string userId = String.Empty;
            if (User.Identity.IsAuthenticated)
            {
                userId = this.User.Identity.GetUserId();
                ticket.AuthorId = userId;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                this.Data.Tickets.Add(ticket);
                
                ApplicationUser user = this.Data.AppicationUsers.All().FirstOrDefault(u => u.Id == userId);
                user.Points++;
                this.Data.SaveChanges();
                
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "CategoryId", "Name", ticket.CategoryId);

            List<Object> priorityValues = new List<Object>();
            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
            {
                priorityValues.Add(new { PriorityId = (int)priority, PriorityText = priority.ToString() });
            }

            ViewBag.Priority = new SelectList(priorityValues, "PriorityId", "PriorityText", ticket.Priority);
            return View(ticket);
        }

        public JsonResult GetTicketCategoryData()
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryId = x.CategoryId
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(int? categorysearch)
        {
            var result = this.Data.Tickets.All();

            if (categorysearch != null)
            {
                result = result.Where(t => t.CategoryId == categorysearch);
            }

            IEnumerable<TicketViewModel> endResult = result.Select(TicketViewModel.FromTicket);

            return View(endResult);
        }
    }
}