using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public DateTime HiredDate { get; set; }
        public string Username { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int JobId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
    }
}
