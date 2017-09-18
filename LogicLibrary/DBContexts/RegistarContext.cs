using LibraryCode.People;
using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.DBContexts
{
    public class RegistarContext : UserContext
    {
        public Registar registar;

        public RegistarContext(Registar _registar, string _username, string _pass)
        {
            entityFramework = Database.Instance;
            registar = _registar;
            Username = _username;
            Password = _pass;
        }

        public bool CreateCourse(Course _course)
        {
            try
            {
                entityFramework.AddCourse(_course);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCourse(Course _course)
        {
            try
            {
                entityFramework.RemoveCourse(_course.Name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AssignToCourse(Course _course, Person _person)
        {
            try
            {
                _course.Enrolled.Add(_person);
                entityFramework.UpdateCourse(_course);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AssignToCourse(Course _course, List<Person> _persons)
        {
            try
            {
                foreach (var item in _persons)
                {
                    _course.Enrolled.Add(item);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCourse(Course _course)
        {
            try
            {
                entityFramework.UpdateCourse(_course);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Course> ViewSchedule(Person _person)
        {
            try
            {
                return _person.Subjects.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
