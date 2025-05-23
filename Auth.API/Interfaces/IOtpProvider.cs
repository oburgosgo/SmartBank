using Auth.API.Models;

namespace Auth.API.Interfaces
{
    public interface IOtpProvider
    {
        Task<bool> GenerateOtp(GenerateOtpRequest request);
        Task<string> GetOtp(string key);
        Task RemoveOtp(string key);


    }
}
