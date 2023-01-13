
using System.Threading.Tasks;
using System.Web.Http;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repository;
using HospitalManagementAPI.Services;

namespace HospitalManagementAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }


        // POST: api/Login
        public async Task<IHttpActionResult> LoginUser([FromBody] LoginUser userLogin)
        {
            if (!ModelState.IsValid)
            {
                var authUser = await _userManager.LoginUser(userLogin, userLogin.Password);
                return Ok(authUser);
            };
            return BadRequest("Please Fill the Required Data");
        }

        // GET: api/User/5
        [HttpGet()]
        public async Task<IHttpActionResult> GetUserById(int id)
        {
            if(id != 0)
            {
                var getUserById = await _userManager.GetUserByID(id);
                return Ok(getUserById);
            }
            return NotFound();
        }


        // GET: api/User
        //public async IQueryable<userLogin> GetAllUser()
        //{
        //    var allUser = await _userManager.GetAllUser();
        //    return allUser;
        //}

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