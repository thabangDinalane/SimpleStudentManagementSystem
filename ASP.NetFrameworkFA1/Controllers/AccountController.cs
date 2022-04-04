
using ASP.NetFrameworkFA1.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;


namespace ASP.NetFrameworkFA1.Controllers
{
    public class AccountController : Controller 
    {
        ApplicationDbStudentContext Db = new ApplicationDbStudentContext();

        public static object CurrentUser { get; private set; }

        //GET: Account
        public ActionResult Index()
        {
            List<FacilitatorTable> facilitatorlist = Db.FacilitatorTable.ToList();
            return View(facilitatorlist);
        }

        [HttpGet]
        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account/Register
        [HttpPost]
        public ActionResult Register(FacilitatorTable f)
        {
            try
            {
                Db.FacilitatorTable.Add(f);
                Db.SaveChanges();
                return View();
            }
            catch(DbEntityValidationException e)
            {
                return View();
            }
        }

        //Working with StudentController
        // GET: Student
        public ActionResult StudentList()
        {
            List<Student> students = Db.Students.ToList<Student>();
            return View(students);
        }

        //GET: Student/Create
        [HttpGet]
        public ActionResult StudentCreate()
        {
            return View();
        }
        //GET: Student/Create
        [HttpPost]
        public ActionResult StudentCreate(Student CreateStudent)
        {
            Db.Students.Add(CreateStudent);
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

        // GET: Student/Details/6
        public ActionResult StudentDetail(int? id)
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

        //GET: Student/Delete/5
        [HttpGet]
        public ActionResult StudentDelete(int? id)
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

        //GET: Student/Delete
        [HttpPost]
        [ActionName("StudentDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = Db.Students.Find(id);
            Db.Students.Remove(student);
            Db.SaveChanges();
            return RedirectToAction("StudentList");
        }

        //GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        //GET: Account/Login
        [HttpPost]
        public ActionResult Login(FacilitatorTable user)
        {
            bool isUserExists = Db.FacilitatorTable.Any(f => f.UserName == user.UserName && f.Password == user.Password);
            if (isUserExists)
            {
                return RedirectToAction("StudentList");
            }
            else
            {
                ViewBag.fail = "Ooops, Invalid Credentails!";
                return View();
            }
        }

    }
}