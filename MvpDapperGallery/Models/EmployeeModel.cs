using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpDapperGallery.Models
{
    public class EmployeeModel
    {
        public int employeeNo { get; set; }
        public string employeeName { get; set; }
        public string employeePhone { get; set; }
        public decimal employeeSalary { get; set; }
        public int branchNo { get; set; }
    }
}