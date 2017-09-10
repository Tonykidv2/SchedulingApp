using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.People
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool FullTime { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public virtual ICollection<Course> Subjects { get; set; }
        public Person()
        {
            Subjects = new HashSet<Course>();
        }
        //May Go Away
        //public abstract void Enroll(Course _class);
        //public abstract void Drop(Course _class);

    }
}
