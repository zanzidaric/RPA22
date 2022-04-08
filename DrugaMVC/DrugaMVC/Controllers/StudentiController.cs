using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrugaMVC.Models;

namespace DrugaMVC.Controllers
{
    public class StudentiController : Controller
    {
        // GET: Studenti
        public ActionResult Index()
        {
            var studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            };
            // Get the students from the database in the real application
            return View(studentList);            
        }
        public ActionResult TestRazorja()
        {
            Student miha = new Student()
            {
                StudentId = 12,
                StudentName = "Miha",
                Age = 21
            };
            return View(miha);
        }
        public ActionResult Edit(int? id)
        {
            var studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve", Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill", Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            };
            var miha = studentList.Where(a => a.StudentId == id).FirstOrDefault();
            return View(miha);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include="StudentId,StudentName")]Student std)
        {
            string x = std.StudentName;
            // dejanski posodobi bazo
            return RedirectToAction("Index");
        }
    }
}