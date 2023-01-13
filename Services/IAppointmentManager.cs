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
    public interface IAppointmentManager
    {
        Task<UserResponseManager> addApppointment(string id, AppointmentModel Model);

        Task<UserResponseManager> getAppointmentByDate(string id, DateTime date);

    }

    public class AppointmenrManager : IAppointmentManager
    {
        private readonly HospitalManagementDbEntities2 _context;

        public AppointmenrManager(HospitalManagementDbEntities2 hospitalManagementDbEntities)
        {
            _context = hospitalManagementDbEntities;
        }
        public async Task<UserResponseManager> addApppointment(string id, AppointmentModel Model)
        {

            userLogin userLogged = await _context.userLogins.FindAsync(id);
            if (userLogged.email == Model.Email)
            {
                var appointment = new appointment
                {
                    email= Model.Email
                };
                _context.userLogins.Add(Model);
                await _context.SaveChangesAsync();
                return new UserResponseManager
                { 
                    Response = true,
                    Message = "Appointment Created for the "+Model.Email+" to the Doctor " + Model.Doctor
                };
            }
            return new UserResponseManager
            {

            };
        }

        public async Task<UserResponseManager> getAppointmentByDate(string id, DateTime date)
        {
            var appointmentScheduled = await _context.userLogins.FindAsync(id);
            if(id != null)
            {
                var dateAppointment = await _context.userLogins.FindAsync(date);
                return new UserResponseManager
                {
                    Response = true,
                    Message = "Appointments for the User " + appointmentScheduled.username,
                    Data = new AppointmentModel
                    {
                        AppointmentDate = DateTime.Now
                    }
                };
            }
            return new UserResponseManager
            {
                Response = false,
                Message = "No Appointments for the User " + appointmentScheduled.username;
            };
        }
    }
}
