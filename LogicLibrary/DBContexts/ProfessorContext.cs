using LibraryCode.People;
using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.DBContexts
{
    class ProfessorContext : UserContext
    {
        Professor professor;

        public ProfessorContext(Professor _professor)
        {
            entityFramework = Database.Instance;
            professor = _professor;
        }

        public bool RegisterStudent(Student _student)
        {
            _student.Person.Subjects.Add(professor.Person.Subjects.First());
            entityFramework.UpdateStudent(_student);
            return true;
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
