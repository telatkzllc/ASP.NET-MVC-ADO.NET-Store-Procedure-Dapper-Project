using Dapper;
using MvpDapperGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvpDapperGallery.Controllers
{
    public class UserController : Controller
    {
        private const string ConnectionString = @"Server=.;Database=DapperGallery;Integrated Security=true;";

        [HttpGet]
        public ActionResult Login()
        {
            return View(); // Login.cshtml view'ını gösterir
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Veritabanında kullanıcıyı ara
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();

                // Örnek bir sorgu, gerçek sorgunuzu projenize uygun olarak güncelleyin
                var user = db.QueryFirstOrDefault<UserModel>("SELECT * FROM User WHERE Nickname = @Nickname AND Password = @Password",
                    new { Nickname = username, Password = password });

                if (user != null)
                {
                    // Kullanıcı bulundu, giriş başarılı
                    // İstenilen yönlendirmeyi yapabilirsiniz
                    return RedirectToAction("Index", "Branch");
                }
                else
                {
                    // Kullanıcı bulunamadı, hata mesajı gösterilebilir
                    ModelState.AddModelError("", "Invalid username or password");
                    return View("Login");
                }
            }
        }
    }
}
