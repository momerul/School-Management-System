using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanglaMvc.Models;
using System.Data;

namespace BanglaMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Details(int Id)
        {
            Faculty faculty = new Faculty()
            {
                ID = Id
            };
            List<FacultyDetails> dt = faculty.GetAllFaculty();
            return View(dt);
        }

        public ActionResult AllStudents()
        {
            Faculty faculty = new Faculty();
            List<StudentDetails> details= faculty.AllStudents();
            return View(details);
        }

        YYYEntities student = new YYYEntities();

        public ActionResult AllStudent(string Search)
        {
            return View(student.StudentDetails.Where(x => x.StudentName.Contains(Search) || Search == null).ToList());
        }


        public ActionResult StudentDetails(int Id)
        {
            Faculty faculty = new Faculty()
            {
                ID = Id
            };
            List<StudentDetails> dt = faculty.GetAllStudents();
            return View(dt);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";

            return View();
        }       
    }
}