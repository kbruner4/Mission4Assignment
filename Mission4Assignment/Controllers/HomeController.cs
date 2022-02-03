using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext BlahContext { get; set; }

        public HomeController(MovieFormContext someName)
        {
            BlahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult MovieForm ()
        {

            ViewBag.Categories =  BlahContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm (MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                BlahContext.Add(mr);
                BlahContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else
            {
                ViewBag.Categories = BlahContext.Categories.ToList();
                return View(mr);
            }
            
        }

        public IActionResult MovieList ()
        {
            var movies = BlahContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int categoryid)
        {
            ViewBag.Categories = BlahContext.Categories.ToList();

            var form = BlahContext.responses.Single(x => x.CategoryId == categoryid);

            return View("MovieForm", form);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse blah)
        {
            BlahContext.Update(blah);
            BlahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int categoryid)
        {
            var form = BlahContext.responses.Single(x => x.CategoryId == categoryid);

            return View();
        }

        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            BlahContext.responses.Remove(mr);
            BlahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
