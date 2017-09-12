using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCode.People;
using Microsoft.SqlServer;
using System.Data.Entity;

namespace LibraryCode.Src
{
    public class EntityFramework : DbContext
    {
        public DbSet<TestCodeFirst> TestCodeFirsts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Registar> Registars { get; set; }
        public DbSet<Course> Courses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Server=tcp:anthonysqlserver.database.windows.net,1433;Initial Catalog=AnthonySQLServer;Persist Security Info=False;User ID=adminsql;Password=123!@#qwe;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    //builder.UseSqlServer("Server=anthonysqlserver.database.windows.net;Database=AnthonySQLServer;user id=adminsql;password=123!@#qwe");
        //}
        public EntityFramework() : base("Server=tcp:anthonysqlserver.database.windows.net,1433;Initial Catalog=AnthonySQLServer;Persist Security Info=False;User ID=adminsql;Password=123!@#qwe;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().
                            HasMany(c => c.Enrolled).
                            WithMany(p => p.Subjects).
                            Map(
                                m =>
                                {
                                    m.MapLeftKey("CourseID");
                                    m.MapRightKey("PersonID");
                                    m.ToTable("PersonCourses");
                                }
                          );
        }

        public void Codefirstcrap()
        {
            //var ef = new EntityFramework();

            var p = new Person(){ FirstName = "Jessica", LastName = "John", FullTime = true, Username = "User", Password = "Pass"};
            var s = new Student(){ Person = p };
            //var t = new TestCodeFirst() { Name = "test123" };
            //TestCodeFirsts.Add(t);
            Students.Add(s);
            SaveChanges();

            //var people = TestCodeFirsts.ToList();
            //Console.WriteLine(people.First().Name);
        }

        public void AddCourse(Course _course)
        {
            //var Gymcourse = new Course() { Name = "Gym", CreditHours = 4, TimeSlotStart = "0500", TimeSlotEnd = "0900", MaxStudents = 20 };
            //var Physic = new Course() { Name = "Physic", CreditHours = 4, TimeSlotStart = "1000", TimeSlotEnd = "1400", MaxStudents = 20 };
            //var ArtCourse = new Course() { Name = "Art", CreditHours = 4, TimeSlotStart = "1500", TimeSlotEnd = "1900", MaxStudents = 20 };
            //var ProgrammingCourse = new Course() { Name = "Programming", CreditHours = 4, TimeSlotStart = "2000", TimeSlotEnd = "2400", MaxStudents = 20 };

            //Courses.Add(Gymcourse);
            //Courses.Add(Physic);
            //Courses.Add(ArtCourse);
            //Courses.Add(ProgrammingCourse);
            Courses.Add(_course);
            SaveChanges();
        }

        public void RemoveCourse(string _course)
        {
            var tobedeleted = Courses.First(p => p.Name == _course);
            if(tobedeleted != null)
            {
                Courses.Remove(tobedeleted);
                SaveChanges();
            }
        }

        public void UpdateCourse(Course _course)
        {
            var tobeupdated = Courses.First(p => p.CourseID == _course.CourseID);
            if(tobeupdated != null)
            {
                tobeupdated.CreditHours = _course.CreditHours;
                tobeupdated.Enrolled = _course.Enrolled;
                tobeupdated.MaxStudents = _course.MaxStudents;
                tobeupdated.Name = _course.Name;
                tobeupdated.TimeSlotEnd = _course.TimeSlotEnd;
                tobeupdated.TimeSlotStart = _course.TimeSlotStart;

                SaveChanges();
            }
        }

        public Course GetCourse(string name)
        {
            return Courses.First(p => p.Name == name);
        }

        public void UpdateStudent(Student _student)
        {
            var tobeupdated = Students.First(p => p.StudentID == _student.StudentID);
            if(tobeupdated != null)
            {
                tobeupdated.Person = _student.Person;
            
                SaveChanges();
            }
        }

        public void RemoveStudent(string _name)
        {

            var tobedeleted = Students.First(p => p.Person.FirstName + " " + p.Person.LastName == _name);
            if(tobedeleted != null)
            {
                Persons.Remove(tobedeleted.Person);
                Students.Remove(tobedeleted);
                SaveChanges();
            }
        }

        public void AddStudent(Person _student)
        {
            Students.Add(new Student() { Person = _student });
            SaveChanges();
        }

        public Student GetStudent(string name)
        {
            Student result = Students.First(p => p.Person.FirstName + " " + p.Person.LastName == name);

            return result;
        }

        public Professor GetProfessor(string name)
        {
            Professor result = Professors.First(p => p.Person.FirstName + " " + p.Person.LastName == name);

            return result;
        }

        public void UpdateProfessor(Professor professor)
        {
            var tobeupdated = Professors.First(p => p.ProfessorID == professor.ProfessorID);
            if (tobeupdated != null)
            {
                tobeupdated.Person = professor.Person;

                SaveChanges();
            }
        }
        public void RemoveProfessor(string _name)
        {
            var tobedeleted = Professors.First(p => p.Person.FirstName + " " + p.Person.LastName == _name);
            if (tobedeleted != null)
            {
                Persons.Remove(tobedeleted.Person);
                Professors.Remove(tobedeleted);
                SaveChanges();
            }
        }

        public Registar GetRegistar(string name)
        {
            Registar result = Registars.First(p => p.Person.FirstName + " " + p.Person.LastName == name);

            return result;
        }

        public void UpdateRegistar(Registar reg)
        {
            var tobeupdated = Registars.First(p => p.RegistarID == reg.RegistarID);
            if (tobeupdated != null)
            {
                tobeupdated.Person = reg.Person;

                SaveChanges();
            }
        }
        public void RemoveRegistar(string _name)
        {
            var tobedeleted = Registars.First(p => p.Person.FirstName + " " + p.Person.LastName == _name);
            if (tobedeleted != null)
            {
                Persons.Remove(tobedeleted.Person);
                Registars.Remove(tobedeleted);
                SaveChanges();
            }
        }

        public Student GetStudent(string _username, string _pass)
        {
            Student result = null;
            try
            {
                result = Students.First(p => p.Person.Username == _username && p.Person.Password == _pass);
            }
            catch
            {

                return null;
            }            
            return result;
        }
        public Professor GetProfessor(string _username, string _pass)
        {
            Professor result = null;
            try
            {
                result = Professors.First(p => p.Person.Username == _username && p.Person.Password == _pass);
            }
            catch
            {

                return null;
            }
            return result;
        }
        public Registar GetRegistar(string _username, string _pass)
        {
            Registar result = null;
            try
            {
                result = Registars.First(p => p.Person.Username == _username && p.Person.Password == _pass);
            }
            catch
            {
                return null;
            }
            return result;
        }
    }
}
