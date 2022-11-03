using System;
using System.Collections.Generic;

#nullable disable

namespace firstapi.Models
{
    public partial class Employee
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public double? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public string City { get; set; }
    }
}
