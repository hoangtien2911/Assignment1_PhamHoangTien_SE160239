using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
    }
}
