using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Text;


namespace MVCLearning1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Credits()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUser(string textName, string textPass)
        {
            return RedirectToAction("Index", "Login");
            //var factory = CreateSessionFactory();
            //using (var session = factory.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        var user = new lpoj_users
            //        {
            //            USERS_USERNAME = textName,
            //            USERS_PASSWORD = textPass,
            //            USERS_JOIN_DATE = DateTime.Now.Date

            //        };

            //        session.Save(user);
            //        transaction.Commit();
            //    }
            //}
            //return RedirectToAction("Index", "Login");
        }

    }
}
