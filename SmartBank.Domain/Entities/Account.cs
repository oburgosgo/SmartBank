using SmartBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Domain.Entities
{
    public  class Account
    {
        public Guid AccountId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public CurrencyType Currency { get; set; }
        public string AccountNumber { get; set; }
    }
}
