﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementAPI.Models.ServiceModels
{
    public class AppointmentModel
    {
        public int userid { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public doctorInfo doctor { get; set; }
    }
}