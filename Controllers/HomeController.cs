using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostintheWoods.Models;
using LostintheWoods.Factory;

namespace LostintheWoods.Controllers
{
    public class HomeController : Controller
    {
        private TrailFactory _dapperTrail;
        //constructor
        public HomeController()
        {
            _dapperTrail = new TrailFactory();

        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.trails = _dapperTrail.AllTrails();
            return View();
        }
        [HttpGet("AddTrail")]
        public IActionResult AddTrail(){
            return View();
        }
        [HttpPost("AddTrailtoDb")]
        public IActionResult AddTrailtoDb(AllTrails trails){
            if(ModelState.IsValid){
                _dapperTrail.AddTrails(trails);
                return RedirectToAction("Index");
            }
            return View("AddTrail");
        }
        [HttpGet("Trail/{id}")]
        public IActionResult TrailInfo(string id){
            ViewBag.showTrailInfo = _dapperTrail.TrailInfo(id);
            return View("TrailInfo");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}