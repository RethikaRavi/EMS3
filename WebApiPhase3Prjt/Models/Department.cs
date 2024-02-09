using System;
using System.Collections.Generic;

namespace WebApiPhase3Prjt.Models
{
    public partial class Department
    {
        public Department()
        {
            EmpProfiles = new HashSet<EmpProfile>();
        }

        public int DeptCode { get; set; }
        public string DeptName { get; set; } = null!;

        public virtual ICollection<EmpProfile> EmpProfiles { get; set; }
    }
}
