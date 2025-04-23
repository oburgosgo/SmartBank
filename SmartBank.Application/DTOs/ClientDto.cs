using SmartBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application.DTOs
{
    public class ClientDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public IdType IdType { get; set; }
        public int BurnDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public GenderType Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
