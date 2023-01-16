using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models.UserModels
{
    public class TokenModel
    {
        public string Type { get; set; }
        public dynamic User { get; set; }
        public string Token { get; set; }

        public DateTime Expires { get; set; }
    }
}