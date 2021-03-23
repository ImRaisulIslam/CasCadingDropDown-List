using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CasCadingDropDown.Models;
using CasCadingDropDown.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using CasCadingDropDown.ViewModel;
using CasCadingDropDown.Repository;

namespace CasCadingDropDown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly StudentRepo repo;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context, StudentRepo repo)
        {
            _logger = logger;
           _context = context;
            this.repo = repo;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Country()
        {
          var country =  _context.Country.ToList();
            return View(country);
        }
        public IActionResult AddCountry( )
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _context.Country.Add(country);
            _context.SaveChanges();

            return RedirectToAction ("Index");
        }

        public IActionResult StateIndex()
        {
          var model =  _context.State.ToList();
            return View(model);
        }

        public IActionResult AddState()
        {
            ViewBag.Country = new SelectList(_context.Country, "Id", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult AddState(State state)
        {
            _context.State.Add(state);
            _context.SaveChanges();
            return RedirectToAction("StateIndex");
        }



        public IActionResult CityIndex()
        {
            var model = _context.City.ToList();
            return View(model);
        }

        public IActionResult AddCity()
        {
            ViewBag.city = new SelectList(_context.State, "Id", "StateName");
            return View();
        }



        [HttpPost]
        public IActionResult AddCity(City city)
        {
            _context.City.Add(city);
            _context.SaveChanges();
            return View();
        }


        public IActionResult CasCadingList()
        {
            ViewBag.Countries = new SelectList(_context.Country, "Id", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult CasCadingList(StudentViewModel model)
        {
            var student = new Student
            {
                FullName = model.Name,
                CountryId = model.CountryId,
                StateId = model.StateId
            };

            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction("StudentInfo");
        }

        public IActionResult StudentInfo()
        {
            var students = repo.StudentInfo();
           
            return View(students);
        }



        public JsonResult LoadState(int Id)
        {
            var state = _context.State.Where(id => id.CountryId == Id);
            return Json(new SelectList(state, "Id", "StateName"));
        }

        public JsonResult LoadCity(int CountryId)
        {

            var citylist = new SelectList(_context.State.Where(c => c.CountryId == CountryId), "Id", "StateName");
            return Json(citylist);
            //var state = _context.City.Where(id => id.StateId == Id);
            //return Json(new SelectList(state, "Id", "StateName"));
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
