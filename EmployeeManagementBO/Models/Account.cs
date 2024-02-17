using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Account
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int DeleteFlag { get; set; }
        public int? AddressId { get; set; }

        public virtual Address? Address { get; set; } = null;
        public virtual Employee? Employee { get; set; } = null;
    }
}
