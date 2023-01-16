using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HospitalManagementAPI.Services;
using AutoMapper;

namespace HospitalManagementAPI.Services
{
    public class UserService : IUserservice
    {
        db_9f24e4_voywellnessEntities _context = new db_9f24e4_voywellnessEntities();

        public async Task<UserResponseManager> LoginUser(LoginUser model, string password)
        {

            var userLogin =  _context.Users.FirstOrDefault(x => x.UserName == model.Username);
            //var passwordDecoded = VerifyPasswordHash(password, userLogin.passwordSalt, userLogin.passwordSalt);

            if (userLogin != null)
            {
                if (userLogin.Password == password)
                {
                    //var getToken = GenerateToken(model);
                    return new UserResponseManager
                    {
                        Response = true,
                        Message = "User '" + model.Username + "' Logged In !",
                        Data = userLogin

                    };
                }
            }
            return null;

        }

        public async Task<UserResponseManager> GetUserByID(int id)
        {

            User userLogin = await _context.Users.FindAsync(id);

            if (userLogin != null)
            {
                return new UserResponseManager
                {
                    Response = true,
                    Message = "User Found for User Id : " + id,
                    Data =  userLogin
                   
                };
            }
            return null;
        }



        //Additional


        //public async Task<UserResponseManager> GetAllUser()
        //{
        //    //var user =  _context.userLogins.FindAsync();
        //    //return new UserResponseManager
        //    //{
        //    //    Response = true,
        //    //    Message = "List Of Users",
        //    //    Data =  user
        //    //};
        //    return null;
        //}

        //public async Task<UserResponseManager> ResgisterUser(RegisterModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<UserResponseManager> UpdateUser(int id, UpdateUser model)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<UserResponseManager> DeleteUser(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //private string GenerateToken(LoginUser user)
        //{
        //    //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
        //    //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    //var claims = new[]
        //    //{
        //    //    new Claim(ClaimTypes.NameIdentifier, user.Username),
        //    //    new Claim(ClaimTypes.Email, user.Email),
        //    //    new Claim(ClaimTypes.Role, user.Role)
        //    //};

        //    //var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //    //    _config["Jwt:Audience"],
        //    //    claims,
        //    //    expires: DateTime.Now.AddMinutes(100),
        //    //    signingCredentials: credentials);
        //    //return new JwtSecurityTokenHandler().WriteToken(token);
        //    return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJUZXN0S2V5IiwibmFtZSI6Ikhvc3BpdGFsTWFuYWdlbWVudCIsImlhdCI6MTUxNjIzOTAyMn0.Kb1ppZCl1S2lbYm80aHlp35-brcKBUPRr7yIW-HZ2Gw";
        //}

        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}

    }
}