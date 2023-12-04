//using Dapper;
//using MvpDapperGallery.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//namespace MvpDapperGallery.Controllers
//{
//    public class HomeController : Controller
//    {
//        // GET: Home
//        public ActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Login(string username, string password)
//        {
//            // Kullanıcı kimlik doğrulama işlemleri

//            // Veritabanından kullanıcıyı bul
//            var user = DP.Us.FirstOrDefault(u => u.Username == username);

//            if (user != null)
//            {
//                // Kullanıcı bulundu, parolayı kontrol et
//                if (VerifyPassword(password, user.Password))
//                {
//                    // Parola doğrulandı, giriş başarılı
//                    // Yönlendirme işlemleri burada yapılabilir
//                    return RedirectToAction("Dashboard", "User");
//                }
//            }

//            // Kullanıcı adı veya parola geçersiz
//            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya parola");
//            return View(); // Giriş sayfasını tekrar göster
//        }
//    }
//}