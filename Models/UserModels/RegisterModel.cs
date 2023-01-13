using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models
{
    public class RegisterModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public string userType { get; set; }
    }
}