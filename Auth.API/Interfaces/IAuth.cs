using Auth.API.Models;

namespace Auth.API.Interfaces
{
    public interface IAuth
    {
        Task<bool> Login(LoginModel request);
        Task<bool> Logout(string username);
    }
}
