using HospitalManagementAPI.Models.ServiceModels;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace HospitalManagementAPI.Repo
{

    public class AppointmentService : IAppointmentService
    {
        db_9f24e4_voywellnessEntities _context = new db_9f24e4_voywellnessEntities();


        public async Task<UserResponseManager> AddAppointment(AppointmentModel Model)
        {
            User user = await _context.Users.FindAsync(Model.userid);
            if (user != null)
            {
                //DateTime dateNow = new DateTime(10);
                var appointments = new Register_Appointment
                {
                    FK_CustomerID = user.UserId,
                    Appoitment_Date = Model.AppointmentDate,
                    Appoitment_Time =Model.AppointmentTime,
                   /* Inserted_time = dateNow,*/ //DateTime.Now
                    Status = 1
                };
                _context.Register_Appointment.Add(appointments);

                try
                {
                    await _context.SaveChangesAsync();
                    return new UserResponseManager
                    {
                        Response = true,
                        Message = "Appointment Created for the " + user.UserName,
                        Data= appointments
                        
                    };
                }
                catch (DbUpdateException)
                {
                        throw;
                }
            }
            return null;
        }

        public async Task<UserResponseManager> getAppointmentByDate(int id, DateTime date)
        {
            Register_Appointment appoinmentInfo =  _context.Register_Appointment.FirstOrDefault(x=>x.FK_CustomerID == id);
            if (appoinmentInfo != null)
            {
                var dateAppointment = _context.Register_Appointment.Where(x=> x.FK_CustomerID == appoinmentInfo.FK_CustomerID).Where(x => x.Appoitment_Date == date );
                if (dateAppointment != null)
                {
                    
                    return new UserResponseManager
                    {
                        Response = true,
                        Message = "Appointments found for the User!" + appoinmentInfo.FK_CustomerID,
                        Data = dateAppointment
                        
                    };
                }
                return new UserResponseManager
                {
                    Response = false,
                    Message = "User Id '" + appoinmentInfo.FK_CustomerID + "'has not added any appointments on '" + date +"'"
                };
            }
            return null;
        }

        private bool appoinmentInfoExists(int id)
        {
            return _context.Register_Appointment.Count(e => e.Appoitment_Id == id) > 0;
        }


    }
}