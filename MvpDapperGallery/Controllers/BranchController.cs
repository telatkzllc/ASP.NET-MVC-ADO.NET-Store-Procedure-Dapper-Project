using Dapper;
using Microsoft.SqlServer.Server;
using MvpDapperGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvpDapperGallery.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Index()
        {
            return View(DP.Listeleme<BranchModel>("BranchViewAll"));
        }
        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if(id==0) //ekleme sayfası yüklenir
            {
                return View();
            }
            else //burada güncelleme proc ile veriler cekilir id'ye gore
            {
                DynamicParameters param= new DynamicParameters();
                param.Add("@branchNo", id);
                return View(DP.Listeleme<BranchModel>("BranchViewByNo",param).FirstOrDefault<BranchModel>()); //burayı sor.
            }
        }
        [HttpPost]
        public ActionResult EY(BranchModel branch)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@branchNo", branch.branchNo);
            param.Add("@branchName", branch.branchName);
            param.Add("@branchIncome", branch.branchIncome);
            param.Add("@branchCarstock", branch.branchCarstock);
            DP.ExecuteReturn("BranchEY", param);
            return RedirectToAction("Index");
        }
        //Delete için bir view oluşturulmasına gerek yoktur.
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@branchNo", id);
            DP.ExecuteReturn("BranchDel", param);
            return RedirectToAction("Index");

        }
    }
}