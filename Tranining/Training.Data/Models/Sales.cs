using System;
using System.Collections.Generic;

namespace Training.Data.Models
{
    public partial class Sales
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }

        public Customers Customer { get; set; }
        public Employees Employee { get; set; }
        public Products Product { get; set; }
    }
}
