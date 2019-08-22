﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoryDoc.Models;
using WebStoryDoc.Models.Repositories;

namespace WebStoryDoc.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository userRepository;

        public HomeController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Title = "Это супер крутое название",
                Time = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            model.Time = DateTime.Now;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}