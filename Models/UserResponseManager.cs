using HospitalManagementAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace HospitalManagementAPI.Models
{
    public class UserResponseManager
    {
        public bool Response { get; set; }

        public string Message { get; set; } 

        public dynamic Data { get; set; }

    }

}