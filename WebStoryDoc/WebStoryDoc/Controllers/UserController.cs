using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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

        private GroupUsersRepository groupUsersRepository;

        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public UserController(UserRepository userRepository, GroupUsersRepository groupUsersRepository)
        {
            this.userRepository = userRepository;
            this.groupUsersRepository = groupUsersRepository;
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
                UserName = model.UserName,
                CreationDate = DateTime.Now,
                BirthDate = model.BirthDate,
                GroupUsers = groupUsersRepository.Find(new GroupUsersFilter {Id = model.SelectGroupUsersId }).First()
            };

            var res = UserManager.CreateAsync(user, model.Password);

            if (res.Result == IdentityResult.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize]
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