﻿namespace Auth.API.Models
{
    public class UserModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
    }
}
