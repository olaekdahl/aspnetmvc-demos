using Socrates.DataAccess;
using Socrates.Filters;
using Socrates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
//using System.Web.Configuration;
using System.Web.Mvc;

namespace Socrates.Controllers
{
    public class HomeController : BaseController
    {
        //ISocratesContext ctx;

        //public HomeController()
        //{
        //    string conn = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    ctx = SocratesContextFactory.GetContext(conn);
        //}


        public ActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString());
        }
        public ActionResult Index(int pageNum = 0)
        {
            List<Course> courses = ctx.GetAllCourses().ToList();
            
            return View(courses);
        }

        [ChildActionOnly]
        public ActionResult GetSummary()
        {
            var departments = ctx.GetAllDepartments().ToList();
            List<Course> courses = ctx.GetAllCourses().ToList();
            var summary = new SummaryModel();
            summary.Courses = courses;
            summary.Departments = departments;
            return PartialView("_PartialDemo", summary);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult AddCourse()
        {
            return View();
        }


        //[AuditFilter]
        public ActionResult Edit(int id)
        {
            var model = new CourseViewModel();
            model.Course = ctx.GetCourse(id);
            model.Departments = ctx.GetAllDepartments().ToList();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int departmentId, Course c)
        {
            Course course = ctx.GetCourse(c.Id);
            course.Department = ctx.GetAllDepartments().SingleOrDefault(d => d.Id == departmentId);
            //if (ModelState.IsValid)
            //{
                ctx.MarkAsModified(course);
                ctx.SaveChanges();
            //}

            return RedirectToAction("Index");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(FormCollection c)
        {
            //ModelState.IsValid

            Course course = new Course();
            if(TryUpdateModel(course))
            {
                ctx.MarkAsAdded(course);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        public ActionResult Create()
        {
            return View(new Course());
        }

        public ActionResult Details(int id)
        {
            var course = ctx.GetCourse(id);
            return View(course);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hello(string message)
        {
            var obj = new { FirstName = "John", LastName = "Doe", Message = message };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}