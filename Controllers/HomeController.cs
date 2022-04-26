using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        private ProductsContext db;

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        public HomeController(ProductsContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet("/new")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("New");
        }

        [HttpPost("/create")]
        public IActionResult Create(Product product)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid == false)
            {
                return View("New");
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
