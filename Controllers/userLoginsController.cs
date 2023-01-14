using System;
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

namespace HospitalManagementAPI.Controllers
{
    public class userLoginsController : ApiController
    {
        private HospitalManagementDbEntities5 db = new HospitalManagementDbEntities5();

        // GET: api/userLogins
        public IQueryable<userLogin> GetuserLogins()
        {
            return db.userLogins;
        }

        // GET: api/userLogins/5
        [ResponseType(typeof(userLogin))]
        public async Task<IHttpActionResult> GetuserLogin(int id)
        {
            userLogin userLogin = await db.userLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return Ok(userLogin);
        }

        // PUT: api/userLogins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutuserLogin(int id, userLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLogin.userid)
            {
                return BadRequest();
            }

            db.Entry(userLogin).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userLoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/userLogins
        [ResponseType(typeof(userLogin))]
        public async Task<IHttpActionResult> PostuserLogin(userLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userLogins.Add(userLogin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userLogin.userid }, userLogin);
        }

        // DELETE: api/userLogins/5
        [ResponseType(typeof(userLogin))]
        public async Task<IHttpActionResult> DeleteuserLogin(int id)
        {
            userLogin userLogin = await db.userLogins.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            db.userLogins.Remove(userLogin);
            await db.SaveChangesAsync();

            return Ok(userLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userLoginExists(int id)
        {
            return db.userLogins.Count(e => e.userid == id) > 0;
        }
    }
}