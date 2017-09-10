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
            if((student.CurrCredits + course.CreditHours) < 18.0d && (course.Enrolled.Count + 1) < course.MaxStudents)
            {
                foreach (var item in student.Person.Subjects)
                {
                    if (item.Name == course.Name)
                        return false;
                    if (CheckTimeConflict(item, course))
                        return false;
                }
                student.Person.Subjects.Add(course);
                student.CurrCredits += course.CreditHours;
                if (student.CurrCredits >= 12.0d)
                    student.Person.FullTime = true;
                else
                    student.Person.FullTime = false;

                entityFramework.UpdateStudent(student);
            }
            return false;
        }

        private bool CheckTimeConflict(Course rhs, Course lhs)
        {
            int start1 = Convert.ToInt32(rhs.TimeSlotStart);
            int end1 = Convert.ToInt32(rhs.TimeSlotEnd);

            int start2 = Convert.ToInt32(lhs.TimeSlotStart);
            int end2 = Convert.ToInt32(lhs.TimeSlotEnd);
            
            if (start1 < start2 + (end2 - start2) &&
                start1 + (end1 - start1) > start2)
                return true;


            return false;
        }

        public bool DropCourse(Course course)
        {
            return student.Person.Subjects.Remove(course);
        }
    }
}
