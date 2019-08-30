using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoryDoc.Models;
using WebStoryDoc.Models.Repositories;

namespace WebStoryDoc.Controllers
{
    //[Authorize]
    public class GroupUsersController : Controller
    {
        private GroupUsersRepository groupUsersRepository;

        public GroupUsersController(GroupUsersRepository groupUsersRepository)
        {
            this.groupUsersRepository = groupUsersRepository;
        }

        // GET: GroupUsers
        public ActionResult Create()
        {
            var model = new GroupUsersModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GroupUsersModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var groupUsers = new GroupUsers
            {
                Name = model.Name

            };
            groupUsersRepository.Save(groupUsers);

            return RedirectToAction("Index", "Home");
        }
    }
}