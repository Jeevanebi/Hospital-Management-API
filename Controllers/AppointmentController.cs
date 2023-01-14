﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HospitalManagementAPI;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.ServiceModels;
using HospitalManagementAPI.Repo;
using HospitalManagementAPI.Repository;
using HospitalManagementAPI.Services;

namespace HospitalManagementAPI.Controllers
{
    public class AppointmentController : ApiController
    {
        private IAppointmentService _appointmentContext = new AppointmentService();
        private IUserservice _userservice = new UserService();

        // GET: api/Appointment?userid=YOURID&date=YOURDATE
        [ResponseType(typeof(appoinmentInfo))]
        public async Task<IHttpActionResult> GetappoinmentInfo(int userid, DateTime date)
        {
            var user = await  _userservice.GetUserByID(userid);
            if (user != null)
            {
                var appointments = await _appointmentContext.getAppointmentByDate(userid, date);
                return Ok(appointments);
            }
            return Ok(new UserResponseManager
            {
                Response = false,
                Message = "Some properties are invalid !"
            });
        }



        // POST: api/Appointment
        [ResponseType(typeof(appoinmentInfo))]
        public async Task<IHttpActionResult> Postappoinments([FromBody]AppointmentModel appoinmentInfo)
        {
            if (appoinmentInfo != null)
            {
                var userAppointment = await _appointmentContext.AddAppointment(appoinmentInfo);
                if(userAppointment != null)
                {
                    return Ok(userAppointment);
                }
            }
            else
            {
                return Ok(new UserResponseManager
                {
                    Response = false,
                    Message = "Input Model is Not Valid !"
                });
            }
            return CreatedAtRoute("DefaultApi", new { id = appoinmentInfo.userid }, appoinmentInfo);
        }


        //// GET: api/appoinment
        //public IQueryable<appoinmentInfo> GetappoinmentInfoes()
        //{
        //    return db.appoinmentInfoes;
        //}

        //// PUT: api/appoinment/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutappoinmentInfo(int id, appoinmentInfo appoinmentInfo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != appoinmentInfo.ap_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(appoinmentInfo).State = System.Data.Entity.EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!appoinmentInfoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE: api/appoinment/5
        //[ResponseType(typeof(appoinmentInfo))]
        //public async Task<IHttpActionResult> DeleteappoinmentInfo(int id)
        //{
        //    appoinmentInfo appoinmentInfo = await db.appoinmentInfoes.FindAsync(id);
        //    if (appoinmentInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.appoinmentInfoes.Remove(appoinmentInfo);
        //    await db.SaveChangesAsync();

        //    return Ok(appoinmentInfo);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool appoinmentInfoExists(int id)
        //{
        //    return db.appoinmentInfoes.Count(e => e.ap_id == id) > 0;
        //}
    }
}