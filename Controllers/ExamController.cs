using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Models;
using ConsoleApp12.Data;
using System.Globalization;

namespace ConsoleApp12.Controllers
{
    internal class ExamController
    {
        TccsysDbContext context = new TccsysDbContext();
        public void Index()
        {
            using TccsysDbContext context = new TccsysDbContext();
            var exam = context.Exams.OrderBy(std => std.ExamId);
            List<Exam> exm = context.Exams.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Date\t4.Term");
            foreach (Exam item in exam)
            {
                Console.WriteLine("{0} {1} {2} {3} ", item.ExamId + "\t", item.SubjectId + "\t|",
                                                     item.Date + "\t|", item.Term);
            }
        }


        public void Create()
        {
            Exam exm = new Exam();
            Console.Write("Subject Id : \n You can Choose one of these id's:\t");
            List<Subject> subjects = context.Subjects.ToList();
            foreach (Subject item in subjects)
            {
                Console.Write("{0} "+item.SubjectId+"  ");
            }
            exm. SubjectId= Convert.ToInt32(Console.ReadLine());
            Console.Write("Date: ");
          exm.Date=  Console.ReadLine();
            Console.Write("Term: ");
            exm.Term = Convert.ToInt16(Console.ReadLine());
            context.Add(exm);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        public void Search(int x)
        {
            var subject = context.Exams.OrderBy(std => std.ExamId);
            List<Exam> std1 = context.Exams.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Date\t4.Term");
            int a;string str;
            try
            {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Exam item in subject)
                        {
                            if (item.ExamId == a)
                                Console.WriteLine("{0} {1} {2} {3} ", item.ExamId + "\t", item.SubjectId + "\t|",
                                                     item.Date + "\t|", item.Term);
                        }
                        break;
                    case 2:
                        Console.Write("Subject Id : \t You can Choose one of these id's");
                        List<Exam> subjects = context.Exams.ToList();
                        foreach (Exam item in subjects)
                        {
                            Console.WriteLine(item.SubjectId + "\t,");
                                                    
                        }
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Exam item in subject)
                        {
                            if (item.SubjectId == a)
                                Console.WriteLine("{0} {1} {2} {3} ", item.ExamId + "\t", item.SubjectId + "\t|",
                                                     item.Date + "\t|", item.Term);
                        }
                        break;
                    case 3:
                        Console.Write("Date: ");
                        str = Console.ReadLine();
                        foreach (Exam item in subject)
                        {
                            if (item.Date == str)
                                Console.WriteLine("{0} {1} {2} {3} ", item.ExamId + "\t", item.SubjectId + "\t|",
                                                     item.Date + "\t|", item.Term);
                        }
                        break;
                    case 4:
                        Console.Write("Term: ");
                        a = Convert.ToInt16(Console.ReadLine());
                        foreach (Exam item in subject)
                        {
                            if (item.Term == a)
                                Console.WriteLine("{0} {1} {2} {3} ", item.ExamId + "\t", item.SubjectId + "\t|",
                                                     item.Date + "\t|", item.Term);
                        }
                        break;
                }
                context.SaveChanges();

            }
            catch (Exception)
            {
                Console.WriteLine("Not Found");
                throw;
            }
        }
        public void Update(int xx)
        {
            Console.WriteLine("Update Exam Info..\n");
            Search(xx);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1..Subject Id\t2.Date\t3.Term");
            int srch = Convert.ToInt32(Console.ReadLine());
            int id; string str; Exam exam; int x;
            Console.WriteLine("Re_insert subject id bitte ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert new Subject Name");
            exam = context.Exams.SingleOrDefault(std => std.ExamId == id);
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
                    exam.SubjectId = x;
                    context.SaveChanges();

                    break;
                case 2:
                    str=Console.ReadLine();
                    exam.Date = str;
                    context.SaveChanges();
                    break;
                case 3:
                    x = Convert.ToInt16(Console.ReadLine());
                    exam.Term = (short?)x;
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
                    var s1 = context.Exams.Where(sb => sb.ExamId == a).FirstOrDefault();
                    if (s1 is Exam)
                    {
                        context.Exams.Remove(s1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;

                case 2:
                    a = Convert.ToInt32(Console.ReadLine());
                    var d1 = context.Exams.Where(sb => sb.SubjectId == a).FirstOrDefault();
                    if (d1 is Exam)
                    {
                        context.Exams.Remove(d1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 3:
                    str = Console.ReadLine();
                    var s2 = context.Exams.Where(std => std.Date == str).FirstOrDefault();
                    if (s2 is Exam)
                    {
                        context.Remove(s2);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
                case 4:
                    a = Convert.ToInt16(Console.ReadLine());
                    var ctnt = context.Exams.Where(std => std.Term == a).FirstOrDefault();
                    if (ctnt is Exam)
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
