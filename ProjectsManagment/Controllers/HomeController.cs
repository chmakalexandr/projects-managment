using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Domain.Core;
using Infrastructure.Data;

namespace ProjectsManagment.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private UserService userService;
        public HomeController()
        {
            userService = new UserService();
        }
        public ActionResult Index()
        {
            var users = userService.FindById(1);
            return View();
        }
    }
}
