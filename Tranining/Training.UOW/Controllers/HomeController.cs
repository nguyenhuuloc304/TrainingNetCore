﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.UOW.Models;

namespace Training.UOW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var listCus = new List<Customer>();
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 1" });
            listCus.Add(new Customer { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2" });
            ViewBag.student = new Student { Id = Guid.NewGuid().ToString(), Name = "Nguyen 2", Class = "DTH2" };
            return View(listCus);
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
