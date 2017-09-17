using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static LogicLibrary.Factory.ContextFactory;

namespace AUWebsite.Models
{
    public class User
    {
        [Required]
        public string Username1 { get; set; }
        [Required]
        public string Password1 { get; set; }
        public List<SelectListItem> List1 { get; set; }
        [Required]
        public string selected1 { get; set; }
        public bool Incorrect { get; set; }
        public string RemovethisCourse { get; set; }
        public string RemoveThisStudent { get; set; }
        public Course editedCourse { get; set; }

        public User()
        {
            Incorrect = false;
            Username1 = "Username";
            Password1 = "Password";
            List1 = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Student", Value = ContextType.Student.ToString(), Selected = true},
                new SelectListItem() {Text = "Professor", Value = ContextType.Professor.ToString(), Selected = false},
                new SelectListItem() {Text = "Registar", Value = ContextType.Registar.ToString(), Selected = false}
            };

        }
    }
    public static class PersonMVCContext
    {
        private static User instance;

        public static User Instance { get
            {
                if (instance == null)
                    instance = new User();

                return instance;
            }
        }
    }
}