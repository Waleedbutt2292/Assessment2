using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airline1.Controllers
{
    public class firstController : Controller
    {
        private RMSContext R = null;
        public firstController(RMSContext _R)
        {
            R = _R;
        }

        public IActionResult Index()
        {


            return View();
        }
        [HttpGet]
        public IActionResult AddNewAirline()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewAirline(Airline a)
        {
            try
            {

                R.Airline.AddAsync(a);
                R.SaveChangesAsync();
                ViewBag.Message = a.Name + " airline saved Succeesfully";
                ViewBag.MessageType = "s";

            }
            catch (Exception)
            {
                ViewBag.Message = "unable to save the Airline";
                ViewBag.MessageType = "e";

            }
            return View();
        }

        public IActionResult ViewList()
        {
            var g=R.Airline.ToList();
            return View(g);
        }

        public IActionResult deleteAirline(int Id)
        {
            var c = R.Airline.Find(Id);
            R.Airline.Remove(c);
            R.SaveChanges();
            return RedirectToAction("ViewList");
        }
        [HttpGet]
        public IActionResult EditAirline(int id)
        {
            var f = R.Airline.Find(id);
            return View(f);
        }

        [HttpPost]
        public IActionResult EditAirline(Airline s)
        {
            R.Airline.Update(s);
            R.SaveChanges();
            return RedirectToAction("ViewList");
        }
        
        public IActionResult viewairlinedetail(int id)
        {
            var t = R.Airline.Find(id);
            return View(t);
        }


    }
}