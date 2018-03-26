using System;
using System.Collections.Generic;

namespace Training.EFCore.Models
{
    public partial class Class
    {
        public int IdClass { get; set; }
        public string ClassName { get; set; }
        public int? IdStudent { get; set; }

        public Student IdStudentNavigation { get; set; }
    }
}
