using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private Models.EmployeesDBEntities _db = new Models.EmployeesDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Employees.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude="Id")] Models.Employee employeeToAdd)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Employees.Add(employeeToAdd);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
