
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            if (userLogin.Username != null && userLogin.Password != null)
            {
                var authUser = await _userManager.LoginUser(userLogin, userLogin.Password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    var UserNotFoundError = new UserResponseManager
                    {
                        Response = false,
                        Message = "User '" + userLogin.Username + "' is Not Authenticated"
                    };

                    return Content(HttpStatusCode.BadGateway, UserNotFoundError);
                }
            };
            var Notfound = new UserResponseManager
            {
                Response = false,
                Message = "Please Fill the Required Data"
            };
            return Content(HttpStatusCode.BadRequest, Notfound);
        }

        // GET: api/User/ID
        public async Task<IHttpActionResult> GetUserData(int id)
        {
            if(id != null)
            {
                var getUserById = await _userManager.GetUserByID(id);
                if (getUserById != null)
                {
                    return Ok(getUserById);
                }
                var userNotFound = new UserResponseManager
                {
                    Response = false,
                    Message = "User Not Found for User Id : " + id,
                };
                return Content(HttpStatusCode.NotFound,userNotFound);
            }
            return BadRequest();
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