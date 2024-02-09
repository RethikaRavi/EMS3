using System;
using System.Collections.Generic;

namespace WebApiPhase3Prjt.Models
{
    public partial class EmpProfile
    {
        public int Ecode { get; set; }
        public string Ename { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public int? Edept { get; set; }

        public virtual Department? EdeptNavigation { get; set; }
    }
}
