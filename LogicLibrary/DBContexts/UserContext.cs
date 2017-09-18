using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public abstract class UserContext
    {
        public EntityFramework entityFramework;
        protected string Username;
        protected string Password;

        public List<Course> GetActiveCourse()
        {
            return entityFramework.Courses.ToList();
        }

       
    }
}
