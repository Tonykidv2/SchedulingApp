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

        //[HttpGet]
        public ActionResult StudentPage()
        {
            if (ContextFactory.InstanceContext == null)
                return RedirectToAction("Index");
            ViewBag.Content = ((StudentContext)ContextFactory.InstanceContext);
            return View(PersonMVCContext.Instance);
        }

        public ActionResult ProfessorPage()
        {
            if (ContextFactory.InstanceContext == null)
                return RedirectToAction("Index");
            ViewBag.Content = ((ProfessorContext)ContextFactory.InstanceContext);
            ViewBag.Roster = ((ProfessorContext)ContextFactory.InstanceContext).professor.Person.Subjects.ToList().First().Enrolled;
            return View(PersonMVCContext.Instance);
        }

        public ActionResult RegistarPage()
        {
            if (ContextFactory.InstanceContext == null)
                return RedirectToAction("Index");
            ViewBag.Content = ((RegistarContext)ContextFactory.InstanceContext);
            return View(PersonMVCContext.Instance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveCourse(User context)
        {
            PersonMVCContext.Instance.Incorrect = !((StudentContext)ContextFactory.InstanceContext).DropCourse(context.RemovethisCourse);
            
            return RedirectToAction("StudentPage");
        }
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(User context)
        {
            PersonMVCContext.Instance.Incorrect = !((StudentContext)ContextFactory.InstanceContext).EnrollInCouse(context.RemovethisCourse);

            return RedirectToAction("StudentPage");
        }

        public ActionResult ViewCourse()
        {
            ViewBag.Courses = ContextFactory.InstanceContext.GetActiveCourse();

            return View();
        }
        public ActionResult ViewMasterCourse()
        {
            ViewBag.Courses = ContextFactory.InstanceContext.GetActiveCourse();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveStudent(User _person)
        {
            if(_person.selected1 == "Professor")
            {
                
                PersonMVCContext.Instance.Incorrect = ((ProfessorContext)ContextFactory.InstanceContext).RemoveStudent(_person.RemoveThisStudent);
                
                return RedirectToAction("ProfessorPage");
            }
            else if(_person.selected1 == "Registar")
            {

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse()
        {
            PersonMVCContext.Instance.editedCourse = ((ProfessorContext)ContextFactory.InstanceContext).professor.Person.Subjects.First();
            return View(PersonMVCContext.Instance);
        }

        [HttpPost]
        public ActionResult UpdateCourse(User course)
        {
            if (PersonMVCContext.Instance.selected1 == "Professor")
            {
                course.editedCourse.Name = ((ProfessorContext)ContextFactory.InstanceContext).professor.Person.Subjects.First().Name;
                course.editedCourse.Enrolled = ((ProfessorContext)ContextFactory.InstanceContext).professor.Person.Subjects.First().Enrolled;
                course.editedCourse.CourseID = ((ProfessorContext)ContextFactory.InstanceContext).professor.Person.Subjects.First().CourseID;
                PersonMVCContext.Instance.Incorrect = ((ProfessorContext)ContextFactory.InstanceContext).UpdateCourse(course.editedCourse);
                
                return RedirectToAction("ProfessorPage");
            }
            else if (PersonMVCContext.Instance.selected1 == "Registar")
            {

            }

            return RedirectToAction("Index");
        }

        public ActionResult CancelCourse(User course)
        {
            if (PersonMVCContext.Instance.selected1 == "Professor")
            {
                ((ProfessorContext)ContextFactory.InstanceContext).CancelClass();
                return RedirectToAction("ProfessorPage");
            }
            else if (PersonMVCContext.Instance.selected1 == "Registar")
            {
                return RedirectToAction("Register");
            }

            return RedirectToAction("Index");
        }
    }
}