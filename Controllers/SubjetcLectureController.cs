using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Models;
using ConsoleApp12.Data;
namespace ConsoleApp12.Controllers
{
    internal class SubjetcLectureController
    {
        TccsysDbContext context = new TccsysDbContext();
        public void Index()
        {
           
            var sbjlecture = context.SubjectLectures.OrderBy(std => std.SubjectId);
            List<SubjectLecture> std1 = context.SubjectLectures.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Title\t4.Content");
            foreach (SubjectLecture item in sbjlecture)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.SubjectLectureId + "\t", item.SubjectId + "\t|",
                                                     item.Title + "\t|", item.Context);
            }
        }

        public void Create()
        {
            SubjectLecture subject = new SubjectLecture();
            Console.Write("Subject Id : \n You can Choose one of these id's:\t");
            List<Subject> subjects = context.Subjects.ToList();
            foreach (Subject item in subjects)
            {
                Console.Write(item.SubjectId + "  ");
            }
            Console.WriteLine();
            subject.SubjectId =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lecture Title: ");
            subject.Title = Console.ReadLine();

            Console.WriteLine("Lecture Content: ");
            subject.Context= Console.ReadLine();

            context.Add(subject);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        public void Search(int x)
        {
            var subject = context.SubjectLectures.OrderBy(std => std.SubjectLectureId);
            List<SubjectLecture> std1 = context.SubjectLectures.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Title\t4.Content\t5.Subject Lectures Count");

            int a;

            string str;
            try
            {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (SubjectLecture item in subject)
                        {
                            if (item.SubjectLectureId == a)
                                Console.WriteLine("{0} {1} {2} {3}", item.SubjectLectureId + "\t", item.SubjectId + "\t|",
                                                    item.Title + "\t|", item.Context);
                        }
                        break;
                    case 2:

                        Console.Write("Subject Id : \n You can Choose one of these id's:\t");
                        List<Subject> subjects = context.Subjects.ToList();
                        foreach (Subject item in subjects)
                        {
                            Console.Write(item.SubjectId + "  ");
                        }
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (SubjectLecture item in subject)
                        {
                            if (item.SubjectId == a)
                                Console.WriteLine("{0} {1} {2} {3}", item.SubjectLectureId + "\t", item.SubjectId + "\t|",
                                                     item.Title + "\t|", item.Context);
                        }

                        break;
                    case 3:
                        Console.Write("Title: ");
                        str = Console.ReadLine();
                        foreach (SubjectLecture item in subject)
                        {
                            if (item.Title == str)
                                Console.WriteLine("{0} {1} {2} {3}", item.SubjectLectureId + "\t", item.SubjectId + "\t|",
                                                    item.Title + "\t|", item.Context);
                        }
                        break;
                    case 4:
                        Console.Write("Content: ");
                        str = Console.ReadLine();
                        foreach (SubjectLecture item in subject)
                        {
                            if (item.Context == str)
                                Console.WriteLine("{0} {1} {2} {3}", item.SubjectLectureId + "\t", item.SubjectId + "\t|",
                                                    item.Title + "\t|", item.Context);
                        }
                        break;
                    
                    case 5:
                        Console.WriteLine("Find Lectures Number Depending on:\n1.Subject Id\t2.Year\t3.Department\t4.Term ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        int? l =0;
                        int id;
                             List<Subject> std = context.Subjects.ToList();
                             List<SubjectLecture> mrk;
                             List<Department> dept= context.Departments.ToList();
                        switch (c)
                        {
                               case 1:
                                Console.WriteLine("Which Subject?");
                                foreach (Subject item in std)
                                {
                                    Console.Write("{0} ", item.SubjectId);
                                }
                                 id = Convert.ToInt32(Console.ReadLine());
                                 mrk = context.SubjectLectures.Where(e => e.SubjectLectureId == id).ToList();
                                foreach (SubjectLecture item in mrk)
                                {
                                    l++;
                                }
                                Console.WriteLine("Number of lectures: "+l);
                                l = 0;
                                break;

                            case 2:
                                Console.WriteLine("Which Year?");
                               
                                foreach (Subject item in std)
                                {
                                    Console.Write("{0} ", item.SubjectYear);
                                }
                               id = Convert.ToInt32(Console.ReadLine());
                               std= context.Subjects.Where(e => e.SubjectYear == id).ToList();
                                foreach (Subject item in std)
                                {
                                    l++;
                                }
                                Console.WriteLine("Number of lectures: " + l);
                                l = 0;
                                break;

                            case 3:
                                Console.WriteLine("Which Department?");

                                foreach (Department item in dept)
                                {
                                    Console.Write("{0} ", item.DepartmentId);
                                }
                                id = Convert.ToInt32(Console.ReadLine());

                                foreach (Subject item in std)
                                {
                                    if(item.DepartmentId==id)
                                    l++;
                                }
                                Console.WriteLine("Number of lectures: " + l);
                                l = 0;
                                break;
                            case 4:
                                Console.WriteLine("Which Term?");

                                foreach (Subject item in std)
                                {
                                    Console.Write("{0} ", item.Term);
                                }
                                id = Convert.ToInt32(Console.ReadLine());
                                std = context.Subjects.Where(e => e.Term == id).ToList();
                                foreach (Subject item in std)
                                {
                                    l++;
                                }
                                Console.WriteLine("Number of lectures: " + l);
                                l = 0;
                                break;
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
        public void Update(int xx)
        {
            Console.WriteLine("Update Student Info..\n");
            Search(xx);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1.Subject Id\t2.Title\t3.Content");
            int srch = Convert.ToInt32(Console.ReadLine());
            int id; string str; SubjectLecture subject; int x;
            Console.WriteLine("Re_insert subject id bitte ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert new Subject Name");
            subject = context.SubjectLectures.SingleOrDefault(std => std.SubjectLectureId == id);
            switch (srch)
            {
                case 1:
                    Console.Write("Subject Ids' : \n You can Choose one of these id's:\t");
                    List<Subject> sl = context.Subjects.ToList();
                    foreach (Subject item in sl)
                    {
                        Console.Write(item.SubjectId + "  ");
                    }
                    x = Convert.ToInt32(Console.ReadLine());
                    subject.SubjectId = x;
                    context.SaveChanges();
                    break;
                case 2:
                    str = Console.ReadLine();
                    subject.Title = str;
                    context.SaveChanges();
                    break;

                case 3:
                    str = Console.ReadLine();
                    subject.Context = str;
                    context.SaveChanges();
                    break;
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
                    var s1 = context.SubjectLectures.Where(sb => sb.SubjectLectureId == a).FirstOrDefault();
                    if (s1 is SubjectLecture)
                    {
                        context.SubjectLectures.Remove(s1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;

                case 2:
                    a = Convert.ToInt32(Console.ReadLine());
                    var d1 = context.SubjectLectures.Where(sb => sb.SubjectId == a).FirstOrDefault();
                    if (d1 is SubjectLecture)
                    {
                        context.SubjectLectures.Remove(d1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 3:
                    str = Console.ReadLine();
                    var s2 = context.SubjectLectures.Where(std => std.Title == str).FirstOrDefault();
                    if (s2 is SubjectLecture)
                    {
                        context.Remove(s2);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 4:
                    str = Console.ReadLine();
                    var ctnt = context.SubjectLectures.Where(std => std.Context == str).FirstOrDefault();
                    if (ctnt is SubjectLecture)
                    {
                        context.Remove(ctnt);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
            }
            context.SaveChanges();
        }
    }
}
