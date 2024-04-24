using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wazifa.Models;

namespace Wazifa.Controllers
{
    [Authorize(Roles = RoleName.Admins)]
    public class UsersController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: Users
        public ActionResult Account(string id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        public ActionResult AddUserToRole()
        {
            AddUserToRoleViewModel viewModel = new AddUserToRoleViewModel
            {
                Users = context.Users.ToList(),
                Roles = context.Roles.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(AddUserToRoleViewModel userToRole)
        {
            var userId = userToRole.UserRole.UserId;
            var roleName = userToRole.UserRole.RoleName;

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole(userId, roleName);

            return RedirectToAction("Account", new { id = userId });
        }


    }
}