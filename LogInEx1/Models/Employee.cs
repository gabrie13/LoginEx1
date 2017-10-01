using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LogInEx1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string HireDate { get; set; }

        public decimal Wage { get; set; }

        public int Positionid { get; set; }

        public int LocationId { get; set; }

        public virtual Position Position { get; set; }

        public virtual Location Location { get; set; }
    }
}