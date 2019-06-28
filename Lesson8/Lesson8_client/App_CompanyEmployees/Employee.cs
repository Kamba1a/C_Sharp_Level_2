using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CompanyEmployees
{
    class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Department Dep { get; set; }
    }
}
