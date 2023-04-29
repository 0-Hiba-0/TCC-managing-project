using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Models;
using ConsoleApp12.Data;
using Microsoft.EntityFrameworkCore;
//using System.EntityFrameworkCore.ChangeTracking.EntityEntry;

namespace ConsoleApp12.Controllers
{
   
  //  public virtual Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Update(object entity);
    internal class StudentController
        {

        TccsysDbContext context = new TccsysDbContext();

        public string? UserName { get; private set; }

        public void Index() {
           
            var students = context.Students.OrderBy(std => std.FirstName);
              List<Student> std1 = context.Students.ToList();
                Console.WriteLine("1.Id\t2.User Name\t3.First Name\t4.Last Name\t5.Email\t6.Phone\t7.Registration Date\t8.Deptno");
            foreach (Student item in students)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", item.StudentId+ "\t|", item.UserName + "\t|",
                                                     item.FirstName + "\t\t|", item.LastName + "\t|", item.Email + "\t\t|", item.Phone + "\t|"
                                                    , item.DepartmentId + "\t|", item.RegisterDate);
            }
        }
        public void Up()
        {
            context.Update(new Student { FirstName = "h", LastName = "oooo", Email = "llopke;", Phone = "092347587111222", RegisterDate = 901, DepartmentId = 3 });
            context.SaveChanges();
        }
            public void CreateStudent()
            {
            Student std = new Student();
            Console.Write("User Name: ");
            std.UserName = Console.ReadLine();
            Console.Write("First Name : ");
            std.FirstName = Console.ReadLine();
            Console.Write("Last Name : ");
            std.LastName = Console.ReadLine();
            Console.Write("Email : ");
            std.Email = Console.ReadLine();
            Console.Write("Phone : ");
            std.Phone = Console.ReadLine();
            Console.Write("Department Id : \n You can Choose one of these id's:\t");
            List<Department> dept = context.Departments.ToList();
            foreach (Department item in dept)
            {
                Console.Write(item.DepartmentId + "  ");
            }
            std.DepartmentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Registration Date : ");
            std.RegisterDate = Convert.ToInt32(Console.ReadLine());
            context.Add(std);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        public void Search(int x)
        {
            var results = new TccsysDbContext();
                List<Student> std = results.Students.ToList();
            int a;
            string str ; ConsoleColor gray;
            try
                {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Student item in std)
                        {
                            if (item.StudentId == a)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 2:
                        Console.Write("User Name: ");
                        str = Console.ReadLine();
                        foreach (Student item in std)
                        {
                            if (item.UserName == str)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 3:
                        Console.Write("Fisrt Name: ");
                        str = Console.ReadLine();
                        foreach (Student item in std)
                        {
                            if (item.FirstName == str)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 4:
                        gray = ConsoleColor.Cyan;
                        Console.Write("Last Name: ");
                        str = Console.ReadLine();
                        foreach (Student item in std)
                        {
                            if (item.LastName == str)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 5:
                         gray = ConsoleColor.DarkGray;
                        Console.Write("Email: ");
                        str = Console.ReadLine();
                        foreach (Student item in std)
                        {
                            if (item.Email == str)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 6:
                         gray = ConsoleColor.DarkYellow;
                        Console.Write("Phone: ");
                        str = Console.ReadLine();
                        foreach (Student item in std)
                        {
                            if (item.Phone == str)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 7:
                         gray = ConsoleColor.DarkMagenta;
                        int? l = 0;
                        Console.Write("Department Id : \n You can Choose one of these id's:\t");
                        List<Department> dept = context.Departments.ToList();
                        foreach (Department item in dept)
                        {
                            Console.Write(item.DepartmentId + "  ");
                        }
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("1.Choose Term? \t2.Do not Choose Term");
                       int aa = Convert.ToInt32(Console.ReadLine());
                        switch (aa)
                        {
                            case 1:
                                List<Subject> ss = context.Subjects.Where(e=>e.DepartmentId==a).ToList();
                                int y;
                                if (ss != null)
                                {
                                    Console.WriteLine("Choose Year?1.Yes\n2.No");
                                    int k = Convert.ToInt32(Console.ReadLine());
                                    switch (k)
                                    {
                                        case 1:
                                            Console.WriteLine("Which Year?\nHere are the years you can choose..");
                                            foreach (Subject item in ss)
                                            {
                                                Console.Write("{0} ", item.SubjectYear);
                                            }
                                            y = Convert.ToInt32(Console.ReadLine());
                                         ss = context.Subjects.Where(e => e.SubjectYear == y).ToList();
                                            break;
                                        case 2:

                                            break;
                                    }
                                    foreach (Subject item in ss)
                                    {
                                        Console.Write("{0} ", item.Term);
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Choose one..");
                                    aa = Convert.ToInt32(Console.ReadLine());
                                }
                                else
                                {
                                    Console.WriteLine("No Subjects Found here");
                                }
                                break;
                            case 2:
                                break;
                        }
                        foreach (Student item in std)
                        {
                            context.Subjects.Where(e => e.Term == aa);
                            if (item.DepartmentId == a)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 8:
                        Console.Write("Registration Date: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Student item in std)
                        {
                            if (item.RegisterDate == a)
                                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}| {7}", item.StudentId, item.UserName,
                                                                   item.FirstName, item.LastName, item.Email, item.Phone
                                                                   , item.DepartmentId, item.RegisterDate);
                        }
                        break;
                    case 9:
                        Console.WriteLine("Exam: \nWrite exam Id");
                        List<Exam> exm = context.Exams.ToList();
                        foreach (Exam item in exm)
                        {
                            Console.Write("{0} ",item.ExamId);
                        }
                        Console.Write(" : ");
                        int b = int.Parse(Console.ReadLine());
                        Console.Write("Find Students Who: \n1.Did Exam\t2.Do not Do Exam\n");
                        a = Convert.ToInt32(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                        List<StudentMark> e = context.StudentMarks.Where(e => e.ExamId==b).ToList();
                                foreach (StudentMark item in e)
                                {
                                    Console.Write("{0}   ", item.StudentId);
                                }
                                break;
                            case 2:
                                Console.WriteLine();
                                List<StudentMark> ee = context.StudentMarks.Where(e => e.ExamId != b).ToList();
                                foreach (StudentMark item in ee)
                                {
                                    Console.Write("{0}  ", item.StudentId);
                                }
                                break;
                        }
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        int? ll = 0;
                        Console.WriteLine("Which student?");
                        List<Student> stdd = context.Students.ToList();
                        foreach (Student item in stdd)
                        {
                            Console.Write("{0} ", item.StudentId);
                        }
                        int id = Convert.ToInt32(Console.ReadLine());
                        List<StudentMark> mrk = context.StudentMarks.Where(e => e.StudentId == id).ToList();
                        foreach (StudentMark item in mrk)
                        {
                            ll += item.Markk;
                        }
                        Console.WriteLine("Student's {0} Average: {1}", id, ll / mrk.Count());
                        break;
                        context.SaveChanges();
                        Console.WriteLine("Done!");
                }
            }
                catch (Exception)
                {
                    Console.WriteLine("Error Happen");
                    throw;
                }
        }
        public void Delete(int x)
        {
            int a;
            string str;
            switch (x)
            {
                case 1:
                    a = Convert.ToInt32(Console.ReadLine());
                var s1=   context.Students.Where(std => std.StudentId == a).FirstOrDefault();
                    if (s1 is Student)
                    {
                        context.Students.Remove(s1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;

                case 2:
                    str = Console.ReadLine();
                  var  s2 = context.Students.Where(std => std.UserName ==str).FirstOrDefault();
                    if (s2 is Student)
                    {
                        context.Remove(s2);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 3:
                    str = Console.ReadLine();
                    var s3 = context.Students.Where(std => std.FirstName == str).FirstOrDefault();
                    if (s3 is Student)
                    {
                        context.Remove(s3);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 4:
                    str = Console.ReadLine();
                    var s4 = context.Students.Where(std => std.LastName == str).FirstOrDefault();
                    if (s4 is Student)
                    {
                        context.Remove(s4);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 5:
                    str = Console.ReadLine();
                    var s5 = context.Students.Where(std => std.Email == str).FirstOrDefault();
                    if (s5 is Student)
                    {
                        context.Remove(s5);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 6:
                    str = Console.ReadLine();
                    var s6 = context.Students.Where(std => std.Phone == str).FirstOrDefault();
                    if (s6 is Student)
                    {
                        context.Remove(s6);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 7:
                    a = Convert.ToInt32(Console.ReadLine());
                    var s7 = context.Students.Where(std => std.DepartmentId == a).FirstOrDefault();
                    
                    if (s7 is Student)
                    {
                        context.Remove(s7);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 8:
                    a = Convert.ToInt32(Console.ReadLine());
                    var s8 = context.Students.Where(std => std.RegisterDate == a).FirstOrDefault();
                    if (s8 is Student)
                    {
                        context.Remove(s8);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;


            }
            context.SaveChanges();
        }
        public void Updatee(int x)
        {
            Console.WriteLine("Update Student Info..\n");
            Search(x);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1.User Name\t2.First Name\t3.Last Name\t4.Email\t5.Phone\t6.Deptno");
            int srch = Convert.ToInt32(Console.ReadLine());
            int id; string str; Student student;
            switch (srch)
            {
                case 1:
                    Console.WriteLine("Re_insert student id bitte ");
                     id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("insert new User Name");
                    student = context.Students.SingleOrDefault(std => std.StudentId == id);
                     str = Console.ReadLine();
                    student.UserName = str;
                    
                    context.SaveChanges();
                    break;
                case 2:
                    Console.WriteLine("Re_insert student id bitte ");
                     id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("insert new First Name");
                     student = context.Students.SingleOrDefault(std => std.StudentId == id);
                     str  = Console.ReadLine();
                    student.FirstName = str;

                    context.SaveChanges();
                    break;

                case 3:
                    Console.WriteLine("Re_insert student id bitte ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("insert new Last Name");
                    student = context.Students.SingleOrDefault(std => std.StudentId == id);
                    str = Console.ReadLine();
                    student.LastName = str;

                    context.SaveChanges();
                    break;
                case 4:
                    Console.WriteLine("Re_insert student id bitte ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("insert new Email");
                    student = context.Students.SingleOrDefault(std => std.StudentId == id);
                    str = Console.ReadLine();
                    student.Email = str;
                    context.SaveChanges();
                    break;

                case 5:
                    Console.WriteLine("Re_insert student id bitte ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("insert new Pone");
                    student = context.Students.SingleOrDefault(std => std.StudentId == id);
                    str = Console.ReadLine();
                    student.Phone = str;
                    context.SaveChanges();
                    break;
                case 6:
                    Console.WriteLine("Re_insert student id bitte ");
                    id = Convert.ToInt32(Console.ReadLine());
                    student = context.Students.SingleOrDefault(std => std.StudentId == id);
                    Console.Write("Department Id : \n You can Choose one of these id's:\t");
                    List<Department> dept = context.Departments.ToList();
                    foreach (Department item in dept)
                    {
                        Console.Write(item.DepartmentId + "  ");
                    }
                   int i =Convert.ToInt32( Console.ReadLine());
                    student.DepartmentId = i;
                    context.SaveChanges();
                    break;




            }
        }
            
        
        public void Update3(int x)
        {
            //   var stud = new Student() {  };
            //  stud.UserName = Console.ReadLine();
            // string str = stud.UserName;
            //  var context = new TccsysDbContext() ;

            //   var entity = context.Students.FirstOrDefault(item => item.UserName == stud.UserName);
            //  entity.UserName = stud.UserName;
            Console.WriteLine("Student Info..\n");
            Search(x);
            var results = new TccsysDbContext();
            Console.WriteLine("What variable U want to Update?");
            Console.WriteLine("1.User Name\t2.First Name\t3.Last Name\t4.Email\t5.Phone\t6.Deptno");
            int srch = Convert.ToInt32(Console.ReadLine());
            var entity = context.Students.Where(item => item.StudentId == x);
        }
       
        public async void Update2(int x)
        {

            //var app = builder.Build();
            Console.WriteLine("Student Info..\n");
            Search(x);
            var results = new TccsysDbContext();
            Console.WriteLine("What variable U want to Update?");
            Console.WriteLine("1.User Name\t2.First Name\t3.Last Name\t4.Email\t5.Phone\t6.Deptno");
            int srch = Convert.ToInt32(Console.ReadLine());
            var entity = context.Students.FirstOrDefault(item => item.StudentId == x);
            if(entity!=null)
                switch (srch)
                {
                    
                    case 1:
                        entity.UserName = Console.ReadLine();
                        context.SaveChanges();
                        break;
                    case 2:
                        string str1 = Console.ReadLine();
                        var existingstudent = context.Students.Update(entity).Entity;
                        existingstudent.FirstName = Console.ReadLine();

                        context.SaveChanges();
                        Console.WriteLine(  "Updated Successfully");
                        break;
                    case 3:
                        entity.LastName = Console.ReadLine();
                        context.SaveChanges();
                        break;
                    case 4:
                        entity.Email = Console.ReadLine();
                        context.SaveChanges();
                        break;
                    case 5:
                        entity.Phone = Console.ReadLine();
                        context.SaveChanges();
                        break;
                    case 6:
                        entity.DepartmentId =Convert.ToInt32( Console.ReadLine());
                        context.SaveChanges();
                        break;
            }
            
                   
        }
        
        


        }
    
}
