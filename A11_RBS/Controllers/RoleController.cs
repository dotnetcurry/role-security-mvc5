using System;
using System.Linq;
using System.Web.Mvc;

using A11_RBS.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace A11_RBS.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext(); 
        }
       
        

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Set Role for Users
        /// </summary>
        /// <returns></returns>
        public ActionResult SetRoleToUser()
        {
            var list = context.Roles.OrderBy(role => role.Name).ToList().Select(role => new SelectListItem { Value = role.Name.ToString(), Text = role.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAddToRole(string uname, string rolename)
        {
            ApplicationUser user = context.Users.Where(usr => usr.UserName.Equals(uname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            // Display All Roles in DropDown

            var list = context.Roles.OrderBy(role => role.Name).ToList().Select(role => new SelectListItem { Value = role.Name.ToString(), Text = role.Name }).ToList();
            ViewBag.Roles = list;

            if (user != null)
            {
                var account = new AccountController();
                account.UserManager.AddToRoleAsync(user.Id, rolename);

                ViewBag.ResultMessage = "Role created successfully !";

                return View("SetRoleToUser");
            }
            else
            {
                ViewBag.ErrorMessage = "Sorry user is not available";
                return View("SetRoleToUser");
            }

        }
    }
}