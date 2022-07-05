using StudentsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsWebApp.DatabaseMenager;

namespace StudentsWebApp.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            List<StudentModel> student_list = new List<StudentModel>();
            DatabaseMenager.DatabaseMenager student = new DatabaseMenager.DatabaseMenager();
            student_list = student.FetchAllStudents();
            return View("Index", student_list);
        }
        public ActionResult Details(int id)
        {
            DatabaseMenager.DatabaseMenager studentdb = new DatabaseMenager.DatabaseMenager();
            StudentModel student = studentdb.FetchOneStudent(id);
            return View("Details", student);
        }
        public ActionResult CreateForm()
        {
            var model = new StudentModel();
            return View("StudentForm", model);
        }
        public ActionResult EditForm(int id)
        {
            DatabaseMenager.DatabaseMenager studentdb = new DatabaseMenager.DatabaseMenager();
            StudentModel student = new StudentModel();
            student = studentdb.FetchOneStudent(id);
            return View("StudentForm", student);
        }
        public ActionResult DeleteStudent(int id)
        {
            DatabaseMenager.DatabaseMenager studentdb = new DatabaseMenager.DatabaseMenager();
            studentdb.DeleteStudent(id);
            List<StudentModel> students = studentdb.FetchAllStudents();
            return View("Index",students);
        }
        public ActionResult CreateStudent(StudentModel student)
        {
            DatabaseMenager.DatabaseMenager svstudent = new DatabaseMenager.DatabaseMenager();
            svstudent.CreateOrUpdateStudent(student);
            return View("Details",student);
        }
        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForName(string searchPhrase)
        {
            DatabaseMenager.DatabaseMenager studentdb = new DatabaseMenager.DatabaseMenager();
            List<StudentModel> searchresults = studentdb.SearchForName(searchPhrase);
            return View("Index", searchresults);
        }
    }
}