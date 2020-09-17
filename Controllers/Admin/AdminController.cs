using BetterReviews.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterReviews.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}