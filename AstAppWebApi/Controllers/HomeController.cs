using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AstAppWebApi.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Authorize]
        public ActionResult IndexAuthorize()
        {
            try
            {
                string userId = User.Identity.GetUserId();



            }
            catch
            {

            }

            return View();
        }
    }
}
