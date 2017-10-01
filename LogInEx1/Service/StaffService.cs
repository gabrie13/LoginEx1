using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LogInEx1.Models;

namespace LogInEx1.Service
{
    public class StaffService : IStaffService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<EmployeeViewModel> GetAll()
        {
            var employeeList = db.Employees.ToList();
            return employeeList.Select(emp => EmpDto(emp)).ToList();
        }

        private static EmployeeViewModel EmpDto(Employee emp)
        {
            return new EmployeeViewModel
            {
                EmployeeId  = emp.EmployeeId,
                FirstName   = emp.FirstName,
                LastName    = emp.LastName,
                Address     = emp.Address,
                City        = emp.City, 
                State       = emp.State,
                ZipCode     = emp.ZipCode,
                PhoneNumber = emp.PhoneNumber,
                Email       = emp.Email,
                HireDate    = emp.HireDate,
                Wage        = emp.Wage,
                Position    = emp.Position,
                Location    = emp.Location
            };
        }

        public EmployeeViewModel FindById(int id)
        {
            var employee = db.Employees.Find(id);
            return employee != null ? EmpDto(employee) : null;
        }

        public EmployeeViewModel Create(EmployeeViewModel employee)
        {
            var emp = fromEmp(employee);
            db.Employees.Add(emp);
            db.SaveChanges();

            employee.EmployeeId = emp.EmployeeId;
            return EmpDto(emp);
        }

        private static Employee fromEmp(EmployeeViewModel employee)
        {
            var emp = new Employee
            {
                EmployeeId  = employee.EmployeeId,
                LocationId  = employee.LocationId,
                Positionid  = employee.Positionid,
                FirstName   = employee.FirstName,
                LastName    = employee.LastName,
                Address     = employee.Address,
                City        = employee.City,
                State       = employee.State,
                ZipCode     = employee.ZipCode,
                PhoneNumber = employee.PhoneNumber,
                Email       = employee.Email,
                HireDate    = employee.HireDate,
                Wage        = employee.Wage,
                Position = employee.Position,
                Location = employee.Location
            };
            return emp;
        }
    }
}