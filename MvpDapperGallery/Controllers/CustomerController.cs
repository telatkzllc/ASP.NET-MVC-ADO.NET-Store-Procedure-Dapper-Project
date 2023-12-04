using Dapper;
using MvpDapperGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvpDapperGallery.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View(DP.Listeleme<CustomerModel>("CustomerViewAll"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0) //ekleme sayfası yüklenir
            {
                return View();
            }
            else //burada güncelleme proc ile veriler cekilir id'ye gore
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@customerNo", id);
                return View(DP.Listeleme<CustomerModel>("CustomerViewByNo", param).FirstOrDefault<CustomerModel>()); //burayı sor.
            }
        }
        [HttpPost]
        public ActionResult EY(CustomerModel customer)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@customerNo", customer.customerNo);
            param.Add("@customerName", customer.customerName);
            param.Add("@customerPhone", customer.customerPhone);
            param.Add("@customerDeposit", customer.customerDeposit);
            param.Add("@employeeNo", customer.employeeNo);
            DP.ExecuteReturn("CustomerEY", param);
            return RedirectToAction("Index");
        }
        //Delete için bir view oluşturulmasına gerek yoktur.
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@customerNo", id);
            DP.ExecuteReturn("CustomerDel", param);
            return RedirectToAction("Index");

        }
    }
}