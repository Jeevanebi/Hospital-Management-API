using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models.ServiceModels
{
    public class AppointmentModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
        public String Doctor { get; set; }

    }
}