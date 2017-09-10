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

            //ef.Codefirstcrap();
            //ef.AddCourses();

            //adding courses to student
            //var stu = ef.GetStudent("Jessica John");
            //stu.Person.Subjects.Add(ef.GetCourse("Gym"));
            //stu.Person.Subjects.Add(ef.GetCourse("Art"));
            //ef.UpdateStudent(stu);

            var p = new Person() { FirstName = "To", LastName = "Delete", FullTime = true, Username = "User", Password = "Pass" };

            ef.AddStudent(p);
            ef.RemoveStudent("To Delete");
        }
    }
}
