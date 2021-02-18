using Api.Database.Entity;
using Api.Domain.Dto;
using Api.Domain.IService;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;  

        public UserService(UserManager<ApplicationUser> _userManager, IMapper _mapper)
        {
            this._userManager = _userManager;
            this._mapper = _mapper;
        }
        public async Task<IdentityResult> DeleteUserAsync(ApplicationUserDto data)
        {
            var user = _mapper.Map<ApplicationUser>(data);
            var response = await _userManager.DeleteAsync(user);
            return response;
        }

        public ApplicationUserDto GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public ApplicationUserDto Register(ApplicationUserDto userDto, string password)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            user.CreatedOn = DateTime.Now;
            user.LastModifiedOn = DateTime.Now;
            user.LastModifiedBy = 1;
            user.CreatedBy = 1;
            var userNew = _userManager.CreateAsync(user, password).Result;
            return userDto;
        }

        public ApplicationUserDto UpdateUser(ApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        
    }
}
