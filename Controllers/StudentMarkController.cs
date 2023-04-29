using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Models;
using ConsoleApp12.Data;
namespace ConsoleApp12.Controllers
{
    internal class StudentMarkController
    {
        TccsysDbContext context = new TccsysDbContext();
        public void Index()
        {
            using TccsysDbContext context = new TccsysDbContext();
            var stdmarks = context.StudentMarks.OrderBy(std => std.StudentId);
            List<StudentMark> stdmrk1 = context.StudentMarks.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Exam Id\t4.Mark");
            foreach (StudentMark item in stdmarks)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.StudentMarkId + "\t", item.StudentId + "\t|",
                                                     item.ExamId + "\t|", item.Markk);
            }
        }
        public void Create()
        {
            StudentMark exm = new StudentMark();
            Console.Write("Student Id : \n You can Choose one of these id's:\t");
            List<Student> std = context.Students.ToList();
            foreach (Student item in std)
            {
                Console.Write(item.StudentId + "  ");
            }
            exm.StudentId = Convert.ToInt32(Console.ReadLine());



            Console.Write("Exam Id : \n You can Choose one of these id's:\t");
            List<Exam>? exam = context.Exams.ToList();
            foreach (Exam item in exam)
            {
                Console.Write(item.ExamId + "  ");
            }
            exm.ExamId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mark: ");
            //exm.Mark = Console.ReadLine();
            exm.Markk = int.TryParse(Console.ReadLine(), out int i) ? i : new int?();
           // exm.Markk = Convert.ToInt32(Console.ReadLine());
            context.Add(exm);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        private void Create2()
        {
            Console.WriteLine("1.Id\t2.Student Id\t3.Exam Id\t4.Mark");
            TccsysDbContext context = new TccsysDbContext();
            StudentMark studentMark = new StudentMark();

            Console.Write("Student Id: \t you can choose one of these id's");
            List<StudentMark> stdmrk1 = context.StudentMarks.ToList();
            var stdmarks = context.StudentMarks.OrderBy(std => std.StudentId);
            foreach (StudentMark item in stdmarks)
            {
                Console.WriteLine(item.StudentId);
            }
            studentMark.StudentMarkId = Convert.ToInt32(Console.ReadLine());

            List<StudentMark> stdmrk2 = context.StudentMarks.ToList();
            var stdmarks2 = context.StudentMarks.OrderBy(std => std.StudentId);
            foreach (StudentMark item in stdmarks2)
            {
                Console.WriteLine(item.ExamId);
            }
            studentMark.ExamId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mark: ");
           // studentMark.Markk = Console.ReadLine();
            
            context.Add(studentMark);
            context.SaveChanges();
        }

        public void Search(int x)
        {
            var subject = context.StudentMarks.OrderBy(std => std.StudentMarkId);
            List<StudentMark> std1 = context.StudentMarks.ToList();
            Console.WriteLine("1.Id\t2.Subject Id\t3.Exam Id\t4.Mark");

            int a;

            string str;
            try
            {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (StudentMark item in subject)
                        {
                            if (item.StudentMarkId == a)
                                Console.WriteLine("{0} {1} {2} {3}", item.StudentMarkId + "\t", item.StudentId + "\t|",
                                                    item.ExamId + "\t|", item.Markk);
                        }
                        break;
                    case 2:

                        Console.Write("Subject Id : \n You can Choose one of these id's:\t");
                        List<StudentMark> subjects = context.StudentMarks.ToList();
                        foreach (StudentMark item in subjects)
                        {
                            Console.Write(item.StudentId + "  ");
                        }
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (StudentMark item in subject)
                        {
                            if (item.ExamId == a)
                                Console.WriteLine("{0} {1} {2} {3}", item.StudentMarkId + "\t", item.StudentId + "\t|",
                                                   item.ExamId + "\t|", item.Markk);
                        }

                        break;
                    case 3:
                        Console.Write("Exam: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (StudentMark item in subject)
                        {
                            if (item.ExamId == a)
                                 Console.WriteLine("{0} {1} {2} {3}", item.StudentMarkId + "\t", item.StudentId + "\t|",
                                                    item.ExamId + "\t|", item.Markk);
                        }
                        break;
                    case 4:
                        Console.Write("Mark: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (StudentMark item in subject)
                        {
                            if (item.ExamId == a)
                                Console.WriteLine("{0} {1} {2} {3}", item.StudentMarkId + "\t", item.StudentId + "\t|",
                                                   item.ExamId + "\t|", item.Markk);
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
            Console.WriteLine("Update Mark Info..\n");
            Search(xx);
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1.Student Id\t2.Exam Id\t3.Mark");
            int srch = Convert.ToInt32(Console.ReadLine());
            int id; string str; StudentMark exam; int x;
            Console.WriteLine("Re_insert subject id bitte ");
            id = Convert.ToInt32(Console.ReadLine());
            exam = context.StudentMarks.SingleOrDefault(std => std.StudentMarkId == id);
            switch (srch)
            {
                case 1:
                    Console.Write("Student Ids' : \n You can Choose one of these id's:\t");
                    List<Student> sl = context.Students.ToList();
                    foreach (Student item in sl)
                    {
                        Console.Write(item.StudentId + "  ");
                    }
                    x = Convert.ToInt32(Console.ReadLine());
                    exam.StudentId = x;
                    context.SaveChanges();

                    break;
                case 2:
                    Console.Write("Exam Ids' : \n You can Choose one of these id's:\t");
                    List<Exam> exams = context.Exams.ToList();
                    foreach (Exam item in exams)
                    {
                        Console.Write(item.ExamId + "  ");
                    }
                    x = Convert.ToInt32(Console.ReadLine());
                    exam.StudentId = x;
                    context.SaveChanges();
                    break;
                case 3:
                    x = Convert.ToInt16(Console.ReadLine());
                    exam.Markk = (short?)x;
                    context.SaveChanges();
                    break;
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
