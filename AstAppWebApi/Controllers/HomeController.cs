using AstAppBL;
using AstAppSharedEntities.DTOs;
using AstAppSharedEntities.EntityModels;
using AstAppWebApi.Models;
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
        private PoolManager _poolManager = new PoolManager();
        private UserManager _userManager = new UserManager();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Authorize]
        public ActionResult IndexAuthorize()
        {
            UserVM model = new UserVM();
            try
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser user = _userManager.GetUser(userId);                
                if (user != null)
                {
                    model.UserName = user.UserName;
                    model.IsFounder = user.IsFounder;
                }               
            }
            catch(Exception excp)
            {

            }
            return PartialView("~/Views/Home/_IndexAuthorize.cshtml", model);
        }

        [Authorize]
        public JsonResult GetUserPools()
        {
            try
            {
                string userId = User.Identity.GetUserId();

                List<PoolDTO> poolAsAdministrator = _poolManager.GetPoolOfUser(userId);
                List<PoolDTO> availablePools = _poolManager.GetAvailablePools(userId);

                PoolsViewModel poolsVM = new PoolsViewModel();
                poolsVM.UserPools = poolAsAdministrator;
                poolsVM.AvailablePools = availablePools;

                JsonResult json = Json(poolsVM, JsonRequestBehavior.AllowGet);

                return json;
            }
            catch (Exception excp)
            {

            }
            return Json(false);
        }

    }
}
