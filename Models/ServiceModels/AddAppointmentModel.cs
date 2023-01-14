using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models.ServiceModels
{
    public class AddAppointmentModel
    {
        public int userId { get; set; }
        public String Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        
    }
}