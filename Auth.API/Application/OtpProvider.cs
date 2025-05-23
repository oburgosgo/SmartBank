using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace Auth.API.Application
{
    public class OtpProvider : IOtpProvider
    {

        private readonly IDistributedCache _cache;
        public OtpProvider(IDistributedCache cache)
        {
            this._cache = cache;
        }
        public async Task<bool> GenerateOtp(GenerateOtpRequest request)
        {

            await StoreOtp(request.Username, GenerateOtp(), TimeSpan.FromMinutes(5));

            return true;
        }


        private string GenerateOtp()
        {
            var bytes = RandomNumberGenerator.GetBytes(4);
            var otp = BitConverter.ToUInt32(bytes,0) %(uint)Math.Pow(10, 6);
            return otp.ToString("D6");
        }

        private async Task StoreOtp(string key, string otp, TimeSpan expirationTime)
        {
            await _cache.SetStringAsync($"otp:{key}", otp, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            });
        }

        public async Task<string?> GetOtp(string key)
        {
            string otp = await _cache.GetStringAsync($"otp:{key}");

            return otp;
        }

        public async Task RemoveOtp(string key)
        {
            await _cache.RemoveAsync($"otp:{key}");
        }

        public async Task RegenerateOtp(string key, string otp, TimeSpan expirationTime)
        {
            await _cache.RefreshAsync($"otp:{key}", otp, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            });
        }
    }
}
