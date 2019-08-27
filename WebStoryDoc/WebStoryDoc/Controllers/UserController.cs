using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoryDoc.Models;
using WebStoryDoc.Models.Filters;
using WebStoryDoc.Models.Repositories;

namespace WebStoryDoc.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Create()
        {
            var model = new UserModel()
            {
                GroupUsers = new SelectList(userRepository.GroupUsersAll(), "Id", "Name")
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Person
            {
                Login = model.Login,
                Password = model.Password,
                CreationDate = DateTime.Now
                //GroupUsers = model.SelectGroupUsersId
            };
            userRepository.Save(user);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List(UserFilter filter)
        {
            var model = new UserListModel
            {
                Items = userRepository.Find(filter)
            };

            return View(model);
        }
    }
}