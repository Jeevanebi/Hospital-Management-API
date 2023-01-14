using HospitalManagementAPI.Models;
//using HospitalManagementAPI.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace HospitalManagementAPI.Repository
{
    public interface IUserservice
    {
        //**
        Task<UserResponseManager> GetUserByID(int id);
        Task<UserResponseManager> LoginUser(LoginUser model, string password);

        //--
        //Task<UserResponseManager> GetAllUser();
        //Task<UserResponseManager> ResgisterUser(RegisterModel model);
        //Task<UserResponseManager> UpdateUser(int id, UpdateUser model);
        //Task<UserResponseManager> DeleteUser(int id);

        // * Requested
        // -- Additional
    }
  
    
}