using LibraryCode.People;
using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            TEST();
        }

        public static void TEST()
        {
            var ef = new EntityFramework();

        }

        public static bool CheckTimeConflict(Course rhs, Course lhs)
        {
            int start1 = Convert.ToInt32(rhs.TimeSlotStart);
            int end1 = Convert.ToInt32(rhs.TimeSlotEnd);

            int start2 = Convert.ToInt32(lhs.TimeSlotStart);
            int end2 = Convert.ToInt32(lhs.TimeSlotEnd);

            //if (start1 == start2)
            //    return true;
            if (start1 < start2 + (end2 - start2) &&
                start1 + (end1 - start1) > start2)
                return true;


            return false;
        }
    }
}
