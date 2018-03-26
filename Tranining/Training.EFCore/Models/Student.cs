using System;
using System.Collections.Generic;

namespace Training.EFCore.Models
{
    public partial class Student
    {
        public Student()
        {
            Class = new HashSet<Class>();
        }

        public int IdStudent { get; set; }
        public string StudentName { get; set; }

        public ICollection<Class> Class { get; set; }
    }
}
