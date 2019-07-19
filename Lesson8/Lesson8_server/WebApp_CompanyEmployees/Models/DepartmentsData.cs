using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApp_CompanyEmployees.Models
{
    public class DepartmentsData
    {
        List<Department> DepartmentsList;

        public DepartmentsData()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM Departments", sqlConnection);
            sqlDataAdapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DepartmentsList = new List<Department>();
            for (int i = 0; i < dataTable.Rows.Count; i++) DepartmentsList.Add(new Department { ID = (int)dataTable.Rows[i][0], Name = dataTable.Rows[i][1].ToString() });
        }

        public List<Department> GetDepartmentsList()
        {

            return DepartmentsList;
        }

        public Department GetDepartmentByID(int id)
        {
            return DepartmentsList.FirstOrDefault(dep => dep.ID==id);
        }
    }
}