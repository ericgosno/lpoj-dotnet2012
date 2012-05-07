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
    public class LoginController : Controller
    {
        //
        // GET: /Login/
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
            return View();
        }

        [HttpPost]
        public ActionResult CekLogin(string textName, string textPass)
        {
            var nhibernateHelper = CreateSessionFactory();
            lpoj_users tempUser = new lpoj_users();
            int jumItem = 0;
            string command = "";
            using (var session = nhibernateHelper.OpenSession())
            {
                var query = (from make in session.Query<lpoj_users>()
                             where make.USERS_USERNAME == textName
                             select make).ToList<lpoj_users>();
                jumItem = query.Count();
                if (jumItem > 0) tempUser = query.First<lpoj_users>();
            }

            if (tempUser == null)
                //command = "Failed tidak ditemukan";
                return RedirectToAction("Index","Home");
            else 
            {
                
                command = textName + " " + textPass + " " + tempUser.USERS_USERNAME + " " + tempUser.USERS_PASSWORD;
                if (textName != "admin" && textName == tempUser.USERS_USERNAME && tempUser.USERS_PASSWORD == textPass)
                {
                    Session["userActive"] = tempUser;
                    //command += "/Benar masuk ke User";
                    return RedirectToAction("Index", "User");
                }
                else if (textName == "admin" && textName == tempUser.USERS_USERNAME && tempUser.USERS_PASSWORD == textPass)
                {
                    Session["userActive"] = tempUser;
                    //command += "/Benar masuk ke Admin";
                    return RedirectToAction("Index", "Admin");
                    //Response.Redirect("AdminPage.aspx");
                }
                else
                {
                   // command += "/Salah Username atau Password";
                    return RedirectToAction("Index", "Login");
                }
            }
            
            //return RedirectToAction("Index");
        }

    }


}
