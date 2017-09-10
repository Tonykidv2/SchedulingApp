using LibraryCode.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCode.Src
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public virtual Person mOwner { get; set; }
    }
}
