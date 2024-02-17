using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
    }
}
