using System;
using System.Collections.Generic;

namespace EmployeeManagementBO.Models
{
    public partial class JobHistory
    {
        public int JobHistoryId { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? EndedDate { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
