using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLearning1.Models;


using System.Text;

namespace MVCLearning1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private lpojEntities entity;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CekLogin(string textName, string textPass)
        {
            entity = new lpojEntities();
            lpoj_users users;
            IQueryable<lpoj_users> dbPassword = from f in entity.lpoj_users
                                                where f.USERS_USERNAME == textName
                                                select f;
            try { users = dbPassword.First<lpoj_users>(); }
            catch (Exception ex) { return RedirectToAction("Index", "Home"); }

            if (textName!= "admin" && textName == users.USERS_USERNAME && users.USERS_PASSWORD == textPass)
            {
                Session["userActive"] = users;
                return RedirectToAction("Index", "User");
            }
            else if (textName == "admin" && textName == users.USERS_USERNAME && users.USERS_PASSWORD == textPass)
            {
                Session["userActive"] = users;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }


}
