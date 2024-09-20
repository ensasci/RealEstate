using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Users.Repositories
{
    public interface IUserService
    {

        Task<LoginResponseModel> Login(LoginRequestModel request);
        Task<bool> Add(AddUserRequestModel request);
        Task<bool> Update(UpdateUserRequestModel request);
        Task<bool> Delete(int id);
        Task<bool> SendResetPassword(ResetPasswordRequest request);
        List<UserListItemModel> GetAll();
        Task<List<UserListItemModel>> GetAllUserByAdmin(GetAllUserByAdminRequestModel request);
        Task<GetUserReponseModel> GetById(int id);
        Task<bool> IsAdmin(int id);

    }
}
