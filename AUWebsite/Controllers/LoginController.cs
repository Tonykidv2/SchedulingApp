using AUWebsite.Models;
using LogicLibrary;
using LogicLibrary.DBContexts;
using LogicLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static LogicLibrary.Factory.ContextFactory;

namespace AUWebsite.Controllers
{
    public class LoginController : Controller
    {
        UserContext Context;

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            //Context = GetContext(ContextType.Student, "User", "Pass");
            ViewBag.Title = "LogIn";
            ViewBag.Message = "Select Your User";
            User person = new User();
            return View(person);

        }
        [HttpPost]
        public ActionResult CreateContext(User _person)
        {
            Context = new StudentContext(null, "User", "Pass");
            return View();//Content("Type: " + _type + " Username: " + _username + " Pass: " + _pass);
        }

    }
}