using HospitalManagementAPI.Models.ServiceModels;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace HospitalManagementAPI.Repo
{
    public class AppointmentService : IAppointmentService
    {
        HospitalDbEntities1 _context = new HospitalDbEntities1();


        public async Task<UserResponseManager> AddAppointment(AppointmentModel Model)
        {
            userLogin user = await _context.userLogins.FindAsync(Model.userid);
            if (user != null)
            {
                var appointments = new appoinmentInfo
                {
                    userid = user.userid,
                    appointmentDate = Model.AppointmentDate,
                    appointmentTime =Model.AppointmentTime
                };
                _context.appoinmentInfoes.Add(appointments);

                try
                {
                    await _context.SaveChangesAsync();
                    return new UserResponseManager
                    {
                        Response = true,
                        Message = "Appointment Created for the " + user.username
                    };
                }
                catch (DbUpdateException)
                {
                        throw;
                }
            }
            return new UserResponseManager
            {

            };
        }

        public async Task<UserResponseManager> getAppointmentByDate(int id, DateTime date)
        {
            appoinmentInfo appoinmentInfo = await _context.appoinmentInfoes.FindAsync(id);
            if (appoinmentInfo != null)
            {
                var dateAppointment = _context.appoinmentInfoes.FirstOrDefault(x => x.appointmentDate == date);
                if (dateAppointment != null)
                {
                    return new UserResponseManager
                    {
                        Response = true,
                        Message = "Appointments found for the User  !",
                        Data = new userLogin{
                            username = "sucess" //for testing
                        }
                        
                    };
                }

            }
            return new UserResponseManager
            {
                Response = false,
                Message = "No Appointments for the User"
            };
        }

        private bool appoinmentInfoExists(int id)
        {
            return _context.appoinmentInfoes.Count(e => e.ap_id == id) > 0;
        }


    }
}