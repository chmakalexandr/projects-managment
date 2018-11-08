using ProjectsManagment.Data;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectsManagment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public HomeController()
        {
            userService = new UserService();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
                      

            return View();
        }
    }
}
