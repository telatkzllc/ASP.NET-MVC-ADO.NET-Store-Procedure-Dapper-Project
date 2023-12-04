using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpDapperGallery.Models
{
    public class BranchModel
    {
        public int branchNo { get; set; }
        public string branchName { get; set; }
        public decimal branchIncome { get; set; }
        public int branchCarstock { get; set; }
    }
}