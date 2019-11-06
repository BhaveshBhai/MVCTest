using SafetracWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafetracWebApp.Controllers
{
    public class HomeController : Controller
    {
        UserModelView userModel = new UserModelView();
        public ActionResult Index()
        {
            UserModelView users = new UserModelView();
            var data = users.GetAllUsers();
            return View();
        }

        public ActionResult UsersList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadAllData()

        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var search = Request.Form.GetValues("search[value]").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var lstUsers = userModel.LoadAllUsers(search.ToString(), Convert.ToInt32(start), pageSize, sortColumn, sortColumnDir);
            return Json(new { draw = draw, recordsFiltered = lstUsers.Count(), recordsTotal = lstUsers.Select(x=>x.MaxRows).FirstOrDefault(), data = lstUsers }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}