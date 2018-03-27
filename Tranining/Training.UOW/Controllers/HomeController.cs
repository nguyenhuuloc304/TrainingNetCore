using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.UOW.Models;
using Training.UOW.DAL;

namespace Training.UOW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UnitOfWork UOW = new UnitOfWork();
            var customer = UOW.CustomersRepository.Get();
            ViewBag.student = new Student { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2", Class = "DTH2" };

            UOW.CustomersRepository.Insert(new Data.Models.Customers { Name = "David" });
            UOW.CourseRepository.Insert(new Data.Models.Products { Name = "Dotnet", Price = 1 });
            UOW.Save();

            return View(customer);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
