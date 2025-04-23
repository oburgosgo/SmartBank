using Auth.API.Models;
using Auth.API.Models.DTOs;

namespace Auth.API.Interfaces
{
    public interface IUser
    {
        Task<bool> Register(UserModel request);
        Task<bool> DeketeByUsername(string username);
        Task<UserDto> GetByUsername(string username);
        List<UserDto> GetUsers();
    }
}
