using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Shared.API.Reponse
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static APIResponse<T> Ok(T? data, string message) =>
             new() { Success = true, Data = data, Message = message };

        public static APIResponse<T> Failed(string message)=>
            new() { Success = false,Message = message};

    }
}
