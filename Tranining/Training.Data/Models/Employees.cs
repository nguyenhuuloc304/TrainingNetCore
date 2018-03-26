using System;
using System.Collections.Generic;

namespace Training.Data.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Sales> Sales { get; set; }
    }
}
