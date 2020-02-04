using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dojodachi Fox = new Dojodachi();
            HttpContext.Session.SetInt32("fullness", Fox.Fullness);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");

            HttpContext.Session.SetInt32("happiness", Fox.Happiness);
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");

            HttpContext.Session.SetInt32("meals", Fox.Meals);
            ViewBag.meals = HttpContext.Session.GetInt32("meals");

            HttpContext.Session.SetInt32("energy", Fox.Energy);
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            
            
            return View(Fox);
        }

        [HttpGet("feed")]

        public IActionResult Feed()
        {
            int? MealCount = HttpContext.Session.GetInt32("meals");
            if(MealCount > 0)
            {
            MealCount--;
            HttpContext.Session.SetInt32("meals", (int)MealCount);
            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            }
            else
            {
                ViewBag.meals = HttpContext.Session.GetInt32("meals");
            }

            Random rand = new Random();
            int? Full = HttpContext.Session.GetInt32("fullness");
            
            if(ViewBag.meals > 0)
            {
            Full = Full + rand.Next(5,10);
            HttpContext.Session.SetInt32("fullness", (int)Full);
            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            string message = new string("You fed your Dojodachi! Fullness+, Meals-");
            ViewBag.message = message;
            }
            else
            {
                ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
                string message = new string("You don't have any meals left to feed your Dojodachi!");
                ViewBag.message = message;
            }

            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");

            return View("Index");
        }

        [HttpGet("play")]

        public IActionResult Play()
        {
            int? PlayCount = HttpContext.Session.GetInt32("energy");
            if(PlayCount >= 5)
            {
            PlayCount = PlayCount - 5;
            HttpContext.Session.SetInt32("energy", (int)PlayCount);
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            }
            else
            {
                ViewBag.energy = 0;
            }

            Random rand = new Random();
            int? Happy = HttpContext.Session.GetInt32("happiness");
            
            if(ViewBag.energy > 0)
            {
            Happy = Happy + rand.Next(5,10);
            HttpContext.Session.SetInt32("happiness", (int)Happy);
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            string message = new string("You played with your Dojodachi! Happiness++");
            ViewBag.message = message;
            }
            else{
                ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
                string message = new string("You ran out of energy!");
                ViewBag.message = message;
            }

            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");


            return View("Index");

        }

        [HttpGet("work")]

        public IActionResult Work()
        {
            int? WorkCount = HttpContext.Session.GetInt32("energy");
            if(WorkCount >= 5)
            {
            WorkCount = WorkCount - 5;
            HttpContext.Session.SetInt32("energy", (int)WorkCount);
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            }
            else
            {
                ViewBag.energy = 0;
            }

            Random rand = new Random();
            int? MealNum = HttpContext.Session.GetInt32("meals");
            
            if(ViewBag.energy > 5)
            {
            MealNum = MealNum + rand.Next(1,3);
            HttpContext.Session.SetInt32("meals", (int)MealNum);
            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            string message = new string("You worked with your Dojodachi! Energy--, Meals++");
            ViewBag.message = message;
            }
            else{
                ViewBag.meals = HttpContext.Session.GetInt32("meals");
                string message = new string("Your Dojodachi doesn't have enough energy to work!");
                ViewBag.message = message;
            }

            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");


            return View("Index");
        }

        [HttpGet("sleep")]

        public IActionResult Sleep()
        {
            int? sleep = HttpContext.Session.GetInt32("energy");
            sleep = sleep + 15;
            HttpContext.Session.SetInt32("energy", (int)sleep);
            ViewBag.energy = HttpContext.Session.GetInt32("energy");


            int? SleepHappy = HttpContext.Session.GetInt32("happiness");
            SleepHappy = SleepHappy - 5;
            HttpContext.Session.SetInt32("happiness", (int)SleepHappy);
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");

            int? SleepFull = HttpContext.Session.GetInt32("fullness");
            SleepFull = SleepFull - 5;
            HttpContext.Session.SetInt32("fullness", (int)SleepFull);
            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");


            string message = new string("Your Dojodachi slept! Energy++, Happiness--, Fullness--");
            ViewBag.message = message;



            ViewBag.fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.meals = HttpContext.Session.GetInt32("meals");


            return View("Index");
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
