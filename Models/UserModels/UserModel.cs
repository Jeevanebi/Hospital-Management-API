using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}