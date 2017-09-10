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

            //ef.Codefirstcrap();
            //ef.AddCourses();

            var stu = ef.GetStudent("Jessica John");
            stu.Person.Subjects.Add(ef.GetCourse("Gym"));
            stu.Person.Subjects.Add(ef.GetCourse("Art"));
            ef.SaveChanges();
        }
    }
}
