using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCLearning1.Models;

namespace MVCLearning1.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private lpojEntities entity;
        private lpoj_users activeUser;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            entity = new lpojEntities();
            IQueryable<lpoj_users> result = from f in entity.lpoj_users
                                            where f.USERS_USERNAME == activeUser.USERS_USERNAME
                                            select f;
            try { users = result.First<lpoj_users>(); }
            catch (Exception ex) { return; }

            if (activeUser.USERS_PASSWORD == oldPassword.Text && newPassword.Text == confirmPassword.Text)
            {
                users.USERS_PASSWORD = newPassword.Text;
            }

            entity.SaveChanges();
            Session["userActive"] = users;
            activeUser = users;
            Response.Redirect("AdminPage.aspx");
        }

    }
}
