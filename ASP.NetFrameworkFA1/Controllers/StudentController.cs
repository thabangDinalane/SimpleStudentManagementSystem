using ASP.NetFrameworkFA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASP.NetFrameworkFA1.Controllers
{
    public class StudentController : Controller
    {
         private ApplicationDbStudentContext Db = new ApplicationDbStudentContext();

        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = Db.Students.ToList<Student>();
            return View(students);
        }

        // GET: Student/Details/6
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Student student = Db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //GET: Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //GET: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            Db.Students.Add(student);
            Db.SaveChanges();
            return View();
        }

        //GET: Student/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student student = Db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //GET: Student/Edit 
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Db.Entry(student).State = EntityState.Modified;
            Db.SaveChanges();
            return View();
        }


        //GET: Student/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Student student = Db.Students.Find(id);
            if(student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //GET: Student/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = Db.Students.Find(id);
            Db.Students.Remove(student);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}