using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models
{
    public class UpdateUser
    {
        public string username { get; set; }
        public string email { get; set; }
        public string userType { get; set; }
    }
}