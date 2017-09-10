using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.People
{
    public class Professor
    {
       
        public int ProfessorID { get; set; }

        public virtual Person Person { get; set; }
        //public virtual Course Teaching { get; set; }

        //public Professor()
        //{
        //    Person = new Person();
        //}

    }
}
