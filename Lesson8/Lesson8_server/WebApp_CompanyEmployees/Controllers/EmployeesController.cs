using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp_CompanyEmployees.Models;
using System.Data;

namespace WebApp_CompanyEmployees.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeesData employeesData = new EmployeesData();

        [Route("Employees")]
        public List<Employee> GetEmployees()
        {
            return employeesData.GetEmployeesList();
        }

        [Route("Employees/{id}")]
        public Employee GetEmployeeByID(int id)
        {
            return employeesData.GetEmployeeByID(id);
        }
    }
}
