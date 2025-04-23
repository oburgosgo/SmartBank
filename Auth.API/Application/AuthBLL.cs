using Auth.API.Interfaces;
using Auth.API.Models;
using Azure.Core;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Application
{
    public class AuthBLL : IAuth
    {

        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthBLL(SignInManager<IdentityUser> signInManager) { 
            this._signInManager = signInManager;
        }
        public async Task<bool> Login(LoginModel request)
        {
            var result = await this._signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);

            return result.Succeeded;
        }

        public async Task<bool> Logout(string username)
        {
            //var result = await this._signInManager.SignOutAsync(username);

            return true;
        }
    }
}
