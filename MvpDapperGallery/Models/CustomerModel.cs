using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpDapperGallery.Models
{
    public class CustomerModel
    {
        public int customerNo { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public decimal customerDeposit { get; set; }
        public int employeeNo { get; set; }
    }
}