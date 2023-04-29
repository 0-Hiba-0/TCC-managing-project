using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp12.Data;
using ConsoleApp12.Models;

namespace ConsoleApp12.Controllers
{
    internal class DepartmentController
    {
        TccsysDbContext context = new TccsysDbContext();
        public void Index()
        {
           var dept = context.Departments.OrderBy(std => std.DepartmentId);
            List<Department> departments = context.Departments.ToList();
            Console.WriteLine("1.Id\t2.Department Name");
            foreach (Department item in dept)
            {
                Console.WriteLine("{0} {1}", item.DepartmentId + "\t", item.DepartmentName );
            }
        }
        public void Create()
        {

           
            Department dept = new Department();
            Console.Write("Department Name: ");
            dept.DepartmentName = Console.ReadLine();
            context.Add(dept);
            context.SaveChanges();
            Console.WriteLine("Done!");
        }
        public void Search(int x)
        {
            var results = new TccsysDbContext();
            List<Department> departments = results.Departments.ToList();
            int a;
            string str;
            try
            {
                switch (x)
                {
                    case 1:
                        Console.Write("Id: ");
                        a = Convert.ToInt32(Console.ReadLine());
                        foreach (Department item in departments)
                        {
                            if (item.DepartmentId == a)
                                Console.WriteLine("{0} | {1} ", item.DepartmentId, item.DepartmentName);                                         
                        }
                        break;
                    case 2:
                        Console.Write("Department Name: ");
                        str = Console.ReadLine();
                        foreach (Department item in departments)
                        {
                            if (item.DepartmentName == str)
                                Console.WriteLine("{0} | {1} ", item.DepartmentId, item.DepartmentName);                                          
                        }
                        break;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Error Happen");
                throw;
            }
        }
        public void Update(int xx)
        {
            Console.WriteLine("Update Student Info..\n");
            Search(xx);
            int id; string str; Department dept; int x;
            Console.WriteLine("Re_insert subject id bitte ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert new Department Name");
            dept = context.Departments.SingleOrDefault(std => std.DepartmentId == id);
                    str = Console.ReadLine();
                    dept.DepartmentName = str;
                    context.SaveChanges();
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
                    var d1 = context.Departments.Where(dept => dept.DepartmentId == a).FirstOrDefault();
                    if (d1 is Department)
                    {
                        context.Departments.Remove(d1);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;

                case 2:
                    str = Console.ReadLine();
                    var d2 = context.Departments.Where(dept => dept.DepartmentName == str).FirstOrDefault();
                    if (d2 is Department)
                    {
                        context.Remove(d2);
                    }
                    context.SaveChanges();
                    Console.WriteLine("Successfully Deleted!");
                    break;
            }
            context.SaveChanges();
        }
    }
}
