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
    public class DepartmentsController : ApiController
    {
        DepartmentsData departmentsData = new DepartmentsData();

        [Route("Departments")]
        public List<Department> GetDepartments()
        {
            return departmentsData.GetDepartmentsList();
        }

        [Route("Departments/{id}")]
        public Department GetDepartmentByID(int id)
        {

            return departmentsData.GetDepartmentByID(id);

        }
    }
}
