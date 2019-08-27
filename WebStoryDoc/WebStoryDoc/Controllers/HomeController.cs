using System;
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

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Title = "Хранилище документов",
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
    }
}