using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Services
{
    public interface IAppointmentService
    {
        Task<UserResponseManager> AddAppointment(AppointmentModel Model);

        Task<UserResponseManager> getAppointmentByDate(int id, DateTime date);

    }
}
