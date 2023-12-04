using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpDapperGallery.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}