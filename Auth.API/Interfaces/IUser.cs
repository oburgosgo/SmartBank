using Auth.API.Models;
using Auth.API.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Interfaces
{
    public interface IUser
    {
        Task<IdentityResult> Register(UserModel request);
        Task<bool> DeketeByUsername(string username);
        Task<UserDto> GetByUsername(string username);
        List<UserDto> GetUsers();
    }
}
