using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool;
using NHibernate.Linq;
using MySql.Data.MySqlClient;

using FluentNHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Mapping;

namespace MVCLearning1.Controllers
{
    public class HomeController : Controller
    {
        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                    .ConnectionString(@"Server=10.151.34.45;Port=3306;Database=lpoj;Uid=root;Pwd=dotnetde;")
                    .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<lpoj_usersMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
            /* 
                ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))

                Ada dua parameter pada methods Create (dua-duanya boolean)
                parameter 1: set apakah DDL dioutput ke console atau tidak. Jika diset true, maka DDL akan ditampilkan ke console. Jika diset false, maka DDL tidak ditampilkan

                parameter 2: mengeset apakah DDL diexecute pada database yang didefinisikan pada koneksi. Jika diset true, maka NHibernate akan meng-GENERATE ULANG tabel-tabel di database. Sehingga tabel yang sudah ada akan didrop.
                Jika ingin menggunakan tabel yang sudah ada, set parameter ini menjadi FALSE.
                 * */
        }

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
            var factory = CreateSessionFactory();
            using (var session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = new lpoj_users
                    {
                        USERS_USERNAME = textName,
                        USERS_PASSWORD = textPass,
                        USERS_JOIN_DATE = DateTime.Now.Date

                    };

                    session.Save(user);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index", "Login");
        }

    }
}
