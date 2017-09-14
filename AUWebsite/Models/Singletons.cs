using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUWebsite.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<String> List { get; set; }


        public User()
        {
            Username = "Username";
            Password = "Password";
            List = new List<string>();
            List.Add("Student");
            List.Add("Professor");
            List.Add("Registar");
        }
    }
}