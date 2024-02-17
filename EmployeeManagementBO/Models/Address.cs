using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Address
    {

        public int AddressId { get; set; }
        public string Street { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public DateTime? UpdatedDate { get; set; }

        public virtual Account? Account { get; set; } = null;
    }
}
