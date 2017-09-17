using AUWebsite.Models;
using LogicLibrary;
using LogicLibrary.DBContexts;
using LogicLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUWebsite.Controllers
{
    public class LoginController : Controller
    {
        private UserContext Context;
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            
            ViewBag.Title = "LogIn";
            ViewBag.Message = "Select Your User";

            return View(PersonMVCContext.Instance);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContext(/*[Bind(Include = "Username1, Password1, selected1")]*/User _person)
        {
            switch(_person.selected1)
            {
                case "Student":
                    Context = ContextFactory.GetContext(ContextFactory.ContextType.Student, _person.Username1, _person.Password1);
                    break;
                case "Professor":
                    Context = ContextFactory.GetContext(ContextFactory.ContextType.Professor, _person.Username1, _person.Password1);
                    break;
                case "Registar":
                    Context = ContextFactory.GetContext(ContextFactory.ContextType.Registar, _person.Username1, _person.Password1);
                    break;
            }
            PersonMVCContext.Instance.Password1 = _person.Password1;
            PersonMVCContext.Instance.Username1 = _person.Username1;
            PersonMVCContext.Instance.selected1 = _person.selected1;

            if (Context != null)
            {
                PersonMVCContext.Instance.Incorrect = false;
                if(_person.selected1 == "Student")
                    return RedirectToAction("StudentPage");
                if (_person.selected1 == "Professor")
                    return RedirectToAction("ProfessorPage");
                if (_person.selected1 == "Registar")
                    return RedirectToAction("RegistarPage");
            }
            
            PersonMVCContext.Instance.Incorrect = true;
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult StudentPage()
        {
            if (ContextFactory.InstanceContext == null)
                return RedirectToAction("Index");
            ViewBag.Content = ((StudentContext)ContextFactory.InstanceContext);
            return View(PersonMVCContext.Instance);
        }

        public ActionResult ProfessorPage()
        {
            return View();
        }

        public ActionResult RegistarPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveCourse(User context)
        {
            ((StudentContext)ContextFactory.InstanceContext).DropCourse(context.RemovethisCourse);
            
            return RedirectToAction("StudentPage");
        }
        public ActionResult AddCourse(User context)
        {
            return View();
        }
    }
}