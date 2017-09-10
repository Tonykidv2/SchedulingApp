using LibraryCode.People;
using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.DBContexts
{
    class StudentContext : UserContext
    {

        public StudentContext(Student _student)
        {
            entityFramework = Database.Instance;
            student = _student;
        }

        public Student student;

        public bool EnrollInCouse(Course course)
        {
            if((student.CurrCredits + course.CreditHours) < 18.0f && (course.Enrolled.Count + 1) < course.MaxStudents)
            {
                foreach (var item in student.Person.Subjects)
                {
                    if (item.Name == course.Name)
                        return false;
                    if (CheckTimeConflict(item, course))
                        return false;
                }

            }
            return false;
        }
        private bool CheckTimeConflict(Course rhs, Course lhs)
        {
            DateTime dateTimeOffset = new DateTime();
            return false;
        }
    }
}
