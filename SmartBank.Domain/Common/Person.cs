using SmartBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Domain.Common
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public IdType IdType { get; set; }
        public int BurnDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public GenderType Gender { get; set; }


    }
}
