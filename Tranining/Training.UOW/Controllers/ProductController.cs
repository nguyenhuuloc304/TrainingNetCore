using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.UOW.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.UOW.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var listCus = new List<Customer>();
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 1" });
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2" });
            ViewBag.student = new Student { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2", Class = "DTH2" };
            return View(listCus);
        }

        public IActionResult Edit()
        {
            var listCus = new List<Customer>();
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 1" });
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2" });
            ViewBag.student = new Student { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2", Class = "DTH2" };
            return View(listCus);
        }
    }
}
