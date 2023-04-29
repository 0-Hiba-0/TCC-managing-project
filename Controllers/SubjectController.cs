using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Models;
using ConsoleApp12.Data;
namespace ConsoleApp12.Controllers
{
    internal class SubjectController
    {
        TccsysDbContext context = new TccsysDbContext();
        public void Index()
        {
            var subject = context.Subjects.OrderBy(std => std.SubjectId);
            List<Subject> std1 = context.Subjects.ToList();
            Console.WriteLine("1.Id\t2.Department Id\t3.Subject Name\t4.Minimun Degree\t5.Term\t6.Year");
            foreach (Subject item in subject)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                     item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term,item.SubjectYear);
            } 
        }

        public void Create()
        {
            Subject sbj = new Subject();
            Console.Write("Department Id : \n You can Choose one of these id's:\t");
            List<Subject> subjects = context.Subjects.ToList();
            var subject = context.Subjects.OrderBy(std => std.DepartmentId);
            foreach (Subject item in subject)
            {
                Console.Write(item.DepartmentId);
            }
            sbj.DepartmentId =Convert.ToInt32(Console.ReadLine());


            Console.Write("Subject Name : ");
            sbj.SubjectName = Console.ReadLine();

            Console.Write("Minimum Degree : ");
            sbj.MinimumDegree =Convert.ToInt32( Console.ReadLine());

            Console.Write("Term : ");
            sbj.Term = Convert.ToInt16(Console.ReadLine());

            Console.Write("Year : ");
            sbj.SubjectYear = Convert.ToInt16(Console.ReadLine());
            context.Add(sbj);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        public void Update(int xx)
        {
            Console.WriteLine("Update Student Info..\n");
            Search(xx);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1.Subject Name\t2.Minimum Degree\t3.Term\t4.Year");
            int srch = Convert.ToInt32(Console.ReadLine());
            int id; string str; Subject subject;int x;
            Console.WriteLine("Re_insert subject id bitte ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert new Subject Name");
            subject = context.Subjects.SingleOrDefault(std => std.SubjectId == id);
            switch (srch)
            {
                case 1:
                    str = Console.ReadLine();
                    subject.SubjectName = str;
                    context.SaveChanges();
                    
                    break;
                case 2:
                    x = Convert.ToInt32(Console.ReadLine());
                    subject.MinimumDegree = x;
                    context.SaveChanges();
                    break;
                case 3:
                    x = Convert.ToInt16(Console.ReadLine());
                    subject.Term =(short?) x;
                    context.SaveChanges();
                    break;
                case 4:
                    x = Convert.ToInt16(Console.ReadLine());
                    subject.SubjectYear = (short?)x;
                    context.SaveChanges();
            Console.WriteLine("Done!");
                    break;
            }
        }
            public void Search(int x)
        {
            var subject = context.Subjects.OrderBy(std => std.SubjectId);
            List<Subject> std1 = context.Subjects.ToList();
            int a;string str;
            try
            {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        foreach (Subject item in subject)
                        {
                            Console.Write("{0} ", item.SubjectId);

                        }
                        Console.Write(" : ");

                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Subject item in subject)
                        {
                            if (item.SubjectId == a)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                       item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);
                        }
                        break;
                    case 2:

                        Console.Write("Dept Id: ");

                        List<Department> dept = context.Departments.ToList();
                        foreach (Department item in dept)
                        {
                            Console.Write("{0} ",item.DepartmentId);
                        }
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Subject item in subject)
                        {
                            if (item.DepartmentId == a)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                      item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);
                        }

                        break;
                    case 3:
                        Console.Write("Subject Name: ");
                        foreach (Subject item in subject)
                        {
                            Console.Write("{0} ", item.SubjectName);

                        }
                        Console.Write(" : ");
                        str = Console.ReadLine();
                        foreach (Subject item in subject)
                        {
                            if (item.SubjectName == str)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                      item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);
                        }
                        break;
                    case 4:
                        Console.Write("Minimum Degree: ");
                        foreach (Subject item in subject)
                        {
                            Console.Write("{0} ", item.MinimumDegree);

                        }
                        Console.Write(" : ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Subject item in subject)
                        {
                            if (item.MinimumDegree == a)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                      item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);
                        }
                        break;
                    case 5:
                        Console.Write("Choose Term: ");
                        foreach (Subject item in subject)
                        {
                            Console.Write("{0} ", item.Term);

                        }
                        Console.Write(" : ");

                        a = Convert.ToInt16(Console.ReadLine());
                        foreach (Subject item in subject)
                        {
                            if (item.Term == a)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                      item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);
                            
                        }
                        break;
                    case 6:
                        Console.Write("Choose Year: ");
                        foreach (Subject item in subject)
                        {
                                Console.Write("{0} ",  item.SubjectYear);

                        }
                        Console.Write(" : ");
                        a = Convert.ToInt16(Console.ReadLine());
                        foreach (Subject item in subject)
                        {
                            if (item.SubjectYear == a)
                                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", item.SubjectId + "\t", item.DepartmentId + "\t\t|  ",
                                                      item.SubjectName + "\t\t|  ", item.MinimumDegree + "\t\t\t| ", item.Term, item.SubjectYear);

                        }
                        break;
                    

                    
                }
                context.SaveChanges();
                Console.WriteLine("Done!");

            }
            catch (Exception)
            {
                Console.WriteLine("Not Found");
                throw;
            }
        }

        public void Delete(int x)
        {
            //var Hibaa = context.Students;
            int a;
            string str;
            switch (x)
            {
                case 1:
                    a = Convert.ToInt32(Console.ReadLine());
                    var s1 = context.Subjects.Where(sb => sb.SubjectId == a).FirstOrDefault();
                    if (s1 is Subject)
                    {
                        context.Subjects.Remove(s1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;

                case 2:
                    a = Convert.ToInt32(Console.ReadLine());
                    var d1 = context.Subjects.Where(sb => sb.DepartmentId == a).FirstOrDefault();
                    if (d1 is Subject)
                    {
                        context.Subjects.Remove(d1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 3:
                    str = Console.ReadLine();
                    var s2 = context.Subjects.Where(std => std.SubjectName == str).FirstOrDefault();
                    if (s2 is Subject)
                    {
                        context.Remove(s2);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 4:
                    a = Convert.ToInt32(Console.ReadLine());
                    var m1 = context.Subjects.Where(sb => sb.MinimumDegree == a).FirstOrDefault();
                    if (m1 is Subject)
                    {
                        context.Subjects.Remove(m1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 5:
                    a = Convert.ToInt32(Console.ReadLine());
                    var term = context.Subjects.Where(sb => sb.Term == a).FirstOrDefault();
                    if (term is Subject)
                    {
                        context.Subjects.Remove(term);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 6:
                    a = Convert.ToInt32(Console.ReadLine());
                    var y = context.Subjects.Where(sb => sb.SubjectYear == a).FirstOrDefault();
                    if (y is Subject)
                    {
                        context.Subjects.Remove(y);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
            }
            context.SaveChanges();
        }

    }
}
