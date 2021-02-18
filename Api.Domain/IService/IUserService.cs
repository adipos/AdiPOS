using Api.Domain.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.IService
{
    public interface IUserService
    {
        ApplicationUserDto Register(ApplicationUserDto user, string password);
        ApplicationUserDto UpdateUser(ApplicationUserDto user);
        Task<IdentityResult> DeleteUserAsync(ApplicationUserDto data);
        ApplicationUserDto GetUserById(int id);
        bool Logout();
    }
}
