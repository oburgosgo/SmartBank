using Auth.API.Interfaces;
using Auth.API.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

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

            throw new NotImplementedException();
        }


        private string GenerateOtp()
        {
            var bytes = RandomNumberGenerator.GetBytes(4);
            var otp = BitConverter.ToUInt32(bytes,0) %(uint)Math.Pow(10, 6);
            return otp.ToString();
        }

        private async Task StoreOtp(string key, string otp, TimeSpan expirationTime)
        {
            await _cache.SetStringAsync($"otp:{key}", otp, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            });
        }

        private async Task<string?> GetOtpStored(string key)
        {
            string otp = await _cache.GetStringAsync($"otp:{key}");

            return otp;
        }

        private async Task RemoveOtpStored(string key)
        {
            await _cache.RemoveAsync($"otp:{key}");
        }
    }
}
