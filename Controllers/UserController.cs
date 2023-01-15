
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repository;
using HospitalManagementAPI.Services;
//using HospitalManagementAPI.Services;

namespace HospitalManagementAPI.Controllers
{
    public class UserController : ApiController
    {
       
         private IUserservice _userManager = new UserService();

        //GET: api/User
        public async Task<IHttpActionResult> GetAllUser()
        {
             return Ok("Welcome to Hospital Management API" +
                " Endpoints :" +
                " * POST: api/User/5(LOGIN) " +
                " * GET: api/User/ID(GET_USER_BY_ID)" +
                " * POST: api/Appointment(ADD APPOINTMENT) " +
                " * GET: api/Appointment?userid=YOURID&date=YOURDATE(GET_APPOINTMENT_BY_DATE = yyyy-mm-dd)");
        }

        // POST: api/User/5
        public async Task<IHttpActionResult>  PostLogin([FromBody] LoginUser userLogin)
        {
            if (ModelState.IsValid)
            {
                var authUser = await _userManager.LoginUser(userLogin, userLogin.Password);
                return Ok(authUser);
            };
            var Notfound = new UserResponseManager
            {
                Response = false,
                Message = "Please Fill the Required Data"
            };
            return Ok(Notfound);
        }

        // GET: api/User/ID
        public async Task<IHttpActionResult> GetUserData(int id)
        {
            if(id != 0)
            {
                var getUserById = await _userManager.GetUserByID(id);
                return Ok(getUserById);
            }
            return NotFound();
        }


  

        // PUT: api/User/5
        //public async Task<IHttpActionResult> PutuserLogin(int id, userLogin userLogin)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != userLogin.userid)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(userLogin).State = System.Data.Entity.EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!userLoginExists(id))
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

        // POST: api/User
        //public async Task<IHttpActionResult> PostuserLogin(userLogin userLogin)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.userLogins.Add(userLogin);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = userLogin.userid }, userLogin);
        //}

        // DELETE: api/User/5
        
        //public async Task<IHttpActionResult> DeleteuserLogin(int id)
        //{
        //    userLogin userLogin = await db.userLogins.FindAsync(id);
        //    if (userLogin == null)
        //    {
        //        return NotFound();
        //    }

        //    db.userLogins.Remove(userLogin);
        //    await db.SaveChangesAsync();

        //    return Ok(userLogin);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool userLoginExists(int id)
        //{
        //    return db.userLogins.Count(e => e.userid == id) > 0;
        //}
    }
}