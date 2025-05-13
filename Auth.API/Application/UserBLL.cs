using Auth.API.Interfaces;
using Auth.API.Models;
using Auth.API.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Application
{
    public class UserBLL : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;


        public UserBLL(UserManager<IdentityUser> userManager) { 
            this ._userManager = userManager;  
        }
        public async Task<bool> DeketeByUsername(string username)
        {

            var result = await _userManager.DeleteAsync(new IdentityUser() {UserName= username });
            return result.Succeeded;
        }

        public Task<UserDto> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUsers()
        {
            
            var users = _userManager.Users.Select(x=> new UserDto()
            {
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
            }).ToList();

            return users;
        }

        public async Task<bool> Register(UserModel request)
        {
            var user = new IdentityUser { UserName = request.Email, 
                                          TwoFactorEnabled = request.TwoFactor,
                                          Email = request.Email,
                                          PhoneNumber = request.PhoneNumber};

            var result =await _userManager.CreateAsync(user, request.Password);

            return result.Succeeded;
        }
    }
}
