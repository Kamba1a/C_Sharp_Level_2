using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApp_CompanyEmployees.Models
{
    public class EmployeesData
    {
        List<Employee> EmployeesList;

        public EmployeesData()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT Employees.ID, Employees.SecondName, Employees.FirstName, Employees.Salary, Employees.Position, Departments.ID" +
                                                " FROM Employees" +
                                                " INNER JOIN Departments" +
                                                " ON Employees.Department = Departments.ID",
                                                sqlConnection);
            sqlDataAdapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DepartmentsData departmentsData = new DepartmentsData();
            List<Department> DepartmentsList = departmentsData.GetDepartmentsList();

            EmployeesList = new List<Employee>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                int DepId = (int)dataTable.Rows[i][5];
                Department department = DepartmentsList[DepId - 1];

                EmployeesList.Add(new Employee
                {
                    ID = (int)dataTable.Rows[i][0],
                    SecondName = dataTable.Rows[i][1].ToString(),
                    FirstName = dataTable.Rows[i][2].ToString(),
                    Salary = (int)dataTable.Rows[i][3],
                    Position = dataTable.Rows[i][4].ToString(),
                    Dep = department
                });
            }
        }

        public List<Employee> GetEmployeesList()
        {
            return EmployeesList;
        }

        public Employee GetEmployeeByID(int id)
        {
            return EmployeesList.FirstOrDefault(empl => empl.ID==id);
        }
    }
}