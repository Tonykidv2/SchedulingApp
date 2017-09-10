using LibraryCode.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.Src
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public string TimeSlotStart { get; set; }
        public string TimeSlotEnd { get; set; }
        public int MaxStudents { get; set; }

        public virtual ICollection<Person> Enrolled { get; set; }

        public Course()
        {
            Enrolled = new HashSet<Person>();
        }
    }
}
