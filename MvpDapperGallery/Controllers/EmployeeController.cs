using Dapper;
using MvpDapperGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvpDapperGallery.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View(DP.Listeleme<EmployeeModel>("EmployeeViewAll"));
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
                param.Add("@employeeNo", id);
                return View(DP.Listeleme<EmployeeModel>("EmployeeViewByNo", param).FirstOrDefault<EmployeeModel>()); //burayı sor.
            }
        }
        [HttpPost]
        public ActionResult EY(EmployeeModel employee)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@employeeNo", employee.employeeNo);
            param.Add("@employeeName", employee.employeeName);
            param.Add("@employeePhone", employee.employeePhone);
            param.Add("@employeeSalary", employee.employeeSalary);
            param.Add("@branchNo", employee.branchNo);
            DP.ExecuteReturn("EmployeeEY", param);
            return RedirectToAction("Index");
        }
        //Delete için bir view oluşturulmasına gerek yoktur.
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@employeeNo", id);
            DP.ExecuteReturn("EmployeeDel", param);
            return RedirectToAction("Index");

        }
    }
}