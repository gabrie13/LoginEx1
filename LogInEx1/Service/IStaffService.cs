using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LogInEx1.Models;

namespace LogInEx1.Service
{
    interface IStaffService
    {
        List<EmployeeViewModel> GetAll();

        EmployeeViewModel FindById(int id);

        EmployeeViewModel Create(EmployeeViewModel employee);
    }
}
