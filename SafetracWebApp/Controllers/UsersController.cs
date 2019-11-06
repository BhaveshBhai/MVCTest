using SafetracWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetracWebApp.Controllers
{
    public class UsersController : Controller
    {
        UserModelView userModel = new UserModelView();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult List()

        {
            return Json(new { data = userModel.GetAllUsers() }, JsonRequestBehavior.AllowGet);
        }
    }
}