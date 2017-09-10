using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.People
{
    public class Student
    {
        public int StudentID { get; set; }

        public virtual Person Person {get; set;}
        

        //public Student()
        //{
        //    Subjects = new HashSet<Course>();
        //}
    }
}
