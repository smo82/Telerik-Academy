using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : BaseController
    {
	}
}