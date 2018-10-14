using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infrastructure.Data;

namespace ProjectsManagment.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var users = unitOfWork.Users.GetUserList();
            return View();
        }
    }
}
