using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Service;
namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private IAdminService _adminService;
        public HomeController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }
        public ActionResult Index()
        {
            var check = _adminService.GetAll().ToList();
            return View();
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