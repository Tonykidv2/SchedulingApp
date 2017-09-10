using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.People
{
    public class Registar
    {
        public int RegistarID { get; set; }

        public virtual Person Person { get; set; }

        public Registar()
        {
            Person = new Person();
        }
    }
}
