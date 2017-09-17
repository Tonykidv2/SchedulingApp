using LibraryCode.People;
using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.DBContexts
{
    public class ProfessorContext : UserContext
    {
        public Professor professor;

        public ProfessorContext(Professor _professor, string _username, string _pass)
        {
            entityFramework = Database.Instance;
            professor = _professor;
            Username = _username;
            Password = _pass;
        }

        public bool RegisterStudent(Student _student)
        {
            try
            {
                _student.Person.Subjects.Add(professor.Person.Subjects.First());
                entityFramework.UpdateStudent(_student);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveStudent(Student _student)
        {
            try
            {
                _student.Person.Subjects.Remove(professor.Person.Subjects.First());
                entityFramework.UpdateStudent(_student);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool RemoveStudent(string _student)
        {
            try
            {
                var stu = entityFramework.GetStudent(_student);
                professor.Person.Subjects.First().Enrolled.Remove(stu.Person);
                entityFramework.UpdateProfessor(professor);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdateCourse(Course _course)
        {
            if(_course.Enrolled.Contains(professor.Person))
            {
                entityFramework.UpdateCourse(_course);
                return true;
            }
            return false;
        }

        public List<Person> ViewallAttendies()
        {
            List<Person> result = null;

            if(professor.Person.Subjects.First() != null)
            {
                foreach (var item in professor.Person.Subjects.First().Enrolled)
                {
                    if(item.Username != Username)
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public bool CancelClass(Course _course)
        {
            if (professor.Person.Subjects.First() != null)
            {
                _course.Enrolled.Clear();
                entityFramework.UpdateCourse(_course);
                return true;
            }

            return false;
        }
    }
}
