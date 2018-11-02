using AdventureWorks.Models.DAL;
using AdventureWorks.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class HomeController : Controller
    {
        DataAccess data = new DataAccess();
        public ActionResult Index()
        {
            var products = data.GetProducts();
            return View(products);
        }

        [HttpPost]
        public ActionResult Search(string product)
        {
            var products = data.Search(product);
            return View("Index", products);
        }


        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel emp)
        {
            //emp.LastName = "Ekdahl";
            data.AddEmployee(emp);
            return RedirectToAction("Employees");
        }

        public ActionResult Employees()
        {
            var emps = data.GetEmployees();
            return View(emps);
        }

        public ActionResult Details(int id)
        {
            var product = data.GetProduct(id);
            return View(product);
        }

        public ActionResult GetImage(int pid)
        {
            var image = data.GetPhoto(pid);
            return new FileStreamResult(new MemoryStream(image), "image/png");
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}
